namespace HTTPAMAM
{
    partial class Form1
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
            this.btnTest = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.chkEnableHttps = new System.Windows.Forms.CheckBox();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblPort = new System.Windows.Forms.Label();
            this.btnInstallCert = new System.Windows.Forms.Button();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtRequestBody = new System.Windows.Forms.TextBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblBody = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPortStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(138, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(120, 30);
            this.btnTest.TabIndex = 9;
            this.btnTest.Text = "Тест запроса";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(12, 198);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(760, 218);
            this.txtLog.TabIndex = 11;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(12, 12);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(120, 30);
            this.btnStartStop.TabIndex = 10;
            this.btnStartStop.Text = "Старт";
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // chkEnableHttps
            // 
            this.chkEnableHttps.AutoSize = true;
            this.chkEnableHttps.Location = new System.Drawing.Point(264, 18);
            this.chkEnableHttps.Name = "chkEnableHttps";
            this.chkEnableHttps.Size = new System.Drawing.Size(62, 17);
            this.chkEnableHttps.TabIndex = 8;
            this.chkEnableHttps.Text = "HTTPS";
            // 
            // numPort
            // 
            this.numPort.BackColor = System.Drawing.Color.White;
            this.numPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPort.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numPort.Location = new System.Drawing.Point(411, 17);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(80, 23);
            this.numPort.TabIndex = 6;
            this.numPort.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPort.Location = new System.Drawing.Point(370, 19);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(38, 15);
            this.lblPort.TabIndex = 7;
            this.lblPort.Text = "Порт:";
            // 
            // btnInstallCert
            // 
            this.btnInstallCert.Location = new System.Drawing.Point(497, 17);
            this.btnInstallCert.Name = "btnInstallCert";
            this.btnInstallCert.Size = new System.Drawing.Size(120, 20);
            this.btnInstallCert.TabIndex = 12;
            this.btnInstallCert.Text = "Установить SSL";
            this.btnInstallCert.Click += new System.EventHandler(this.btnInstallCert_Click);
            // 
            // cmbMethod
            // 
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.Items.AddRange(new object[] {
            "GET",
            "POST",
            "PUT",
            "DELETE"});
            this.cmbMethod.Location = new System.Drawing.Point(64, 47);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(80, 21);
            this.cmbMethod.TabIndex = 1;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(188, 47);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(584, 20);
            this.txtUrl.TabIndex = 3;
            this.txtUrl.Text = "http://example.com";
            // 
            // txtRequestBody
            // 
            this.txtRequestBody.Location = new System.Drawing.Point(12, 92);
            this.txtRequestBody.Multiline = true;
            this.txtRequestBody.Name = "txtRequestBody";
            this.txtRequestBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRequestBody.Size = new System.Drawing.Size(760, 100);
            this.txtRequestBody.TabIndex = 5;
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(12, 50);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(42, 13);
            this.lblMethod.TabIndex = 0;
            this.lblMethod.Text = "Метод:";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(150, 50);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(32, 13);
            this.lblUrl.TabIndex = 2;
            this.lblUrl.Text = "URL:";
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Location = new System.Drawing.Point(12, 76);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(80, 13);
            this.lblBody.TabIndex = 4;
            this.lblBody.Text = "Тело запроса:";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblPortStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 419);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 13;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 17);
            this.lblStatus.Text = "Готов";
            // 
            // lblPortStatus
            // 
            this.lblPortStatus.Name = "lblPortStatus";
            this.lblPortStatus.Size = new System.Drawing.Size(65, 17);
            this.lblPortStatus.Text = "Порт: 8080";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.cmbMethod);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.txtRequestBody);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.chkEnableHttps);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnInstallCert);
            this.Controls.Add(this.statusStrip);
            this.Name = "Form1";
            this.Text = "HTTP/HTTPS Перехватчик";
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.CheckBox chkEnableHttps;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnInstallCert;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtRequestBody;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblPortStatus;
    }
    #endregion
}

