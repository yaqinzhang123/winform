using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text;

namespace WinFormUI
{
    public class IDCardAPI
    {
        //首先，声明通用接口


        [DllImport("sdtapi.dll")]
        public static extern int SDT_ClosePort(int iPortID);

        [DllImport("sdtapi.dll")]
        public static extern int SDT_GetCOMBaud();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iPortID"></param>
        /// <param name="StrSAMID">16个字节</param>
        /// <param name="iIfOpen"></param>
        /// <returns></returns>
        [DllImport("sdtapi.dll")]

        public static extern int SDT_GetSAMID(int iPortID, byte[] StrSAMID, int iIfOpen);

        [DllImport("sdtapi.dll")]
        public static extern int SDT_GetSAMIDToStr(int iPortID, byte[] pcSAMID, int iIfOpen);

        [DllImport("sdtapi.dll")]
        public static extern int SDT_GetSAMStatus(int iPortID, int iIfOpen);

        [DllImport("sdtapi.dll")]
        public static extern int SDT_OpenPort(int iPortID);

        [DllImport("sdtapi.dll")]
        public static extern int SDT_ReadBaseMsg(int iPortID, byte[] pucCHMsg, ref int puiCHMsgLen, byte[] pucPHMsg, ref int puiPHMsgLen, int iIfOpen);

        //int STDCALL SDT_ReadBaseMsg(int iPortID,unsigned char * pucCHMsg,unsigned int *	puiCHMsgLen,unsigned char * pucPHMsg,unsigned int  *puiPHMsgLen,int iIfOpen);


        [DllImport("sdtapi.dll")]
        public static extern int SDT_ReadBaseMsgToFile(int iPortID, string fileName1, ref int puiCHMsgLen, string fileName2, ref int puiPHMsgLen, int iIfOpen);


        [DllImport("sdtapi.dll")]
        public static extern int SDT_ReadNewAppMsg(int iPortID, ref byte pucAppMsg, ref int puiAppMsgLen, int iIfOpen);


        [DllImport("sdtapi.dll")]
        public static extern int SDT_ResetSAM(int iPortID, int iIfOpen);


        [DllImport("sdtapi.dll")]
        public static extern int SDT_SelectIDCard(int iPortID, ref int pucSN, int iIfOpen);

        [DllImport("sdtapi.dll")]
        public static extern int SDT_SetCOMBaud(int iComID, int uiCurrBaud, int uiSetBaud);

        [DllImport("sdtapi.dll")]
        public static extern int SDT_SetMaxRFByte(int iPortID, byte ucByte, int iIfOpen);

        [DllImport("sdtapi.dll")]
        public static extern int SDT_StartFindIDCard(int iPortID, ref int pucIIN, int iIfOpen);


        [DllImport("WltRS.dll")]
        public static extern int GetBmp(string file_name, int intf);

        [DllImport("CMIDAPI.dll")]
        public static extern string ReadIDInfo(int iport);



        public delegate void De_ReadICCardComplete(EDZ objEDZ);
        public event De_ReadICCardComplete ReadICCardComplete;
        private EDZ objEDZ = new EDZ();
        private int EdziIfOpen = 1;               //自动开关串口
        int EdziPortID;

        public int InitDevice()
        {
            bool bUsbPort = false;

            int intOpenPortRtn = 0;

            for (int iPort = 1001; iPort <= 1016; iPort++)
            {
                intOpenPortRtn = SDT_OpenPort(iPort);
                if (intOpenPortRtn == 144)
                {
                    EdziPortID = iPort;
                    bUsbPort = true;
                    break;
                }
            }
            //检测串口的机具连接
            if (!bUsbPort)
            {
                for (int iPort = 1; iPort <= 2; iPort++)
                {
                    intOpenPortRtn = SDT_OpenPort(iPort);
                    if (intOpenPortRtn == 144)
                    {
                        EdziPortID = iPort;
                        bUsbPort = false;
                        break;
                    }
                }
            }
            if (intOpenPortRtn != 144)
            {
                throw new Exception("端口打开失败，请检测相应的端口或者重新连接读卡器！");
                //return 0;
            }

            return EdziPortID;

        }


