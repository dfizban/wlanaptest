namespace WiFiExample
{
    partial class Form1 //Partial type definitions allow for the definition of a class, struct, or interface to be split into multiple files.
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
            this.btn_RadioOn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_RadioOff = new System.Windows.Forms.Button();
            this.btnScanAP = new System.Windows.Forms.Button();
            this.btnWiFiCap = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnHWNetwokInfo = new System.Windows.Forms.Button();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.profileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rssiNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.channelNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.macAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.securityType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.encrypType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_RadioOn
            // 
            this.btn_RadioOn.Location = new System.Drawing.Point(22, 15);
            this.btn_RadioOn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btn_RadioOn.Name = "btn_RadioOn";
            this.btn_RadioOn.Size = new System.Drawing.Size(137, 42);
            this.btn_RadioOn.TabIndex = 0;
            this.btn_RadioOn.Text = "RadioOn";
            this.btn_RadioOn.UseVisualStyleBackColor = true;
            this.btn_RadioOn.Click += new System.EventHandler(this.btn_RadioOn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.profileName,
            this.rssiNum,
            this.channelNum,
            this.macAddress,
            this.ipAddress,
            this.securityType,
            this.encrypType});
            this.dataGridView1.Location = new System.Drawing.Point(22, 188);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(555, 321);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btn_RadioOff
            // 
            this.btn_RadioOff.Location = new System.Drawing.Point(187, 15);
            this.btn_RadioOff.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btn_RadioOff.Name = "btn_RadioOff";
            this.btn_RadioOff.Size = new System.Drawing.Size(137, 42);
            this.btn_RadioOff.TabIndex = 3;
            this.btn_RadioOff.Text = "RadioOff";
            this.btn_RadioOff.UseVisualStyleBackColor = true;
            this.btn_RadioOff.Click += new System.EventHandler(this.btn_RadioOff_Click);
            // 
            // btnScanAP
            // 
            this.btnScanAP.Location = new System.Drawing.Point(354, 15);
            this.btnScanAP.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnScanAP.Name = "btnScanAP";
            this.btnScanAP.Size = new System.Drawing.Size(137, 42);
            this.btnScanAP.TabIndex = 4;
            this.btnScanAP.Text = "ScanAP";
            this.btnScanAP.UseVisualStyleBackColor = true;
            this.btnScanAP.Click += new System.EventHandler(this.btnScanAP_Click);
            // 
            // btnWiFiCap
            // 
            this.btnWiFiCap.Location = new System.Drawing.Point(187, 85);
            this.btnWiFiCap.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnWiFiCap.Name = "btnWiFiCap";
            this.btnWiFiCap.Size = new System.Drawing.Size(181, 42);
            this.btnWiFiCap.TabIndex = 5;
            this.btnWiFiCap.Text = "WiFi Capabilities";
            this.btnWiFiCap.UseVisualStyleBackColor = true;
            this.btnWiFiCap.Click += new System.EventHandler(this.btnWiFiCap_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(22, 85);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(137, 42);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnHWNetwokInfo
            // 
            this.btnHWNetwokInfo.Location = new System.Drawing.Point(386, 85);
            this.btnHWNetwokInfo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnHWNetwokInfo.Name = "btnHWNetwokInfo";
            this.btnHWNetwokInfo.Size = new System.Drawing.Size(181, 42);
            this.btnHWNetwokInfo.TabIndex = 7;
            this.btnHWNetwokInfo.Text = "HW Network Info";
            this.btnHWNetwokInfo.UseVisualStyleBackColor = true;
            this.btnHWNetwokInfo.Click += new System.EventHandler(this.btnHWNetwokInfo_Click);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // profileName
            // 
            this.profileName.HeaderText = "SSID";
            this.profileName.Name = "profileName";
            // 
            // rssiNum
            // 
            this.rssiNum.HeaderText = "RSSI";
            this.rssiNum.Name = "rssiNum";
            this.rssiNum.Width = 50;
            // 
            // channelNum
            // 
            this.channelNum.HeaderText = "Channel";
            this.channelNum.Name = "channelNum";
            this.channelNum.Width = 50;
            // 
            // macAddress
            // 
            this.macAddress.HeaderText = "MAC";
            this.macAddress.Name = "macAddress";
            // 
            // ipAddress
            // 
            this.ipAddress.HeaderText = "IP";
            this.ipAddress.Name = "ipAddress";
            // 
            // securityType
            // 
            this.securityType.HeaderText = "Security Type";
            this.securityType.Name = "securityType";
            // 
            // encrypType
            // 
            this.encrypType.HeaderText = "Encryption Type";
            this.encrypType.Name = "encrypType";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "WiFi AP List";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 545);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHWNetwokInfo);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnWiFiCap);
            this.Controls.Add(this.btnScanAP);
            this.Controls.Add(this.btn_RadioOff);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_RadioOn);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_RadioOn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_RadioOff;
        private System.Windows.Forms.Button btnScanAP;
        private System.Windows.Forms.Button btnWiFiCap;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnHWNetwokInfo;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn profileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn rssiNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn channelNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn macAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn securityType;
        private System.Windows.Forms.DataGridViewTextBoxColumn encrypType;
        private System.Windows.Forms.Label label1;
    }
}

