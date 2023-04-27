using gocqhttp_CSharp.common;
using gocqhttp_CSharp.Forms;
using gocqhttp_CSharp.gocqhttp;

namespace gocqhttp_CSharp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            MainForm mainForm = new MainForm();
            Log.SetOutDomain(mainForm);
            Application.Run(mainForm);
        }
    }
}