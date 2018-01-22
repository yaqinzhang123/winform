using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class SignPad2 : Form
    {
        public SignPad2()
        {
            InitializeComponent();
        }

        private void SignPad2_Load(object sender, EventArgs e)
        {
            if (Screen.AllScreens.Length > 1)
            {
                this.Location = new Point(Screen.PrimaryScreen.Bounds.Width + 1, 0);
                this.WindowState = FormWindowState.Maximized;
            }
        }

        //private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    if (webBrowser1.Document != null
        //        && webBrowser1.Document.Encoding == "gb2312"
        //        && webBrowser1.Document.Url.AbsoluteUri.StartsWith("http://219.139.106.6:8888/"))
        //    {
        //        webBrowser1.Document.Encoding = "UTF-8";
        //        webBrowser1.Refresh();
        //    }
        //}
        
    }
}
