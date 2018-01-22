using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZKFPControlCS;

namespace WinFormUI
{
    [ComVisibleAttribute(true)]
    public partial class Finger : Form
    {
        const int MESSAGE_CAPTURED_OK = 0x0400 + 6;
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);


        IntPtr m_hDevice = IntPtr.Zero;
        IntPtr m_hDBCache = IntPtr.Zero;
        byte[] m_FpImage = null;
        byte[] m_fpTemplate;
        int m_cbFpImage;
        int m_cbfpTemplate;

        //int m_nF;
        //BSTR m_EnFpTem1;
        //BSTR m_EnFpTem2;

        //BSTR m_FpTemplate11;
        bool m_bInit;
        int m_Width;
        int m_Height;
        //LONG m_timeOut;
        bool m_bThreadStop;
        bool m_bCapture;
        //LONG m_lastTicks;
        IntPtr FingerHandle = IntPtr.Zero;

        byte[][] mRegFPTemps = new byte[3][];
        int[] mcbRegFPTemps = new int[3];


        public Finger()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }


        private void Init()
        {
            //打开设备
            //步骤1 Init
            //步骤2 GetDeviceCount()
            //步骤3 如果设备数>=1,才OpenDevice
            //步骤4 DBInit
            int nRet = zkfperrdef.ZKFP_ERR_OK;
            if (IntPtr.Zero != m_hDevice)
            {
                MessageBox.Show("设备已打开！");
                return;
            }

            if (!m_bInit)
            {
                if (nRet != ZKFPControl.Init())
                {
                    MessageBox.Show("初始化失败！");
                }
                m_bInit = true;
            }

            if (ZKFPControl.GetDeviceCount() <= 0)
            {
                MessageBox.Show("未找到设备！");
                return;
            }

            m_hDevice = ZKFPControl.OpenDevice(0);
            if (IntPtr.Zero == m_hDevice)
            {
                MessageBox.Show("设备打开失败！");
                return;
            }

            //byte[] paramValue = new byte[64];
            //int cbParamValue = 64;
            //byte[] HUNAMEFENGLIN = System.Text.Encoding.Default.GetBytes("HNFL2017");
            //if (0 == ZKFPControl.GetParameter(m_hDevice, 1104, paramValue, ref cbParamValue))
            //{
            //    if (!paramValue.SequenceEqual(HUNAMEFENGLIN))
            //    {
            //        //ZKFPControl.CloseDevice(m_hDevice);
            //       // m_hDevice = IntPtr.Zero;
            //        textBox.Text = "FwName != HNFL2017";

            //    }
            //}
            //byte[] paramValue1 = new byte[64];
            //int cbParamValue1 = 64;
            //if(0 == ZKFPControl.GetFwName(m_hDevice, paramValue1, cbParamValue1))
            //{
            //    MessageBox.Show(System.Text.Encoding.Default.GetString(paramValue1));
            //    //if (!paramValue1.SequenceEqual(HUNAMEFENGLIN))
            //    //{
            //    //    //ZKFPControl.CloseDevice(m_hDevice);
            //    //    //m_hDevice = IntPtr.Zero;
            //    //    MessageBox.Show("FwName != HNFL2017");

            //    //}
            //}
            m_hDBCache = ZKFPControl.DBInit();
            if (m_hDBCache == IntPtr.Zero)
            {
                MessageBox.Show("设备初始化失败！");
                return;
            }
            int size = 4;
            byte[] width = new byte[4];
            byte[] height = new byte[4];
            ZKFPControl.GetParameter(m_hDevice, 1, width, ref size);
            m_Width = BitConverter.ToInt32(width, 0);
            //m_Width =Convert .ToInt32( System.Text.Encoding.Default.GetString(width));
            size = 4;
            ZKFPControl.GetParameter(m_hDevice, 2, height, ref size);
            m_Height = BitConverter.ToInt32(height, 0);
            //m_Height =Convert .ToInt32( System.Text.Encoding.Default.GetString(width));

            m_FpImage = new byte[m_Width * m_Height];
            m_cbFpImage = m_Width * m_Height;
            m_fpTemplate = new byte[2048];
            m_bThreadStop = false;
            Thread captureThread = new Thread(new ThreadStart(DoCapture));
            captureThread.IsBackground = true;
            captureThread.Start();
            mRegFPTemps[0] = new byte[2048];
            mRegFPTemps[1] = new byte[2048];
            mRegFPTemps[2] = new byte[2048];
            m_bCapture = true;
        }
        private void DoCapture()
        {
            int nRet = zkfperrdef.ZKFP_ERR_OK;
            while (!m_bThreadStop)
            {
                if (m_bCapture)
                {
                    m_cbfpTemplate = 2048;
                    nRet = ZKFPControl.AcquireFingerprint(m_hDevice, m_FpImage, m_cbFpImage, m_fpTemplate, ref m_cbfpTemplate);
                    if (nRet == zkfperrdef.ZKFP_ERR_OK)
                    {
                        if (m_cbFpImage > 0 && m_cbfpTemplate > 0)
                        {
                            mRegFPTemps[0] = m_fpTemplate;
                            mcbRegFPTemps[0] = m_cbfpTemplate;
                            //int i= SendMessage(FingerHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                            this.setImage();
                        }
                    }
                }
                Thread.Sleep(200);
            }
        }

        private delegate void setImageDelegate();
        private void setImage()
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new setImageDelegate(setImage));
            else
            {
                MemoryStream msFP = new MemoryStream();
                BitmapFormat.GetBitmap(m_FpImage, m_Width, m_Height, ref msFP);

                Bitmap bmpfp = new Bitmap(msFP);
                this.pictureBox.Image = bmpfp;
            }
        }


        //private void button2_Click(object sender, EventArgs e)
        //{
        //    //开始采集
        //    m_bCapture = true;
        //}

        //private void  button3_Click(object sender, EventArgs e)
        //{
        //    //图片原始数据转JPG格式
        //    byte[] jpg = new byte[m_Width * m_Height];
        //    int nRet = ZKFPControl.BmpToJpg(m_FpImage, m_Width, m_Height, jpg);
        //    if (nRet <= 0)
        //    {
        //    }
        //    else
        //    {
        //        string img = Convert.ToBase64String(jpg);
        //        //textBox.Text = "保存成功";
        //    }
        //    FileStream fs = new FileStream("d:\\finger.jpg", FileMode.Create, FileAccess.Write);
        //    fs.Write(jpg, 0, jpg.Length);
        //    fs.Close();
            
        //    //return img;
        //}

        private void  button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public string Save()
        {
            Image img = this.pictureBox.Image;
            Bitmap bmp = new Bitmap(img);
            MemoryStream ms1 = new MemoryStream();
            bmp.Save(ms1, ImageFormat.Jpeg);
            byte[] arr1 = new byte[ms1.Length];
            ms1.Position = 0;
            ms1.Read(arr1, 0, (int)ms1.Length);
            ms1.Close();
            string img64 = Convert.ToBase64String(arr1);
            return img64;
        }

        private void Finger_Load(object sender, EventArgs e)
        {
            FingerHandle = this.Handle;
            Init();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