        public EDZ ReadICCard(int iPort)
        {
            bool bUsbPort = false;
            int intOpenPortRtn = 0;
            int rtnTemp = 0;
            int pucIIN = 0;
            int pucSN = 0;
            int puiCHMsgLen = 0;
            int puiPHMsgLen = 0;

            objEDZ = new EDZ();


            if (iPort > 1000)
            {
                bUsbPort = true;
            }
            intOpenPortRtn = SDT_OpenPort(iPort);

            if (intOpenPortRtn != 144)
            {
                throw new Exception("端口打开失败，请检测相应的端口或者重新连接读卡器！");
            }
            //找卡
            rtnTemp = SDT_StartFindIDCard(EdziPortID, ref pucIIN, EdziIfOpen);
            if (rtnTemp != 159)
            {
                rtnTemp = SDT_StartFindIDCard(EdziPortID, ref pucIIN, EdziIfOpen);  //再找卡
                if (rtnTemp != 159)
                {
                    rtnTemp = SDT_ClosePort(EdziPortID);
                    throw new Exception("未放卡或者卡未放好，请重新放卡！");
                }
            }

            //选卡
            rtnTemp = SDT_SelectIDCard(EdziPortID, ref pucSN, EdziIfOpen);
            if (rtnTemp != 144)
            {
                rtnTemp = SDT_SelectIDCard(EdziPortID, ref pucSN, EdziIfOpen);  //再选卡
                if (rtnTemp != 144)
                {
                    rtnTemp = SDT_ClosePort(EdziPortID);
                    throw new Exception("读卡失败！");
                }
            }
            //注意，在这里，用户必须有应用程序当前目录的读写权限
            FileInfo objFile = new FileInfo("wz.txt");
            if (objFile.Exists)
            {
                objFile.Attributes = FileAttributes.Normal;
                objFile.Delete();
            }
            objFile = new FileInfo("zp.bmp");
            if (objFile.Exists)
            {
                objFile.Attributes = FileAttributes.Normal;
                objFile.Delete();
            }
            objFile = new FileInfo("zp.wlt");
            if (objFile.Exists)
            {
                objFile.Attributes = FileAttributes.Normal;
                objFile.Delete();
            }
            rtnTemp = SDT_ReadBaseMsgToFile(EdziPortID, "D:\\wz.txt", ref puiCHMsgLen, "D:\\zp.wlt", ref puiPHMsgLen, EdziIfOpen);
            if (rtnTemp != 144)
            {
                rtnTemp = SDT_ClosePort(EdziPortID);
                throw new Exception("读卡失败！");
                //return "读卡失败！";
            }
            
            FileInfo f = new FileInfo("D:\\wz.txt");
            FileStream fs = f.OpenRead();
            byte[] bt = new byte[fs.Length];
            fs.Read(bt, 0, (int)fs.Length);
            fs.Close();

            string str = UnicodeEncoding.Unicode.GetString(bt);

            objEDZ.Name = UnicodeEncoding.Unicode.GetString(bt, 0, 30).Trim();
            objEDZ.Sex_Code = UnicodeEncoding.Unicode.GetString(bt, 30, 2).Trim();
            objEDZ.NATION_Code = UnicodeEncoding.Unicode.GetString(bt, 32, 4).Trim();
            string strBird = UnicodeEncoding.Unicode.GetString(bt, 36, 16).Trim();
            objEDZ.BIRTH = Convert.ToDateTime(strBird.Substring(0, 4) + "年" + strBird.Substring(4, 2) + "月" + strBird.Substring(6) + "日");
            objEDZ.ADDRESS = UnicodeEncoding.Unicode.GetString(bt, 52, 70).Trim();
            objEDZ.IDC = UnicodeEncoding.Unicode.GetString(bt, 122, 36).Trim();
            objEDZ.REGORG = UnicodeEncoding.Unicode.GetString(bt, 158, 30).Trim();
            string strTem = UnicodeEncoding.Unicode.GetString(bt, 188, bt.GetLength(0) - 188).Trim();
            objEDZ.STARTDATE = Convert.ToDateTime(strTem.Substring(0, 4) + "年" + strTem.Substring(4, 2) + "月" + strTem.Substring(6, 2) + "日");
            strTem = strTem.Substring(8);
            if (strTem.Trim() != "长期")
            {
                objEDZ.ENDDATE = Convert.ToDateTime(strTem.Substring(0, 4) + "年" + strTem.Substring(4, 2) + "月" + strTem.Substring(6, 2) + "日");
            }
            else
            {
                objEDZ.ENDDATE = DateTime.MaxValue;
            }
            
          
            //ReadICCardComplete(objEDZ);
            return objEDZ;
        }


    }

 
    public class EDZ
    {
        private SortedList lstMZ = new SortedList();
        private string _Name;   //姓名
        private string _Sex_Code;   //性别代码
        private string _Sex_CName;   //性别
        private string _IDC;      //身份证号码
        private string _NATION_Code;   //民族代码
        private string _NATION_CName;   //民族
        private DateTime _BIRTH;     //出生日期
        private string _ADDRESS;    //住址
        private string _REGORG;     //签发机关
        private DateTime _STARTDATE;    //身份证有效起始日期
        private DateTime _ENDDATE;    //身份证有效截至日期
        private string _Period_Of_Validity_Code;   //有效期限代码，许多原来系统上面为了一代证考虑，常常存在这样的字段，二代证中已经没有了
        private string _Period_Of_Validity_CName;   //有效期限
        

