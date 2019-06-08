using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace FaceRecognition.BL
{
	public abstract class NeuaralNetworkStrategy
	{
		protected abstract string ScriptFilePath { get; }

		public Task Train(string dataSourcePath, bool isCsv, bool isImageFolder, string outputModelPath, Action<string> outputWriter)
		{
			string pythonPath = GetPythonExeFullPath();
			string nnFilePath = this.GetNNScriptFullPath();
			string dataSourceType = "";
			if (isCsv)
			{
				dataSourceType = "csv";
			}

			if (isImageFolder)
			{
				dataSourceType = "directory";
			}

			string cmd = $"\"{pythonPath}\" \"{nnFilePath}\" \"{dataSourcePath}\" {dataSourceType} \"{outputModelPath}\"";

			return ExecuteCmdAsync(
				input =>
				{
					// ---- OPTION 1: virtualenv ----
					//var currentDir = AppDomain.CurrentDomain.BaseDirectory;
					//string drive = currentDir[0].ToString();
					//input.WriteLine($"{drive}:");
					//input.WriteLine($"cd {GetFullPath(@"EmoPy-master\venv1\Scripts")}");
					//input.WriteLine($"activate");
					//input.WriteLine($"python {pathToFermodelExample}");
					//input.WriteLine($"deactivate");

					// ---- OPTION 2: global packages ----
					input.WriteLine(cmd);
				},
				outputWriter);
		}

		public Task Recognize(string trainedModelPath, string imagePath, string emotionsSubset, Action<string> outputWriter)
		{
			string pythonPath = GetPythonExeFullPath();
			string pathToFermodelExample = GetFermodelExampleFullPath();

			string cmd = $"\"{pythonPath}\" \"{pathToFermodelExample}\" \"{trainedModelPath}\" \"{imagePath}\" \"{emotionsSubset}\"";

			return ExecuteCmdAsync(
				input =>
				{
					// ---- OPTION 1: virtualenv ----
					//var currentDir = AppDomain.CurrentDomain.BaseDirectory;
					//string drive = currentDir[0].ToString();
					//input.WriteLine($"{drive}:");
					//input.WriteLine($"cd {GetFullPath(@"EmoPy-master\venv1\Scripts")}");
					//input.WriteLine($"activate");
					//input.WriteLine($"python {pathToFermodelExample}");
					//input.WriteLine($"deactivate");

					// ---- OPTION 2: global packages ----
					input.WriteLine(cmd);
				},
				outputWriter);
		}

		public Task ExecuteCmdAsync(Action<StreamWriter> inputWriter, Action<string> outputWriter)
		{
			return Task.Run(() =>
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

				inputWriter(p.StandardInput);

				p.StandardInput.Flush();
				p.StandardInput.Close();

				p.WaitForExit();
			});
		}

		public string GetPythonExeFullPath()
		{
			return Environment.GetEnvironmentVariable("PYTHON_PATH") ?? "[ENV VARIABLE NOT SPECIFIED]"; // return "python";
		}

		public string GetEmoPyExamplesFolderFullPath()
		{
			return Path.Combine(Environment.GetEnvironmentVariable("EMOPY_PATH") ?? "[ENV VARIABLE NOT SPECIFIED]", "examples"); // GetFullPath(@"\EmoPy -master\EmoPy\examples\");
		}

		private string GetFermodelExampleFullPath()
		{
			return Path.Combine(GetEmoPyExamplesFolderFullPath(), "fermodel_example.py");
		}

		private string GetNNScriptFullPath()
		{
			return Path.Combine(GetEmoPyExamplesFolderFullPath(), this.ScriptFilePath.TrimStart('\\', '/'));
		}

		//private static string GetFullPath(string relativePath)
		//{
		//	return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath.TrimStart('\\', '/'));
		//}
	}
}
