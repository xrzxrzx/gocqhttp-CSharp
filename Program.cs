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
            TextLog.SetOutDomain(mainForm);
            //初始化
            Gocqhttp.Init(Init);
            Application.Run(mainForm);
        }
        public static void Init()
        {
            try
            {
                // 注册一个功能或做其他初始化写在这里
            }
            catch (FunctionIsRegisteredException ex)
            {
                TextLog.Warn($"功能：“{ex.Message}”无法注册，因为该功能名或响应条件已注册");
            }
        }
    }
}