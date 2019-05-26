using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FaceRecognition.BL;
using FaceRecognition.BL.Interfaces;
using FaceRecognition.Models.Enums;
using FaceRecognition.UI.ViewModels;

namespace FaceRecognition.UI
{
    public partial class MainForm : Form
    {
        private readonly Dictionary<NeuralNetworkType, INeuralNetworkStrategy> recognitionAlgorithms;

        public MainForm()
        {
            InitializeComponent();

            nnTypeComboBox.DataSource = new List<ComboBoxItem>()
            {
                new ComboBoxItem() { Text = "ConvolutionalNN", Value = NeuralNetworkType.Convolutional },
                new ComboBoxItem() { Text = "TimeDelayConvNN", Value = NeuralNetworkType.TimeDelayConv },
                new ComboBoxItem() { Text = "ConvolutionalLstmNN", Value = NeuralNetworkType.ConvolutionalLstm },
                new ComboBoxItem() { Text = "TransferLearningNN", Value = NeuralNetworkType.TransferLearning },
            };

            nnTypeComboBox.DisplayMember = "Text";
            nnTypeComboBox.ValueMember = "Value";

            recognitionAlgorithms = new Dictionary<NeuralNetworkType, INeuralNetworkStrategy>()
            {
                { NeuralNetworkType.Convolutional, new ConvolutionalNNStrategy() },
                { NeuralNetworkType.TimeDelayConv, new TimeDelayConvNNStrategy() },
                { NeuralNetworkType.ConvolutionalLstm, new ConvolutionalLstmNNStrategy() },
                { NeuralNetworkType.TransferLearning, new TransferLearningNNStrategy() },
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please select a picture you would like to recognize.");

                return;
            }

            var image = ConvertImageToByteArray(pictureBox1.Image);

            var selectedNeuralNetwork = (ComboBoxItem)nnTypeComboBox.SelectedItem;

            if (selectedNeuralNetwork == null)
            {
                MessageBox.Show("Please select any neural network to recognize an image.");

                return;
            }

            textBox1.Text = recognitionAlgorithms[(NeuralNetworkType)selectedNeuralNetwork.Value].Recognize(image);
        }

        private byte[] ConvertImageToByteArray(Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            return ms.ToArray();
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
