using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using FaceRecognition.BL;
using FaceRecognition.Models.Enums;
using FaceRecognition.UI.ViewModels;

namespace FaceRecognition.UI
{
	public partial class MainForm : Form
	{
		private OutputWriter TrainingOutputWriter;
		private OutputWriter RecognitionOutputWriter;

		private TimeRecorder TrainingTimeRecorder;
		private TimeRecorder RecognitionTimeRecorder;

		private readonly Dictionary<NeuralNetworkType, NeuaralNetworkStrategy> recognitionAlgorithms = new Dictionary<NeuralNetworkType, NeuaralNetworkStrategy>()
		{
			{ NeuralNetworkType.Convolutional, new ConvolutionalNNStrategy() },
			{ NeuralNetworkType.TimeDelayConv, new TimeDelayConvNNStrategy() },
			{ NeuralNetworkType.ConvolutionalLstm, new ConvolutionalLstmNNStrategy() },
			{ NeuralNetworkType.TransferLearning, new TransferLearningNNStrategy() },
		};

		private static string appDataFolder = @"\AppData\";

		private static string GetFullPath(string relativePath)
		{
			return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath.TrimStart('\\', '/'));
		}

		private SynchronizationContext MainThread;

		// User Info
		private string userName;
		private string userGroup;

		// Training Info
		private bool isCsvDataSource = false;
		private bool isImageFolderDataSource = true;
		private string dataSourcePath;
		private string outputModelPath;

		private Dictionary<string, string[]> supportedEmotionsSubsets = new Dictionary<string, string[]>
		{
			["anger, fear, surprise, calm"]		= new[] { "anger", "fear", "surprise", "calm" },  // "anger,fear,surprise,calm",		// 
			["happiness, disgust, surprise"]	= new[] { "happiness", "disgust", "surprise" },	  // "happiness,disgust,surprise",		// 
			["anger, fear, surprise"]			= new[] { "anger", "fear", "surprise" },		  // "anger,fear,surprise",            // 
			["anger, fear, calm"]				= new[] { "anger", "fear", "calm" },			  // "anger,fear, calm",               // 
			["anger, happiness, calm"]			= new[] { "anger", "happiness", "calm" },		  // "anger, happiness, calm",			// 
			["anger, fear, disgust"]			= new[] { "anger", "fear", "disgust" },			  // "anger, fear, disgust",			// 
			["calm, disgust, surprise"]			= new[] { "calm", "disgust", "surprise" },		  // "calm, disgust, surprise",        // 
			["sadness, disgust, surprise"]		= new[] { "sadness", "disgust", "surprise" },	  // "sadness, disgust, surprise",		// 
			["anger, happiness"]				= new[] { "anger", "happiness" }                  // "anger, happiness"				// 
		};

		// Prediction Info
		private string trainedModelPath;
		private static string imageToPredict = Path.Combine(appDataFolder, "image.png");
		private static string emotionsSubset;


