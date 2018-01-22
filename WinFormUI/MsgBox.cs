using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WinFormUI
{
    public class MsgBox
    {
        private Form form;

        public MsgBox(Form form)
        {
            this.form = form;
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
