using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using SharpAvi;
using SharpAvi.Codecs;
using SharpAvi.Output;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace Recorder
{
    public class RecorderParams
    {
        public RecorderParams(string filename, int FrameRate, FourCC Encoder, int Quality)
        {
            FileName = filename;
            FramesPerSecond = FrameRate;
            Codec = Encoder;
            this.Quality = Quality;
            //  Height = Screen.PrimaryScreen.Bounds.Height*2;
            //     Width = Screen.PrimaryScreen.Bounds.Width*2;
            ManagementObjectSearcher mydisplayResolution = new ManagementObjectSearcher("SELECT CurrentHorizontalResolution, CurrentVerticalResolution FROM Win32_VideoController");
            ManagementObjectCollection moc = mydisplayResolution.Get();
            foreach (ManagementObject record in moc)
            {
                int convertedHeight = Convert.ToInt32(record["CurrentVerticalResolution"]);
                int convertedWidth = Convert.ToInt32(record["CurrentHorizontalResolution"]);
                Height =  convertedHeight > 0 ? convertedHeight : Height;
                Width =  convertedWidth > 0 ? convertedWidth : Width;
            }

        }


        string FileName;
        public int FramesPerSecond, Quality;
        FourCC Codec;
        public int Height { get; private set; }
        public int Width { get; private set; }

        public AviWriter CreateAviWriter()
        {
            return new AviWriter(FileName)
            {
                FramesPerSecond = FramesPerSecond,
                EmitIndex1 = true,
            };
        }

        public IAviVideoStream CreateVideoStream(AviWriter writer)
        {
            if (Codec == KnownFourCCs.Codecs.Uncompressed)
                return writer.AddUncompressedVideoStream(Width, Height);
            else if (Codec == KnownFourCCs.Codecs.MotionJpeg)
                return writer.AddMotionJpegVideoStream(Width, Height, Quality);
            else
            {
                return writer.AddMpeg4VideoStream(Width, Height, (double)writer.FramesPerSecond,
                    quality: Quality,
                    codec: Codec,
                    forceSingleThreadedAccess: true);
            }
        }
    }

    public class Recorder : IDisposable
    {
        #region Fields
        AviWriter writer;
        RecorderParams Params;
        IAviVideoStream videoStream;
        Thread captureThread;
        Thread writerThread;
        ManualResetEvent stopThread = new ManualResetEvent(false);
        private BlockingCollection<byte[]> bufferQueue = new BlockingCollection<byte[]>();
        #endregion
        private bool isDisposed = false;

        public Recorder(RecorderParams Params)
        {
            this.Params = Params;
            writer = Params.CreateAviWriter();
            videoStream = Params.CreateVideoStream(writer);
            videoStream.Name = "Captura";
            captureThread = new Thread(CaptureScreen)
            {
                Name = typeof(Recorder).Name + ".CaptureScreen",
                IsBackground = true
            };
            writerThread = new Thread(WriteScreen)
            {
                IsBackground = true
            };
            writerThread.Start();
            captureThread.Start();
        }


        public void Dispose()
        {
            if (!isDisposed)
            {
                stopThread.Set();
                writerThread.Join();
                captureThread.Join();
                writer.Close();
                stopThread.Dispose();
            }
            isDisposed = true;
        }

        public void WriteScreen()
        {
            while (!bufferQueue.IsCompleted)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                // the code that you want to measure comes here
                var buffer = bufferQueue.Take();
                videoStream.WriteFrame(true, buffer, 0, buffer.Length);
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                System.Diagnostics.Debug.WriteLine(elapsedMs);
            }
        }
        void CaptureScreen()
        {
            var frameInterval = TimeSpan.FromSeconds(1 / (double)writer.FramesPerSecond);
            var timeTillNextFrame = TimeSpan.Zero;
            // the code that you want to measure comes here
            while (!stopThread.WaitOne(timeTillNextFrame))
            {
                var buffer = new byte[Params.Width * Params.Height * 4];
                var timestamp = DateTime.Now;
                Screenshot(buffer);
                bufferQueue.Add(buffer);
                timeTillNextFrame = timestamp + frameInterval - DateTime.Now;
                if (timeTillNextFrame < TimeSpan.Zero)
                    timeTillNextFrame = TimeSpan.Zero;
            }
            bufferQueue.CompleteAdding();

        }

        public void Screenshot(byte[] Buffer)
        {
            using (var BMP = new Bitmap(Params.Width, Params.Height))
            {
                using (var g = Graphics.FromImage(BMP))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, new Size(Params.Width, Params.Height), CopyPixelOperation.SourceCopy);
                    g.Flush();
                    var bits = BMP.LockBits(new Rectangle(0, 0, Params.Width, Params.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
                    Marshal.Copy(bits.Scan0, Buffer, 0, Buffer.Length);
                    BMP.UnlockBits(bits);
                }
            }
        }

    }
}
//zaimplementuj wzorzec producent konsument, przy pomocy kolekcji blokujacej
//producent to ten co produkuje nowe klatki do zapisu czyli ten co wywoluje metode Screenshot i dodaje je do kolekcji
//konsument to ten co pobiera nowe klatki i je koduje 
//po wszystkim uzyj klas stopwatch do zmierzenia wydajnosci (klatki na sekunde)