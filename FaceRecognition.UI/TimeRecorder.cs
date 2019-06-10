using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognition.UI
{
	public class TimeRecorder
	{
		private const int intervalSeconds = 1;

		private long elaspsedTime = 0;
		private Label timeControl;
		private Timer timer;

		public TimeRecorder(Label timeControl)
		{
			this.timeControl = timeControl;

			this.timer = new Timer();
			this.timer.Interval = intervalSeconds * 1000;
			this.timer.Tick += WriteFunc; // Is colled on UI thread since timer is instance of System.Windows.Forms.Timer class
		}

		public void Start()
		{
			this.elaspsedTime = 0;
			this.DisplayElapsedTime();
			this.timer.Start();
		}

		public void Stop()
		{
			this.timer.Stop();
		}

		private void WriteFunc(object objectInfo, EventArgs e)
		{
			this.elaspsedTime += intervalSeconds;
			this.DisplayElapsedTime();
		}

		private void DisplayElapsedTime()
		{
			var time = TimeSpan.FromSeconds((double)this.elaspsedTime);
			this.timeControl.Text = $"{time.Hours:00}:{time.Minutes:00}:{time.Seconds:00}";
		}
	}
}
