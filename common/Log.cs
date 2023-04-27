using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using gocqhttp_CSharp.Forms;

namespace gocqhttp_CSharp.common
{
    static class Log
    {
        static MainForm? outDomain;
        public static void SetOutDomain(MainForm form) => outDomain = form;
        public static void Info(string msg)
        {
            if (outDomain != null)
            {
                outDomain.UpdateText(
                    "<INFO> " +
                    System.DateTime.Now.ToString("HH:mm:ss | ") +
                    msg +
                    "\n");
            }
        }
        public static void Warn(string msg)
        {
            if (outDomain != null)
            {
                outDomain.UpdateText(
                    "<Warn> " +
                    System.DateTime.Now.ToString("HH:mm:ss | ") +
                    msg +
                    "\n");
            }
        }
        public static void Error(string msg)
        {
            if (outDomain != null)
            {
                outDomain.UpdateText(
                    "<ERROR> " +
                    System.DateTime.Now.ToString("HH:mm:ss") +
                    msg +
                    "\n");
            }
        }
    }
}
