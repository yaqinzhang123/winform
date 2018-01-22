using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinFormUI
{
    public delegate void ReadFingerDelegate(string img);
    public class FingerReader
    {
        private Form form;
        public ReadFingerDelegate ReadFingerComplete;
        public FingerReader(Form form)
        {
            this.form = form;
        }
        public string Read()
        {
            Finger finger = new Finger();
            string img = string.Empty;
            try
            {
                //finger.ShowDialog();
                if (finger.ShowDialog() == DialogResult.OK)
                {
                    img = finger.Save();
                }
                finger.Dispose();
                return img;  
            }catch(Exception e)
            {
                //MessageBox.Show(e.ToString());
                return img;
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
