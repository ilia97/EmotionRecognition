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

		private Dictionary<string, string> supportedEmotionsSubsets = new Dictionary<string, string>
		{
			["anger, fear, surprise, calm"] = "anger, fear, surprise, calm",    // new[] { "anger", "fear", "surprise", "calm" },
			["happiness, disgust, surprise"] = "happiness, disgust, surprise",  //new[] { "happiness", "disgust", "surprise" },
			["anger, fear, surprise"] = "anger, fear, surprise",            // new[] { "anger", "fear", "surprise" },
			["anger, fear, calm"] = "anger, fear, calm",                // new[] { "anger", "fear", "calm" },
			["anger, happiness, calm"] = "anger, happiness, calm",      // new[] { "anger", "happiness", "calm" },
			["anger, fear, disgust"] = "anger, fear, disgust",          // new[] { "anger", "fear", "disgust" },
			["calm, disgust, surprise"] = "calm, disgust, surprise",        // new[] { "calm", "disgust", "surprise" },
			["sadness, disgust, surprise"] = "sadness, disgust, surprise",  // new[] { "sadness", "disgust", "surprise" },
			["anger, happiness"] = "anger, happiness"               // new[] { "anger", "happiness" }
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
				.Select(kvp => new ComboBoxItem() { Text = kvp.Key, Value = kvp.Value })
				.ToList();

			radioButton2.Checked = true;
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
		}

		private void RadioButton2_CheckedChanged(object sender, EventArgs e)
		{
			this.isImageFolderDataSource = radioButton2.Checked;
		}


		private async void Button2_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.dataSourcePath))
			{
				MessageBox.Show("Please specify data source path.");

				return;
			}

			if (string.IsNullOrEmpty(this.outputModelPath))
			{
				MessageBox.Show("Please specify output model path.");

				return;
			}

			var selectedNeuralNetwork = (ComboBoxItem)comboBox1.SelectedItem;

			this.richTextBox1.Text = "";
			await recognitionAlgorithms[(NeuralNetworkType)selectedNeuralNetwork.Value].Train(
				this.dataSourcePath,
				this.isCsvDataSource,
				this.isImageFolderDataSource,
				this.outputModelPath,
				line =>
				{
					this.MainThread.Post(new SendOrPostCallback(o =>
					{
						this.richTextBox1.Text += $"{(string)o} \n";
					}), 
					line);
				});

		}

		// Prediction controls

		private void TextBox4_TextChanged(object sender, EventArgs e)
		{
			this.trainedModelPath = textBox4.Text;
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.trainedModelPath))
			{
				MessageBox.Show("Please specify trained model path.");

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

			this.richTextBox2.Text = "";
			await recognitionAlgorithms[(NeuralNetworkType)selectedNeuralNetwork.Value].Recognize(
				this.trainedModelPath,
				imagePath,
				selectedEmotionsSubset.Value as string,
				line =>
				{
					this.MainThread.Post(new SendOrPostCallback(o =>
					{
						this.richTextBox2.Text += $"{(string)o} \n";
					}),
					line);
				});
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
					pictureBox1.Image = new Bitmap(dlg.FileName);
				}
			}
		}
	}
}
