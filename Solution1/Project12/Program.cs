using System;
using System.Windows.Forms;
using Project10.Views;
using Project10.DataLayer;
using System.IO;
namespace Project10
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (File.Exists(ObjectPlus.STORE_PATH))
            {
                ObjectPlus.Deserialize();
            }
            else
            {
                PopulateDB.Populate();
            }
            Application.ApplicationExit += (s, e) => ObjectPlus.Serialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}