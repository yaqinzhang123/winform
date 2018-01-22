using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WinFormUI
{
    public class SignReader
    {
        private Form form;

        public SignReader(Form form)
        {
            this.form = form;
        }
        public string Read()
        {
            SignPad sign = new SignPad();
            string imgPath = string.Empty;
            try
            {
                if (sign.ShowDialog() == DialogResult.OK)
                {
                   imgPath = sign.Save();
                }
                //sign.Dispose();
                return imgPath;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return imgPath;
            }
        }
        public void Show(string msg)
        {
            MessageBox.Show(msg);
        }
        public void CloseWindow()
        {
            Application.Exit();
        }
    }
}