        public EDZ()
        {
            lstMZ.Add("01", "汉族");
            lstMZ.Add("02", "蒙古族");
            lstMZ.Add("03", "回族");
            lstMZ.Add("04", "藏族");
            lstMZ.Add("05", "维吾尔族");
            lstMZ.Add("06", "苗族");
            lstMZ.Add("07", "彝族");
            lstMZ.Add("08", "壮族");
            lstMZ.Add("09", "布依族");
            lstMZ.Add("10", "朝鲜族");
            lstMZ.Add("11", "满族");
            lstMZ.Add("12", "侗族");
            lstMZ.Add("13", "瑶族");
            lstMZ.Add("14", "白族");
            lstMZ.Add("15", "土家族");
            lstMZ.Add("16", "哈尼族");
            lstMZ.Add("17", "哈萨克族");
            lstMZ.Add("18", "傣族");
            lstMZ.Add("19", "黎族");
            lstMZ.Add("20", "傈僳族");
            lstMZ.Add("21", "佤族");
            lstMZ.Add("22", "畲族");
            lstMZ.Add("23", "高山族");
            lstMZ.Add("24", "拉祜族");
            lstMZ.Add("25", "水族");
            lstMZ.Add("26", "东乡族");
            lstMZ.Add("27", "纳西族");
            lstMZ.Add("28", "景颇族");
            lstMZ.Add("29", "柯尔克孜族");
            lstMZ.Add("30", "土族");
            lstMZ.Add("31", "达翰尔族");
            lstMZ.Add("32", "仫佬族");
            lstMZ.Add("33", "羌族");
            lstMZ.Add("34", "布朗族");
            lstMZ.Add("35", "撒拉族");
            lstMZ.Add("36", "毛南族");
            lstMZ.Add("37", "仡佬族");
            lstMZ.Add("38", "锡伯族");
            lstMZ.Add("39", "阿昌族");
            lstMZ.Add("40", "普米族");
            lstMZ.Add("41", "塔吉克族");
            lstMZ.Add("42", "怒族");
            lstMZ.Add("43", "乌孜别克族");
            lstMZ.Add("44", "俄罗斯族");
            lstMZ.Add("45", "鄂温克族");
            lstMZ.Add("46", "德昂族");
            lstMZ.Add("47", "保安族");
            lstMZ.Add("48", "裕固族");
            lstMZ.Add("49", "京族");
            lstMZ.Add("50", "塔塔尔族");
            lstMZ.Add("51", "独龙族");
            lstMZ.Add("52", "鄂伦春族");
            lstMZ.Add("53", "赫哲族");
            lstMZ.Add("54", "门巴族");
            lstMZ.Add("55", "珞巴族");
            lstMZ.Add("56", "基诺族");
            lstMZ.Add("57", "其它");
            lstMZ.Add("98", "外国人入籍");
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Sex_Code
        {
            get { return _Sex_Code; }
            set
            {
                _Sex_Code = value;
                switch (value)
                {
                    case "1":
                        Sex_CName = "男";
                        break;
                    case "2":
                        Sex_CName = "女";
                        break;
                }
            }
        }
        public string Sex_CName
        {
            get { return _Sex_CName; }
            set { _Sex_CName = value; }
        }
        public string IDC
        {
            get { return _IDC; }
            set { _IDC = value; }
        }
        public string NATION_Code
        {
            get { return _NATION_Code; }
            set
            {
                _NATION_Code = value;
                if (lstMZ.Contains(value))
                    NATION_CName = lstMZ[value].ToString();
            }
        }
        public string NATION_CName
        {
            get { return _NATION_CName; }
            set { _NATION_CName = value; }
        }
        public DateTime BIRTH
        {
            get { return _BIRTH; }
            set { _BIRTH = value; }
        }
        public string ADDRESS
        {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
        }
        public string REGORG
        {
            get { return _REGORG; }
            set { _REGORG = value; }
        }
        public DateTime STARTDATE
        {
            get { return _STARTDATE; }
            set { _STARTDATE = value; }
        }
        public DateTime ENDDATE
        {
            get { return _ENDDATE; }
            set
            {
                _ENDDATE = value;
                if (_ENDDATE == DateTime.MaxValue)
                {
                    _Period_Of_Validity_Code = "3";
                    _Period_Of_Validity_CName = "长期";
                }
                else
                {
                    if (_STARTDATE != DateTime.MinValue)
                    {
                        switch (value.AddDays(1).Year - _STARTDATE.Year)
                        {
                            case 5:
                                _Period_Of_Validity_Code = "4";
                                _Period_Of_Validity_CName = "5年";
                                break;
                            case 10:
                                _Period_Of_Validity_Code = "1";
                                _Period_Of_Validity_CName = "10年";
                                break;
                            case 20:
                                _Period_Of_Validity_Code = "2";
                                _Period_Of_Validity_CName = "20年";
                                break;
                        }
                    }
                }

            }
        }
        public string Period_Of_Validity_Code
        {
            get { return _Period_Of_Validity_Code; }
            set { _Period_Of_Validity_Code = value; }
        }
        public string Period_Of_Validity_CName
        {
            get { return _Period_Of_Validity_CName; }
            set { _Period_Of_Validity_CName = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("姓名:{0}", this.Name).AppendLine();
            sb.AppendFormat("身份证号码:{0}", this.IDC).AppendLine();
            return sb.ToString();
        }
    }
}