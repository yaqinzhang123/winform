using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinFormUI
{
    public class ICardReader
    {
        private Form form;

        private static IDCardAPI idCard = new IDCardAPI();

        public ICardReader(Form form)
        {
            this.form = form;
        }
        public string Read()
        {
            try
            {
                int i = idCard.InitDevice();
                if (i==1001)
                {
                    try
                    {
                        EDZ obj = idCard.ReadICCard(i);
                        string str = JsonConvert.SerializeObject(obj);
                        MessageBox.Show("读取成功"+str);
                        return str;
                    }
                    catch
                    {
                        MessageBox.Show("未放卡或卡未放好！请重新放卡！");
                        return "";
                    }
                }
                MessageBox.Show("设备初始化未成功！请检查设备连接状态！");
                return "";
            }
            catch (Exception e)
            {
                MessageBox.Show("设备初始化未成功！请检查设备连接状态！");
                return "";
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
