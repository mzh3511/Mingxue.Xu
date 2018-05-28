namespace App
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnRequest = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.grpxHttp = new System.Windows.Forms.GroupBox();
            this.grpxResult = new System.Windows.Forms.GroupBox();
            this.grpxFtp = new System.Windows.Forms.GroupBox();
            this.btnFtpRequest = new System.Windows.Forms.Button();
            this.txtFtpUrl = new System.Windows.Forms.TextBox();
            this.grpxHttp.SuspendLayout();
            this.grpxResult.SuspendLayout();
            this.grpxFtp.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(6, 15);
            this.txtUrl.Multiline = true;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(355, 46);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.Text = "https://127.0.0.1/";
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(6, 64);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(75, 23);
            this.btnRequest.TabIndex = 2;
            this.btnRequest.Text = "Request";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(3, 17);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(344, 279);
            this.txtResult.TabIndex = 3;
            this.txtResult.Text = "";
            // 
            // grpxHttp
            // 
            this.grpxHttp.Controls.Add(this.btnRequest);
            this.grpxHttp.Controls.Add(this.txtUrl);
            this.grpxHttp.Location = new System.Drawing.Point(0, 3);
            this.grpxHttp.Name = "grpxHttp";
            this.grpxHttp.Size = new System.Drawing.Size(367, 91);
            this.grpxHttp.TabIndex = 4;
            this.grpxHttp.TabStop = false;
            this.grpxHttp.Text = "Http";
            // 
            // grpxResult
            // 
            this.grpxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpxResult.Controls.Add(this.txtResult);
            this.grpxResult.Location = new System.Drawing.Point(373, 12);
            this.grpxResult.Name = "grpxResult";
            this.grpxResult.Size = new System.Drawing.Size(350, 299);
            this.grpxResult.TabIndex = 5;
            this.grpxResult.TabStop = false;
            this.grpxResult.Text = "Result";
            // 
            // grpxFtp
            // 
            this.grpxFtp.Controls.Add(this.btnFtpRequest);
            this.grpxFtp.Controls.Add(this.txtFtpUrl);
            this.grpxFtp.Location = new System.Drawing.Point(3, 100);
            this.grpxFtp.Name = "grpxFtp";
            this.grpxFtp.Size = new System.Drawing.Size(367, 91);
            this.grpxFtp.TabIndex = 6;
            this.grpxFtp.TabStop = false;
            this.grpxFtp.Text = "Ftp";
            // 
            // btnFtpRequest
            // 
            this.btnFtpRequest.Location = new System.Drawing.Point(6, 64);
            this.btnFtpRequest.Name = "btnFtpRequest";
            this.btnFtpRequest.Size = new System.Drawing.Size(75, 23);
            this.btnFtpRequest.TabIndex = 2;
            this.btnFtpRequest.Text = "Request";
            this.btnFtpRequest.UseVisualStyleBackColor = true;
            this.btnFtpRequest.Click += new System.EventHandler(this.btnFtpRequest_Click);
            // 
            // txtFtpUrl
            // 
            this.txtFtpUrl.Location = new System.Drawing.Point(6, 15);
            this.txtFtpUrl.Multiline = true;
            this.txtFtpUrl.Name = "txtFtpUrl";
            this.txtFtpUrl.Size = new System.Drawing.Size(355, 46);
            this.txtFtpUrl.TabIndex = 1;
            this.txtFtpUrl.Text = "ftp://127.0.0.1/";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 313);
            this.Controls.Add(this.grpxFtp);
            this.Controls.Add(this.grpxResult);
            this.Controls.Add(this.grpxHttp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grpxHttp.ResumeLayout(false);
            this.grpxHttp.PerformLayout();
            this.grpxResult.ResumeLayout(false);
            this.grpxFtp.ResumeLayout(false);
            this.grpxFtp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.GroupBox grpxHttp;
        private System.Windows.Forms.GroupBox grpxResult;
        private System.Windows.Forms.GroupBox grpxFtp;
        private System.Windows.Forms.Button btnFtpRequest;
        private System.Windows.Forms.TextBox txtFtpUrl;
    }
}

