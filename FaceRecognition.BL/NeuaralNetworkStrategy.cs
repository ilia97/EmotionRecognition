using FaceRecognition.Models.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace FaceRecognition.BL
{
	public abstract class NeuaralNetworkStrategy
	{
		private static string pathToExamplesFolder = @"\EmoPy-master\EmoPy\examples\";
		private static string pathToFermodelExample = GetFullPath(Path.Combine(pathToExamplesFolder, "fermodel_example.py"));
		private readonly Dictionary<NeuralNetworkType, string> recognitionAlgorithmsExecutables = new Dictionary<NeuralNetworkType, string>
		{
			[NeuralNetworkType.Convolutional] = GetFullPath(Path.Combine(pathToExamplesFolder, "convolutional_model.py")),
			[NeuralNetworkType.TimeDelayConv] = GetFullPath(Path.Combine(pathToExamplesFolder, "timedelay_conv_model.py")),
			[NeuralNetworkType.ConvolutionalLstm] = GetFullPath(Path.Combine(pathToExamplesFolder, "convolutional_lstm_model.py")),
			[NeuralNetworkType.TransferLearning] = GetFullPath(Path.Combine(pathToExamplesFolder, "transferlearning_model.py"))
		};


		public async Task Train(string dataSourcePath, bool isCsv, bool isImageFolder, string outputModelPath, Action<string> outputWriter)
		{
			await Task.Run(() =>
			{
				var p = new Process();
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.RedirectStandardOutput = true;
				p.StartInfo.RedirectStandardError = true;
				p.OutputDataReceived += (sender, args) => outputWriter(args.Data);
				p.ErrorDataReceived += (sender, args) => outputWriter(args.Data);
				p.StartInfo.RedirectStandardInput = true;
				p.StartInfo.FileName = "cmd.exe";
				p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				p.StartInfo.CreateNoWindow = true;

				p.Start();

				p.BeginOutputReadLine();
				p.BeginErrorReadLine();

				var currentDir = AppDomain.CurrentDomain.BaseDirectory;
				string drive = currentDir[0].ToString();
				p.StandardInput.WriteLine($"{drive}:");

				p.StandardInput.WriteLine($"cd {GetFullPath(@"EmoPy-master\venv1\Scripts")}");

				p.StandardInput.WriteLine($"activate");

				// Execution of pythin script. Put your code here
				p.StandardInput.WriteLine($"python {pathToFermodelExample}");

				p.StandardInput.WriteLine($"deactivate");

				p.StandardInput.Flush();
				p.StandardInput.Close();

				p.WaitForExit();
			});
		}

		public async Task Recognize(string trainedModelPath, string imagePath, string emotionsSubset, Action<string> outputWriter)
		{
			await Task.Run(() =>
			{
				var p = new Process();
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.RedirectStandardOutput = true;
				p.StartInfo.RedirectStandardError = true;
				p.OutputDataReceived += (sender, args) => outputWriter(args.Data);
				p.ErrorDataReceived += (sender, args) => outputWriter(args.Data);
				p.StartInfo.RedirectStandardInput = true;
				p.StartInfo.FileName = "cmd.exe";
				p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				p.StartInfo.CreateNoWindow = true;

				p.Start();

				p.BeginOutputReadLine();
				p.BeginErrorReadLine();

				var currentDir = AppDomain.CurrentDomain.BaseDirectory;
				string drive = currentDir[0].ToString();
				p.StandardInput.WriteLine($"{drive}:");

				p.StandardInput.WriteLine($"cd {GetFullPath(@"EmoPy-master\venv1\Scripts")}");

				p.StandardInput.WriteLine($"activate");

				// Execution of pythin script. Put your code here
				p.StandardInput.WriteLine($"python {pathToFermodelExample}");

				p.StandardInput.WriteLine($"deactivate");

				p.StandardInput.Flush();
				p.StandardInput.Close();

				p.WaitForExit();
			});
		}

		private static string GetFullPath(string relativePath)
		{
			return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath.TrimStart('\\', '/'));
		}
	}
}