		public MainForm()
		{
			InitializeComponent();

			this.MainThread = SynchronizationContext.Current;

			nnTypeComboBox.DisplayMember = "Text";
			nnTypeComboBox.ValueMember = "Value";
			nnTypeComboBox.DataSource = new List<ComboBoxItem>()
			{
				new ComboBoxItem() { Text = "ConvolutionalNN", Value = NeuralNetworkType.Convolutional },
				new ComboBoxItem() { Text = "TimeDelayConvNN", Value = NeuralNetworkType.TimeDelayConv },
				new ComboBoxItem() { Text = "ConvolutionalLstmNN", Value = NeuralNetworkType.ConvolutionalLstm },
				new ComboBoxItem() { Text = "TransferLearningNN", Value = NeuralNetworkType.TransferLearning },
			};

			comboBox1.DisplayMember = "Text";
			comboBox1.ValueMember = "Value";
			comboBox1.DataSource = new List<ComboBoxItem>()
			{
				new ComboBoxItem() { Text = "ConvolutionalNN", Value = NeuralNetworkType.Convolutional },
				new ComboBoxItem() { Text = "TimeDelayConvNN", Value = NeuralNetworkType.TimeDelayConv },
				new ComboBoxItem() { Text = "ConvolutionalLstmNN", Value = NeuralNetworkType.ConvolutionalLstm },
				new ComboBoxItem() { Text = "TransferLearningNN", Value = NeuralNetworkType.TransferLearning },
			};

			comboBox2.DisplayMember = "Text";
			comboBox2.ValueMember = "Value";
			comboBox2.DataSource = supportedEmotionsSubsets
				.Select(kvp => new ComboBoxItem() { Text = kvp.Key, Value = string.Join(",", kvp.Value) })
				.ToList();

			radioButton2.Checked = true;

			this.label13.Text += " " + this.recognitionAlgorithms[NeuralNetworkType.Convolutional].GetPythonExeFullPath();
			this.label14.Text += " " + this.recognitionAlgorithms[NeuralNetworkType.Convolutional].GetEmoPyExamplesFolderFullPath();

			this.TrainingOutputWriter = new OutputWriter(this.richTextBox1);
			this.RecognitionOutputWriter = new OutputWriter(this.richTextBox2);
			this.TrainingTimeRecorder = new TimeRecorder(this.label18);
			this.RecognitionTimeRecorder = new TimeRecorder(this.label19);

			this.tabControl1.TabPages.Remove(this.tabPage1);
			this.tabControl1.TabPages.Remove(this.tabPage2);
		}

		// Training controls

		private void TextBox5_TextChanged(object sender, EventArgs e)
		{
			this.userName = this.textBox5.Text;
		}

		private void TextBox7_TextChanged(object sender, EventArgs e)
		{
			this.userGroup = this.textBox7.Text;
		}

		private void TextBox2_TextChanged(object sender, EventArgs e)
		{
			this.dataSourcePath = textBox2.Text;
		}

		private void TextBox3_TextChanged(object sender, EventArgs e)
		{
			this.outputModelPath = textBox3.Text;
		}

		private void RadioButton1_CheckedChanged(object sender, EventArgs e)
		{
			this.isCsvDataSource = radioButton1.Checked;
			this.textBox2.Text = "";
		}

		private void RadioButton2_CheckedChanged(object sender, EventArgs e)
		{
			this.isImageFolderDataSource = radioButton2.Checked;
			this.textBox2.Text = "";
		}


