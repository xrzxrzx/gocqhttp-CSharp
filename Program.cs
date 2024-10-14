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
            //��ʼ��
            Gocqhttp.Init(Init);
            Application.Run(mainForm);
        }
        public static void Init()
        {
            try
            {
                // ע��һ�����ܻ���������ʼ��д������
            }
            catch (FunctionIsRegisteredException ex)
            {
                TextLog.Warn($"���ܣ���{ex.Message}���޷�ע�ᣬ��Ϊ�ù���������Ӧ������ע��");
            }
        }
    }
}