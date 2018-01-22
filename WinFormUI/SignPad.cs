using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class SignPad : Form
    {
        public object NewPath;
        public SignPad()
        {
            InitializeComponent();        }

        private void SignPad_Load(object sender, EventArgs e)
        {
            if(Screen.AllScreens.Length>1)
            {
                this.Location = new Point(Screen.PrimaryScreen.Bounds.Width + 1, 0);
                this.WindowState = FormWindowState.Maximized;
            }
            this.axHWPenSign1.HWInitC();
            this.axHWPenSign1.HWMouseEnable(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.axHWPenSign1.HWClearPenSign();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.axHWPenSign1.HWSwitchMonitor(0, 0);
           // this.axHWPenSign1.HWCloseC();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = System.Environment.CurrentDirectory + @"\sign\";
            //path=path.Replace(@"\\",@"\");
            //string path = HttpContext.Current.Server.MapPath("/sign/");
            string imgName = DateTime.Now.ToString("yyyyMMddhhmmss") + ".png";
            NewPath = path + imgName;
            int state = axHWPenSign1.HWIsNeedSave();
            if (state == 1)
                axHWPenSign1.HWSaveFile(NewPath);
            //this.tableLayoutPanel1.Visible = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public string Save()
        {
            return NewPath.ToString();
        }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