		private async void Button2_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.dataSourcePath) || !IsDataSourceExist())
			{
				MessageBox.Show("Please specify existing data source path.");

				return;
			}

			if (string.IsNullOrEmpty(this.outputModelPath) || !Directory.Exists(this.outputModelPath))
			{
				MessageBox.Show("Please specify existing output model path.");

				return;
			}

			var selectedNeuralNetwork = (ComboBoxItem)comboBox1.SelectedItem;

			this.button2.Enabled = false;
			this.TrainingOutputWriter.Clear();
			this.TrainingTimeRecorder.Start();
			this.TrainingOutputWriter.AddLine("---------- TRAINING STARTED ----------");
			await recognitionAlgorithms[(NeuralNetworkType)selectedNeuralNetwork.Value].Train(
				this.dataSourcePath,
				this.isCsvDataSource,
				this.isImageFolderDataSource,
				this.outputModelPath,
				line => this.TrainingOutputWriter.AddLine(line));

			this.TrainingOutputWriter.AddLine("---------- TRAINING FINISHED ----------");
			this.TrainingTimeRecorder.Stop();
			this.button2.Enabled = true;
		}

		private bool IsDataSourceExist()
		{
			if (this.isCsvDataSource)
			{
				return File.Exists(this.dataSourcePath);
			}

			if (this.isImageFolderDataSource)
			{
				return Directory.Exists(this.dataSourcePath);
			}

			return false;
		}

		// Prediction controls

		private void TextBox4_TextChanged(object sender, EventArgs e)
		{
			this.trainedModelPath = textBox4.Text;
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			string trainedModelPathValidationError = GetTrainedModelPathValidationError();
			if (!string.IsNullOrEmpty(trainedModelPathValidationError))
			{
				MessageBox.Show(trainedModelPathValidationError);

				return;
			}

			if (pictureBox1.Image == null)
			{
				MessageBox.Show("Please select a picture you would like to recognize.");

				return;
			}

			var selectedNeuralNetwork = (ComboBoxItem)nnTypeComboBox.SelectedItem;
			if (selectedNeuralNetwork == null)
			{
				MessageBox.Show("Please select any neural network to recognize an image.");

				return;
			}

			var selectedEmotionsSubset = (ComboBoxItem)comboBox2.SelectedItem;
			if (selectedEmotionsSubset == null)
			{
				MessageBox.Show("Please select the emotions subset.");

				return;
			}

			var imagePath = GetImagePath(pictureBox1.Image);

			this.button1.Enabled = false;
			this.RecognitionOutputWriter.Clear();
			this.RecognitionTimeRecorder.Start();
			this.RecognitionOutputWriter.AddLine("---------- RECOGNITION STARTED ----------");
			await recognitionAlgorithms[(NeuralNetworkType)selectedNeuralNetwork.Value].Recognize(
				this.trainedModelPath,
				imagePath,
				selectedEmotionsSubset.Value as string,
				line => this.RecognitionOutputWriter.AddLine(line));

			this.RecognitionOutputWriter.AddLine("---------- RECOGNITION FINISHED ----------");
			this.RecognitionTimeRecorder.Stop();
			this.button1.Enabled = true;
		}

		private string GetTrainedModelPathValidationError()
		{
			if (string.IsNullOrEmpty(this.trainedModelPath) || !Directory.Exists(this.trainedModelPath))
			{
				return "Please specify existing trained model path.";
			}

			return string.Empty;
		}

		private string GetImagePath(Image image)
		{
			if (File.Exists(imageToPredict))
			{
				File.Delete(imageToPredict);
			}

			string path = GetFullPath(imageToPredict);

			image.Save(path, ImageFormat.Png);

			return path;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				dlg.Title = "Open Image";
				dlg.Filter = "png files (*.png)|*.png";

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					using (Image image = Image.FromFile(dlg.FileName))
					{
						pictureBox1.Image = new Bitmap(image, 320, 245);
					}
				}
			}
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			if (this.isImageFolderDataSource)
			{
				using (FolderBrowserDialog dlg = new FolderBrowserDialog())
				{
					dlg.ShowNewFolderButton = true;
					dlg.Description = "Select data source directory";

					if (dlg.ShowDialog() == DialogResult.OK)
					{
						this.textBox2.Text = dlg.SelectedPath;
					}
				}
			}

			if (this.isCsvDataSource)
			{
				using (OpenFileDialog dlg = new OpenFileDialog())
				{
					dlg.Title = "Select CSV data source";
					dlg.Filter = "csv files (*.csv)|*.csv";

					if (dlg.ShowDialog() == DialogResult.OK)
					{
						this.textBox2.Text = dlg.FileName;
					}
				}
			}
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog dlg = new FolderBrowserDialog())
			{
				dlg.ShowNewFolderButton = true;
				dlg.Description = "Select output folder for trained model";

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					this.textBox3.Text = dlg.SelectedPath;
				}
			}
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog dlg = new FolderBrowserDialog())
			{
				dlg.ShowNewFolderButton = false;
				dlg.Description = "Select folder with trained model";

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					this.textBox4.Text = dlg.SelectedPath;
				}
			}
		}

		private void Button6_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.userName))
			{
				MessageBox.Show("Please enter the user name.");

				return;
			}

			if (string.IsNullOrEmpty(this.userGroup))
			{
				MessageBox.Show("Please enter the group name.");

				return;
			}

			this.label22.Text = this.userName;
			this.label21.Text = this.userGroup;
			this.flowLayoutPanel1.Visible = true;
			this.flowLayoutPanel2.Visible = true;

			this.tabControl1.TabPages.Remove(this.tabPage0);
			this.tabControl1.TabPages.Add(this.tabPage1);
			this.tabControl1.TabPages.Add(this.tabPage2);
		}
	}
}
