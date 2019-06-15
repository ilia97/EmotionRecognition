using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Threading;
using System.Threading.Tasks;

namespace FaceRecognition.BL
{
	public abstract class NeuaralNetworkStrategy
	{
		protected abstract string ScriptFilePath { get; }

		public Task Train(string dataSourcePath, bool isCsv, bool isImageFolder, string outputModelPath, Action<string> outputWriter, CancellationToken token)
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
					//input.WriteLine($"python {GetFullPath(@"EmoPy-master\EmoPy\examples\fermodel_example.py")}");
					//input.WriteLine(cmd);
					//input.WriteLine($"deactivate");

					// ---- OPTION 2: global packages ----
					input.WriteLine(cmd);
				},
				outputWriter,
				token);
		}

		public static Task Recognize(string trainedModelPath, string imagePath, string emotionsSubset, Action<string> outputWriter, CancellationToken token)
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
					//input.WriteLine($"python {GetFullPath(@"EmoPy-master\EmoPy\examples\fermodel_example.py")}");
					//input.WriteLine($"deactivate");

					// ---- OPTION 2: global packages ----
					input.WriteLine(cmd);
				},
				outputWriter,
				token);
		}

		public static Task ExecuteCmdAsync(Action<StreamWriter> inputWriter, Action<string> outputWriter, CancellationToken token)
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

				while (!p.HasExited)
				{
					if (token.IsCancellationRequested)
					{
						if (!p.HasExited)
						{
							KillProcessTree(p.Id);

							token.ThrowIfCancellationRequested();
						}
					}
				}
			});
		}

		public static string GetPythonExeFullPath()
		{
			return Path.Combine(Environment.GetEnvironmentVariable("EMOPY_PYTHON_PATH") ?? "[ENV VARIABLE NOT SPECIFIED]", "python.exe");
			// return "python";
		}

		public static string GetEmoPyExamplesFolderFullPath()
		{
			return Path.Combine(Environment.GetEnvironmentVariable("EMOPY_PATH") ?? "[ENV VARIABLE NOT SPECIFIED]", "examples");
			// return GetFullPath(@"\EmoPy-master\EmoPy\examples\");
		}

		private static string GetFermodelExampleFullPath()
		{
			return Path.Combine(GetEmoPyExamplesFolderFullPath(), "fermodel_example.py");
		}

		private string GetNNScriptFullPath()
		{
			return Path.Combine(GetEmoPyExamplesFolderFullPath(), this.ScriptFilePath.TrimStart('\\', '/'));
		}

		// private static string GetFullPath(string relativePath)
		// {
		// 	return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath.TrimStart('\\', '/'));
		// }

		private static void KillProcessTree(int pid)
		{
			// Cannot close 'system idle process'.
			if (pid == 0)
			{
				return;
			}

			ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + pid);
			ManagementObjectCollection moc = searcher.Get();
			foreach (ManagementObject mo in moc)
			{
				KillProcessTree(Convert.ToInt32(mo["ProcessID"]));
			}
			try
			{
				Process proc = Process.GetProcessById(pid);
				proc.Kill();
			}
			catch (ArgumentException)
			{
				// Process already exited.
			}
		}
	}
}
