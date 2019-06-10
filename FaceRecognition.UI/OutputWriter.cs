using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FaceRecognition.UI
{
	public class OutputWriter : IDisposable
	{
		private TextBoxBase outputTarget;
		private object syncRoot;
		private Timer timer;
		private List<string> outputQueue;

		private static Regex CmdFilter = new Regex(@"\w:\\.*>", RegexOptions.Compiled);
		private bool disposed;

		public OutputWriter(TextBoxBase outputTarget)
		{
			this.outputTarget = outputTarget;

			this.syncRoot = new object();

			this.outputQueue = new List<string>();

			this.timer = new Timer();
			this.timer.Interval = 1000;
			this.timer.Tick += WriteFunc; // Is colled on UI thread since timer is instance of System.Windows.Forms.Timer class
			this.timer.Start();
		}

		public void AddLine(string line)
		{
			lock (this.syncRoot)
			{
				if (!string.IsNullOrEmpty(line) && !CmdFilter.IsMatch(line))
				{
					this.outputQueue.Add(line);
				}
			}
		}

		public void Clear()
		{
			this.outputTarget.Text = "";
		}

		private void WriteFunc(object objectInfo, EventArgs e)
		{
			string text = string.Empty;

			lock (this.syncRoot)
			{
				text = string.Join("\n", this.outputQueue);
				this.outputQueue.Clear();
			}

			if (!string.IsNullOrEmpty(text))
			{
				this.outputTarget.AppendText($"{text}\n");
			}
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (this.disposed)
			{
				return;
			}

			if (disposing)
			{
				if (this.timer != null)
				{
					this.timer.Stop();
					this.timer.Dispose();
				}
			}

			this.disposed = true;
		}
	}
}
