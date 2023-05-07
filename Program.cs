using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Wenli.IEM.Win32;
using Wenli.IEM.Helper;
using System.IO;

namespace Wenli.IEM
{
    static class Program
    {
        public static KeyboardHook keyBordHook = new KeyboardHook();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string path = Application.StartupPath + "\\Win32\\pinyin.dll";
            bool fileExist = File.Exists(path);

            string path2 = Application.StartupPath + "\\汉字拼音对照表.txt";
            bool fileExist2 = File.Exists(path2);

            
            if (fileExist)
            {
                //MessageBox.Show("pinyin.dll File exists.");
            }
            else
            {

                if (fileExist2)
                {
    
                    MessageBox.Show("將由 " + Application.StartupPath + "\\汉字拼音对照表.txt" + " 產生 " + Application.StartupPath + "\\win32\\pinyin.dll");
                    Wenli.IEM.Helper.Generate.GenerateFile();
                }

            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            keyBordHook.Start();
            Application.Run(new WordBoard());
            keyBordHook.Stop();
        }        
    }
}
