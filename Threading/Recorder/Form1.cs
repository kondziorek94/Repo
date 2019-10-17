using System;
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
            Rec = new Recorder(new RecorderParams("out.avi", 30, SharpAvi.KnownFourCCs.Codecs.Xvid, 70));
            infoBox.Text = "Recording. Press Finish to stop recording.";
        }

        private void FinishRecordingButton_Click(object sender, EventArgs e)
        {
            Rec?.Dispose();
            infoBox.Text = "Recording stopped.";
        }
    }
}