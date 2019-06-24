using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recorder
{
    public partial class Form1 : Form
    {
        public Recorder Rec { get; set; }
        public Form1()
        {
           
            InitializeComponent();
        }

        private void StartRecordingButton_Click(object sender, EventArgs e)
        {

            Rec = new Recorder(new RecorderParams("out.avi", 10, SharpAvi.KnownFourCCs.Codecs.MotionJpeg, 70));
            infoBox.Text = "Recording. Press Finish to stop recording.";
        }

        private void FinishRecordingButton_Click(object sender, EventArgs e)
        {
            
            Rec?.Dispose();
            infoBox.Text = "Recording stopped.";
        }
    }
}
