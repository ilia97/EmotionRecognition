using FaceRecognition.BL.Interfaces;
using IronPython.Hosting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FaceRecognition.BL
{
    public abstract class NeuaralNetworkStrategy : INeuralNetworkStrategy
    {
        private const string imageName = "C:\\Program Files\\Python36\\Lib\\site-packages\\EmoPy\\examples\\image_data\\image.png";

        public string Recognize(byte[] image)
        {
            this.SaveImage(image);

            var p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "fermodel_example.cmd";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            p.WaitForExit();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();

            output = output.Substring(output.IndexOf("Initializing"));

            return output;
        }

        private void SaveImage(byte[] bytes)
        {
            if (File.Exists(imageName))
            {
                File.Delete(imageName);
            }

            var stream = new MemoryStream(bytes);

            var image = Image.FromStream(stream);

            image.Save(imageName, ImageFormat.Png);
        }
    }
}
