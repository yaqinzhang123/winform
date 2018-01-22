namespace WinFormUI
{
    partial class ICard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblMsg = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnInitDevice = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtport = new System.Windows.Forms.TextBox();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.txtYearMonth = new System.Windows.Forms.TextBox();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.txtFolk = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtClose = new System.Windows.Forms.TextBox();
            this.txtMFbyte = new System.Windows.Forms.TextBox();
            this.txtReset = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtRead = new System.Windows.Forms.TextBox();
            this.txtSelect = new System.Windows.Forms.TextBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.txtInit = new System.Windows.Forms.TextBox();
            this.txtSamStr = new System.Windows.Forms.TextBox();
            this.txtOpenPort = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSetMF = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnGetStatus = new System.Windows.Forms.Button();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnGetSamStr = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(23, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(434, 313);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblMsg);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.btnRead);
            this.tabPage1.Controls.Add(this.btnInitDevice);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.txtport);
            this.tabPage1.Controls.Add(this.txtAdd);
            this.tabPage1.Controls.Add(this.txtYearMonth);
            this.tabPage1.Controls.Add(this.txtSign);
            this.tabPage1.Controls.Add(this.txtFolk);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.txtNo);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(426, 287);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "读卡";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(233, 137);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 12);
            this.lblMsg.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(300, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(300, 189);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 16;
            this.btnRead.Text = "读卡";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click_1);
            // 
            // btnInitDevice
            // 
            this.btnInitDevice.Location = new System.Drawing.Point(300, 151);
            this.btnInitDevice.Name = "btnInitDevice";
            this.btnInitDevice.Size = new System.Drawing.Size(75, 23);
            this.btnInitDevice.TabIndex = 15;
            this.btnInitDevice.Text = "初始化";
            this.btnInitDevice.UseVisualStyleBackColor = true;
            this.btnInitDevice.Click += new System.EventHandler(this.btnInitDevice_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(288, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 124);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // txtport
            // 
            this.txtport.Location = new System.Drawing.Point(83, 245);
            this.txtport.Name = "txtport";
            this.txtport.Size = new System.Drawing.Size(100, 21);
            this.txtport.TabIndex = 13;
            // 
            // txtAdd
            // 
            this.txtAdd.Location = new System.Drawing.Point(68, 209);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(200, 21);
            this.txtAdd.TabIndex = 12;
            // 
            // txtYearMonth
            // 
            this.txtYearMonth.Location = new System.Drawing.Point(92, 175);
            this.txtYearMonth.Name = "txtYearMonth";
            this.txtYearMonth.Size = new System.Drawing.Size(100, 21);
            this.txtYearMonth.TabIndex = 11;
            // 
            // txtSign
            // 
            this.txtSign.Location = new System.Drawing.Point(92, 137);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(100, 21);
            this.txtSign.TabIndex = 10;
            // 
            // txtFolk
            // 
            this.txtFolk.Location = new System.Drawing.Point(83, 98);
            this.txtFolk.Name = "txtFolk";
            this.txtFolk.Size = new System.Drawing.Size(100, 21);
            this.txtFolk.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(83, 68);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 8;
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(104, 24);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(100, 21);
            this.txtNo.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "端口号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "地址：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "出生年月：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "签发机关：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "民族：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "姓名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "身份证号：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnOpen);
            this.tabPage2.Controls.Add(this.txtClose);
            this.tabPage2.Controls.Add(this.txtMFbyte);
            this.tabPage2.Controls.Add(this.txtReset);
            this.tabPage2.Controls.Add(this.txtStatus);
            this.tabPage2.Controls.Add(this.txtRead);
            this.tabPage2.Controls.Add(this.txtSelect);
            this.tabPage2.Controls.Add(this.txtFind);
            this.tabPage2.Controls.Add(this.txtInit);
            this.tabPage2.Controls.Add(this.txtSamStr);
            this.tabPage2.Controls.Add(this.txtOpenPort);
            this.tabPage2.Controls.Add(this.btnClose);
            this.tabPage2.Controls.Add(this.btnSetMF);
            this.tabPage2.Controls.Add(this.btnReset);
            this.tabPage2.Controls.Add(this.btnGetStatus);
            this.tabPage2.Controls.Add(this.btnReadCard);
            this.tabPage2.Controls.Add(this.btnSelect);
            this.tabPage2.Controls.Add(this.btnFind);
            this.tabPage2.Controls.Add(this.btnInit);
            this.tabPage2.Controls.Add(this.btnGetSamStr);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(426, 287);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(21, 7);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 20;
            this.btnOpen.Text = "打开设备";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // txtClose
            // 
            this.txtClose.Location = new System.Drawing.Point(123, 258);
            this.txtClose.Name = "txtClose";
            this.txtClose.Size = new System.Drawing.Size(100, 21);
            this.txtClose.TabIndex = 19;
            // 
            // txtMFbyte
            // 
            this.txtMFbyte.Location = new System.Drawing.Point(123, 235);
            this.txtMFbyte.Name = "txtMFbyte";
            this.txtMFbyte.Size = new System.Drawing.Size(100, 21);
            this.txtMFbyte.TabIndex = 18;
            // 
            // txtReset
            // 
            this.txtReset.Location = new System.Drawing.Point(123, 207);
            this.txtReset.Name = "txtReset";
            this.txtReset.Size = new System.Drawing.Size(100, 21);
            this.txtReset.TabIndex = 17;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(123, 178);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(100, 21);
            this.txtStatus.TabIndex = 16;
            // 
            // txtRead
            // 
            this.txtRead.Location = new System.Drawing.Point(123, 149);
            this.txtRead.Name = "txtRead";
            this.txtRead.Size = new System.Drawing.Size(100, 21);
            this.txtRead.TabIndex = 15;
            // 
            // txtSelect
            // 
            this.txtSelect.Location = new System.Drawing.Point(123, 119);
            this.txtSelect.Name = "txtSelect";
            this.txtSelect.Size = new System.Drawing.Size(100, 21);
            this.txtSelect.TabIndex = 14;
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(123, 91);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(100, 21);
            this.txtFind.TabIndex = 13;
            // 
            // txtInit
            // 
            this.txtInit.Location = new System.Drawing.Point(123, 63);
            this.txtInit.Name = "txtInit";
            this.txtInit.Size = new System.Drawing.Size(100, 21);
            this.txtInit.TabIndex = 12;
            // 
            // txtSamStr
            // 
            this.txtSamStr.Location = new System.Drawing.Point(123, 33);
            this.txtSamStr.Name = "txtSamStr";
            this.txtSamStr.Size = new System.Drawing.Size(100, 21);
            this.txtSamStr.TabIndex = 11;
            // 
            // txtOpenPort
            // 
            this.txtOpenPort.Location = new System.Drawing.Point(123, 4);
            this.txtOpenPort.Name = "txtOpenPort";
            this.txtOpenPort.Size = new System.Drawing.Size(100, 21);
            this.txtOpenPort.TabIndex = 10;
            this.txtOpenPort.Text = "1001";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(21, 257);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭设备";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSetMF
            // 
            this.btnSetMF.Location = new System.Drawing.Point(21, 228);
            this.btnSetMF.Name = "btnSetMF";
            this.btnSetMF.Size = new System.Drawing.Size(75, 23);
            this.btnSetMF.TabIndex = 8;
            this.btnSetMF.Text = "设置MFByte";
            this.btnSetMF.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(21, 206);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "重置设备";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnGetStatus
            // 
            this.btnGetStatus.Location = new System.Drawing.Point(21, 177);
            this.btnGetStatus.Name = "btnGetStatus";
            this.btnGetStatus.Size = new System.Drawing.Size(75, 23);
            this.btnGetStatus.TabIndex = 6;
            this.btnGetStatus.Text = "设备状态";
            this.btnGetStatus.UseVisualStyleBackColor = true;
            // 
            // btnReadCard
            // 
            this.btnReadCard.Location = new System.Drawing.Point(21, 148);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(75, 23);
            this.btnReadCard.TabIndex = 5;
            this.btnReadCard.Text = "读卡";
            this.btnReadCard.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(21, 119);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "选卡";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(21, 90);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "找卡";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(21, 61);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 2;
            this.btnInit.Text = "初始化设备";
            this.btnInit.UseVisualStyleBackColor = true;
            // 
            // btnGetSamStr
            // 
            this.btnGetSamStr.Location = new System.Drawing.Point(21, 32);
            this.btnGetSamStr.Name = "btnGetSamStr";
            this.btnGetSamStr.Size = new System.Drawing.Size(75, 23);
            this.btnGetSamStr.TabIndex = 1;
            this.btnGetSamStr.Text = "获取SAMStr";
            this.btnGetSamStr.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ICard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 327);
            this.Controls.Add(this.tabControl1);
            this.Name = "ICard";
            this.Text = "ICard";
            this.Load += new System.EventHandler(this.ICard_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnInitDevice;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtport;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.TextBox txtYearMonth;
        private System.Windows.Forms.TextBox txtSign;
        private System.Windows.Forms.TextBox txtFolk;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtClose;
        private System.Windows.Forms.TextBox txtMFbyte;
        private System.Windows.Forms.TextBox txtReset;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtRead;
        private System.Windows.Forms.TextBox txtSelect;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.TextBox txtInit;
        private System.Windows.Forms.TextBox txtSamStr;
        private System.Windows.Forms.TextBox txtOpenPort;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSetMF;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnGetStatus;
        private System.Windows.Forms.Button btnReadCard;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnGetSamStr;
        private System.Windows.Forms.Button button1;
    }
}