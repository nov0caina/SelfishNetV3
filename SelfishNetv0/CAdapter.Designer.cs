namespace SelfishNetv0
{
    partial class CAdapter
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
            this.labelTypeText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelIPINFO = new System.Windows.Forms.Label();
            this.labelRedirectInfo = new System.Windows.Forms.Label();
            this.labelGWText = new System.Windows.Forms.Label();
            this.labelIpText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelTypeText
            // 
            this.labelTypeText.AutoSize = true;
            this.labelTypeText.Location = new System.Drawing.Point(78, 82);
            this.labelTypeText.Name = "labelTypeText";
            this.labelTypeText.Size = new System.Drawing.Size(47, 13);
            this.labelTypeText.TabIndex = 23;
            this.labelTypeText.Text = "Ethernet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "NIC Type :";
            // 
            // labelIPINFO
            // 
            this.labelIPINFO.AutoEllipsis = true;
            this.labelIPINFO.AutoSize = true;
            this.labelIPINFO.Location = new System.Drawing.Point(139, 103);
            this.labelIPINFO.Name = "labelIPINFO";
            this.labelIPINFO.Size = new System.Drawing.Size(0, 13);
            this.labelIPINFO.TabIndex = 21;
            // 
            // labelRedirectInfo
            // 
            this.labelRedirectInfo.AutoEllipsis = true;
            this.labelRedirectInfo.AutoSize = true;
            this.labelRedirectInfo.Location = new System.Drawing.Point(9, 152);
            this.labelRedirectInfo.Name = "labelRedirectInfo";
            this.labelRedirectInfo.Size = new System.Drawing.Size(384, 13);
            this.labelRedirectInfo.TabIndex = 20;
            this.labelRedirectInfo.Text = "Windows does not redirect packet, however,internal redirection will be activated";
            // 
            // labelGWText
            // 
            this.labelGWText.AutoSize = true;
            this.labelGWText.Location = new System.Drawing.Point(78, 128);
            this.labelGWText.Name = "labelGWText";
            this.labelGWText.Size = new System.Drawing.Size(40, 13);
            this.labelGWText.TabIndex = 19;
            this.labelGWText.Text = "0.0.0.0";
            // 
            // labelIpText
            // 
            this.labelIpText.AutoSize = true;
            this.labelIpText.Location = new System.Drawing.Point(78, 103);
            this.labelIpText.Name = "labelIpText";
            this.labelIpText.Size = new System.Drawing.Size(40, 13);
            this.labelIpText.TabIndex = 18;
            this.labelIpText.Text = "0.0.0.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Gateway :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Ip Address :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Select the Network Interface Card :";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(195, 200);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(51, 33);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(103, 200);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(51, 33);
            this.buttonOK.TabIndex = 13;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 58);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(328, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // CAdapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 266);
            this.ControlBox = false;
            this.Controls.Add(this.labelTypeText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelIPINFO);
            this.Controls.Add(this.labelRedirectInfo);
            this.Controls.Add(this.labelGWText);
            this.Controls.Add(this.labelIpText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CAdapter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nic selection";
            this.Load += new System.EventHandler(this.CAdapter_Load);
            this.Shown += new System.EventHandler(this.CAdapter_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTypeText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelIPINFO;
        private System.Windows.Forms.Label labelRedirectInfo;
        private System.Windows.Forms.Label labelGWText;
        private System.Windows.Forms.Label labelIpText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}