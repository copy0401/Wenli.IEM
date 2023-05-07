using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Wenli.IEM.Helper;

namespace Wenli.IEM
{
    public partial class WordBoard : CCWin.Skin_Mac
    {

        public WordBoard()
        {
            InitializeComponent();
 
        }

        private void WordBoard_Load(object sender, EventArgs e)
        {
            Program.keyBordHook.KeyUpEvent += KeyBordHook_KeyUpEvent;
            Program.keyBordHook.OnSpaced += KeyBordHook_OnSpaced;
            Program.keyBordHook.OnBacked += KeyBordHook_OnBacked;
            Program.keyBordHook.OnPaged += KeyBordHook_OnPaged;

            int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            this.Location = new Point(x, y);
        }



        string keys = "";

        private void KeyBordHook_KeyUpEvent(object sender, KeyEventArgs e)
        {
            keys += e.KeyCode.ToString().ToLower();
            this.ShowCharatar();
        }
        
        private void KeyBordHook_OnSpaced(int choose)
        {
            try
            {
                if (CacheHelper.ContainsKey(keys))
                {
                     if (choose > 0)
                    {
                        choose = choose - 1;
                    }

                    Program.keyBordHook.Send(CacheHelper.Get(keys)[choose]);
                    label1.Text = "";
                    this.listView1.Clear();
                }
            }
            catch
            {

            }
            keys = "";
        }

        private void KeyBordHook_OnBacked()
        {
            if (!string.IsNullOrEmpty(keys))
            {
                keys = keys.Substring(0, keys.Length - 1);
            }
            this.ShowCharatar();
        }


        int pageIndex = 1;
        private void KeyBordHook_OnPaged(int obj)
        {
            pageIndex = pageIndex + obj;
            if (pageIndex < 1)
                pageIndex = 1;
            ShowCharatar();

        }


        private void ShowCharatar()
        {
            this.listView1.BeginInvoke(new Action(() =>
            {
                label1.Text = keys.ToUpper();


                try
                {
                    //this.BackColor = Color.White;
                    var arr = CacheHelper.Get(keys).ToList().Skip((pageIndex - 1) * 9).Take(9).ToArray();
                    if (arr != null && arr.Any())
                    {
                        this.listView1.Items.Clear();
                        for (int i = 0; i < arr.Count(); i++)
                        {
                            //this.listView1.Items.Add((i + 1) + "、" + arr[i]);
                            this.listView1.Items.Add((i) + "、" + arr[i]);
                        }
                    }
                    else
                        pageIndex--;

                }
                catch
                {
                    //當 空碼 時
                    //label1.Text = keys = "";

                    //當 組字長度為 5 空碼 時
                    if (label1.Text.Length == 5)
                    {
                        label1.Text = keys = "";
                    }
                }
            }));
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            this.Location = new Point(x, y);
            this.Show();
        }
    }
}
