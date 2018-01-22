using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class ICard : Form
    {
        [DllImport("cminfo.dll")]
        public static extern int GetBmp(string file_name, int intf);

        public ICard()
        {
            InitializeComponent();
        }

        private void ICard_Load(object sender, EventArgs e)
        {
            idCard.ReadICCardComplete += new IDCardAPI.De_ReadICCardComplete(idCard_ReadICCardComplete);
        }
        
        void idCard_ReadICCardComplete(EDZ objEDZ)
        {

            txtName.Text = objEDZ.Name;
            this.txtNo.Text = objEDZ.IDC;
            this.txtAdd.Text = objEDZ.ADDRESS;
            txtFolk.Text = objEDZ.NATION_CName;
            txtSign.Text = objEDZ.REGORG;
            txtYearMonth.Text = objEDZ.BIRTH.ToLongDateString();
            //MemoryStream ms = new MemoryStream(objEDZ.PIC_Byte);
            //Image img = Image.FromStream(ms);
            //pictureBox1.Image = objEDZ.PIC_Image;
            MessageBox.Show(objEDZ.ToString());
        }

        private void ClearData()
        {
            txtName.Text = "";
            this.txtNo.Text = "";
            this.txtAdd.Text = "";
            txtFolk.Text = ""; ;
            txtSign.Text = "";
            txtYearMonth.Text = "";
            lblMsg.Text = "";

        }
        private IDCardAPI idCard = new IDCardAPI();
        private int iPort;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                int r = IDCardAPI.SDT_OpenPort(int.Parse(txtOpenPort.Text));
                if (r == 144)
                {
                    iPort = int.Parse(txtOpenPort.Text);
                    MessageBox.Show("打开设备成功");


                }
                else
                {
                    MessageBox.Show("打开设备失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private int iPort=1001;
        private void btnGetSamStr_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] samstr = new byte[32];
                int r = IDCardAPI.SDT_GetSAMIDToStr(iPort, samstr, 1);
                if (r == 144)
                {


                    txtSamStr.Text = Encoding.ASCII.GetString(samstr);

                }
                else
                {
                    txtSamStr.Text = "获取模块号码失败";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            try
            {
                iPort = idCard.InitDevice();
                this.txtInit.Text = iPort.ToString();
                //IDCardAPI.SDT_SetMaxRFByte(iPort, 36, 1);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                int pucIIN = 0;

                int rtnTemp;
                rtnTemp = IDCardAPI.SDT_StartFindIDCard(iPort, ref pucIIN, 1);  //再找卡
                if (rtnTemp != 159)
                {
                    // rtnTemp = SDT_ClosePort(EdziPortID);
                    txtFind.Text = "未放卡或者卡未放好，请重新放卡！";

                }
                else
                {
                    txtFind.Text = "找卡成功！";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                ClearData();
                //int r = IDCardAPI.SDT_SetMaxRFByte(1001, (byte)int.Parse(cmbValue.Text), 1);

                idCard.ReadICCard(int.Parse(txtport.Text));
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }


        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                int rtnTemp;
                int pucSN = 0;
                rtnTemp = IDCardAPI.SDT_SelectIDCard(iPort, ref pucSN, 1);  //再选卡
                if (rtnTemp != 144)
                {
                    //rtnTemp = SDT_ClosePort(EdziPortID);
                    txtSelect.Text = "读卡失败！";

                }
                else
                {
                    txtSelect.Text = "选卡成功";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Now;
                int puiCHMsgLen = 0;
                int puiPHMsgLen = 0;
                byte[] baseMsg = new byte[256];
                byte[] pic = new byte[1024];
                int rtnTemp;
                rtnTemp = IDCardAPI.SDT_ReadBaseMsg(iPort, baseMsg, ref puiCHMsgLen, pic, ref puiPHMsgLen, 1);
                if (rtnTemp != 144)
                {
                    txtRead.Text = "读卡失败！";

                }
                else
                {
                    string s = UnicodeEncoding.Unicode.GetString(baseMsg);
                    txtRead.Text = "读卡成功!" + s;
                }
                DateTime dt1 = DateTime.Now;
                MessageBox.Show(dt.Second.ToString() + " " + dt.Millisecond.ToString() + "   " + dt1.Second.ToString() + " " + dt1.Millisecond.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetStatus_Click(object sender, EventArgs e)
        {
            try
            {
                int r = IDCardAPI.SDT_GetSAMStatus(iPort, 1);
                txtStatus.Text = r.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            try
            {
                int r = IDCardAPI.SDT_ResetSAM(iPort, 1);
                if (r == 144)
                {
                    txtReset.Text = "重置成功";

                }
                else
                {
                    txtReset.Text = "重置失败";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnSetMF_Click(object sender, EventArgs e)
        {

            try
            {
                int i = IDCardAPI.SDT_SetMaxRFByte(iPort, 36, 1);
                if (i == 144)
                {
                    txtMFbyte.Text = "设置成功";
                }
                else
                {
                    txtMFbyte.Text = "设置失败";

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                int i = IDCardAPI.SDT_ClosePort(iPort);
                if (i == 144)
                {
                    this.txtClose.Text = "关闭设备成功";
                }
                else
                {
                    txtMFbyte.Text = "关闭设备失败";

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnInitDevice_Click(object sender, EventArgs e)
        {

            try
            {
                iPort = idCard.InitDevice();
                txtport.Text = iPort.ToString();
                IDCardAPI.SDT_SetMaxRFByte(iPort, 36, 1);


            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;

            }


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            IDCardAPI.SDT_ClosePort(iPort);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //byte[] data = { 0x00, 0x03, 0x06, 0x01 };

            //byte b = GetChekSum(data);
            int i = IDCardAPI.SDT_SetCOMBaud(3, 9600, 9600);
        }

        private byte GetChekSum(byte[] b)
        {
            byte r;
            r = b[0];
            for (int i = 1; i < b.Length; i++)
            {
                r ^= b[i];
            }
            return r;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            //MessageBox.Show(objEDZ.ToString());
        }

        private void btnInitDevice_Click_1(object sender, EventArgs e)
        {

            try
            {
                iPort = idCard.InitDevice();
                txtport.Text = iPort.ToString();
                IDCardAPI.SDT_SetMaxRFByte(iPort, 36, 1);


            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;

            }
        }

        private void btnRead_Click_1(object sender, EventArgs e)
        {
            try
            {
                ClearData();
                //int r = IDCardAPI.SDT_SetMaxRFByte(1001, (byte)int.Parse(cmbValue.Text), 1);

                idCard.ReadICCard(int.Parse(txtport.Text));
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int rtnTemp;
            if (false)
                rtnTemp = GetBmp("zp.wlt", 2);
            else
                rtnTemp = GetBmp("zp.wlt", 1);


            //string i = IDCardAPI.ReadIDInfo(3);
            //MessageBox.Show(i.ToString());
        }
    }
    
}
