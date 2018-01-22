using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinFormUI
{
    [ComVisible(true)]
    public partial class Form1 : Form
    {
        private WebView wv;
        private SignPad signPad;
        private SignPad2 signPad1;
        private static IDCardAPI idCard = new IDCardAPI();
        private ICard iCardForm;
        private Finger finger;
        public Form1()
        {
            InitializeComponent();
            this.signPad = new SignPad();
            this.signPad1 = new SignPad2();
            this.iCardForm = new ICard();
            this.finger = new Finger();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.wv = new WebView();
            //this.wv.Address = Application.StartupPath + "\\test.html";
            this.wv.Address="http://dysoft.bclzdd.com";
            this.wv.Parent = this;
            this.wv.Dock = DockStyle.Fill;
            this.wv.LoadCompleted += Wv_LoadCompleted;
            this.wv.RegisterJsObject("MsgBox", new MsgBox(this));
            this.wv.RegisterJsObject("ICardReader", new ICardReader(this));
            this.wv.RegisterJsObject("FingerReader", new FingerReader(this));
            this.wv.RegisterJsObject("SignReader", new SignReader(this));
            this.signPad1.Show();
            this.signPad1.Refresh();
        }

        private void Wv_LoadCompleted(object sender, CefSharp.LoadCompletedEventArgs url)
        {
            WebView view = (WebView)sender;
            this.setTitle(view.Title);
        }

        private delegate void setTitleDelegate(string title);
        private void setTitle(string title)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new setTitleDelegate(setTitle), title);
            else
                this.Text = title;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("真的要退出吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.signPad.axHWPenSign1.Visible = true;
            this.signPad.tableLayoutPanel2.Visible = true;
        }

        //身份证读取
        private void button2_Click(object sender, EventArgs e)
        {
            //this.iCardForm.Show();
            //this.iCardForm.Refresh();
            int i = idCard.InitDevice();
            Thread.Sleep(5000);
            string str = idCard.ReadICCard(i).ToString();
            MessageBox.Show(str);
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    this.finger = new Finger();
        //    this.finger.Show();
        //    this.finger.Refresh();
        //}
    }
}
