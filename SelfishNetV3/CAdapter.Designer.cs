namespace SelfishNetv3
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
            this.labelTypeText.Location = new System.Drawing.Point(117, 126);
            this.labelTypeText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTypeText.Name = "labelTypeText";
            this.labelTypeText.Size = new System.Drawing.Size(71, 20);
            this.labelTypeText.TabIndex = 23;
            this.labelTypeText.Text = "Ethernet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 126);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "NIC Type :";
            // 
            // labelIPINFO
            // 
            this.labelIPINFO.AutoEllipsis = true;
            this.labelIPINFO.AutoSize = true;
            this.labelIPINFO.Location = new System.Drawing.Point(208, 158);
            this.labelIPINFO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIPINFO.Name = "labelIPINFO";
            this.labelIPINFO.Size = new System.Drawing.Size(0, 20);
            this.labelIPINFO.TabIndex = 21;
            // 
            // labelRedirectInfo
            // 
            this.labelRedirectInfo.AutoEllipsis = true;
            this.labelRedirectInfo.AutoSize = true;
            this.labelRedirectInfo.Location = new System.Drawing.Point(14, 234);
            this.labelRedirectInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRedirectInfo.Name = "labelRedirectInfo";
            this.labelRedirectInfo.Size = new System.Drawing.Size(563, 20);
            this.labelRedirectInfo.TabIndex = 20;
            this.labelRedirectInfo.Text = "Windows does not redirect packet, however,internal redirection will be activated";
            // 
            // labelGWText
            // 
            this.labelGWText.AutoSize = true;
            this.labelGWText.Location = new System.Drawing.Point(117, 197);
            this.labelGWText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGWText.Name = "labelGWText";
            this.labelGWText.Size = new System.Drawing.Size(57, 20);
            this.labelGWText.TabIndex = 19;
            this.labelGWText.Text = "0.0.0.0";
            // 
            // labelIpText
            // 
            this.labelIpText.AutoSize = true;
            this.labelIpText.Location = new System.Drawing.Point(117, 158);
            this.labelIpText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIpText.Name = "labelIpText";
            this.labelIpText.Size = new System.Drawing.Size(57, 20);
            this.labelIpText.TabIndex = 18;
            this.labelIpText.Text = "0.0.0.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 197);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Gateway :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 158);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Ip Address :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Select the Network Interface Card :";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(292, 308);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(76, 51);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(154, 308);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(76, 51);
            this.buttonOK.TabIndex = 13;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(18, 89);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(490, 28);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // CAdapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 409);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CAdapter";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nic selection";
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