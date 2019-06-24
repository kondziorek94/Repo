using System;
using System.Windows.Forms;
using Recorder;

namespace Recorder
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //var rec = new Recorder(new RecorderParams("out.avi", 10, SharpAvi.KnownFourCCs.Codecs.MotionJpeg, 70));

            //Console.WriteLine("Press any key to Stop...");
            //Console.ReadKey();

            //// Finish Writing
            //rec.Dispose();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}
