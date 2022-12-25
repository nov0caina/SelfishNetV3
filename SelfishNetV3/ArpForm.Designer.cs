using AdvancedDataGridView;

namespace SelfishNetv3
{
    partial class ArpForm
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
            this.components = new System.ComponentModel.Container();
            AdvancedDataGridView.TreeGridNode treeGridNode1 = new AdvancedDataGridView.TreeGridNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArpForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.treeGridView1 = new AdvancedDataGridView.TreeGridView();
            this.ColPCName = new AdvancedDataGridView.TreeGridColumn();
            this.ColPCIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPCMac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDownload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUpload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDownCap = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.ColUploadCap = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.ColBlock = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColSpoof = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ContextMenuViews = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ViewMenuIP = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenuMAC = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenuDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenuUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenuDownloadCap = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenuUploadCap = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenuBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenuSpoof = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timerSpoof = new System.Windows.Forms.Timer(this.components);
            this.SelfishNetTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SelfishNetTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerDiscovery = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeGridView1)).BeginInit();
            this.ContextMenuViews.SuspendLayout();
            this.SelfishNetTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(685, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::SelfishNetv3.Properties.Resources.Network_Map;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "Network Discovery";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::SelfishNetv3.Properties.Resources.Network_ConnectTo;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton2.Text = "Start redirecting-spoofing";
            this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::SelfishNetv3.Properties.Resources.DisconnectedDrive;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton3.Text = "stop redirecting- spoofing";
            this.toolStripButton3.Click += new System.EventHandler(this.ToolStripButton3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // treeGridView1
            // 
            this.treeGridView1.AllowUserToAddRows = false;
            this.treeGridView1.AllowUserToDeleteRows = false;
            this.treeGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.treeGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.treeGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.treeGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.treeGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.treeGridView1.ColumnHeadersHeight = 35;
            this.treeGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColPCName,
            this.ColPCIP,
            this.ColPCMac,
            this.ColDownload,
            this.ColUpload,
            this.ColDownCap,
            this.ColUploadCap,
            this.ColBlock,
            this.ColSpoof});
            this.treeGridView1.ContextMenuStrip = this.ContextMenuViews;
            this.treeGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.treeGridView1.ImageList = this.imageList1;
            this.treeGridView1.Location = new System.Drawing.Point(0, 39);
            this.treeGridView1.Name = "treeGridView1";
            treeGridNode1.Height = 20;
            treeGridNode1.ImageIndex = 0;
            this.treeGridView1.Nodes.Add(treeGridNode1);
            this.treeGridView1.RowHeadersVisible = false;
            this.treeGridView1.ShowCellErrors = false;
            this.treeGridView1.ShowCellToolTips = false;
            this.treeGridView1.ShowEditingIcon = false;
            this.treeGridView1.ShowRowErrors = false;
            this.treeGridView1.Size = new System.Drawing.Size(685, 351);
            this.treeGridView1.TabIndex = 1;
            this.treeGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.TreeGridView1_CellValueChanged);
            this.treeGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.TreeGridView1_CurrentCellDirtyStateChanged);
            // 
            // ColPCName
            // 
            this.ColPCName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColPCName.DefaultNodeImage = null;
            this.ColPCName.FillWeight = 200F;
            this.ColPCName.HeaderText = "PC Name";
            this.ColPCName.MinimumWidth = 40;
            this.ColPCName.Name = "ColPCName";
            this.ColPCName.ReadOnly = true;
            this.ColPCName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColPCIP
            // 
            this.ColPCIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColPCIP.HeaderText = "IP";
            this.ColPCIP.MinimumWidth = 35;
            this.ColPCIP.Name = "ColPCIP";
            this.ColPCIP.ReadOnly = true;
            this.ColPCIP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColPCMac
            // 
            this.ColPCMac.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColPCMac.HeaderText = "Mac";
            this.ColPCMac.MinimumWidth = 35;
            this.ColPCMac.Name = "ColPCMac";
            this.ColPCMac.ReadOnly = true;
            this.ColPCMac.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDownload
            // 
            this.ColDownload.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDownload.HeaderText = "Download KB/s";
            this.ColDownload.MinimumWidth = 20;
            this.ColDownload.Name = "ColDownload";
            this.ColDownload.ReadOnly = true;
            this.ColDownload.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColUpload
            // 
            this.ColUpload.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColUpload.HeaderText = "Upload KB/s";
            this.ColUpload.MinimumWidth = 20;
            this.ColUpload.Name = "ColUpload";
            this.ColUpload.ReadOnly = true;
            this.ColUpload.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDownCap
            // 
            this.ColDownCap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDownCap.HeaderText = "DownCap";
            this.ColDownCap.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.ColDownCap.MinimumWidth = 35;
            this.ColDownCap.Name = "ColDownCap";
            this.ColDownCap.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColUploadCap
            // 
            this.ColUploadCap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColUploadCap.HeaderText = "UploadCap";
            this.ColUploadCap.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.ColUploadCap.MinimumWidth = 35;
            this.ColUploadCap.Name = "ColUploadCap";
            this.ColUploadCap.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColBlock
            // 
            this.ColBlock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColBlock.HeaderText = "Block";
            this.ColBlock.MinimumWidth = 35;
            this.ColBlock.Name = "ColBlock";
            // 
            // ColSpoof
            // 
            this.ColSpoof.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColSpoof.HeaderText = "Spoof";
            this.ColSpoof.MinimumWidth = 35;
            this.ColSpoof.Name = "ColSpoof";
            this.ColSpoof.Visible = false;
            // 
            // ContextMenuViews
            // 
            this.ContextMenuViews.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewMenuIP,
            this.ViewMenuMAC,
            this.ViewMenuDownload,
            this.ViewMenuUpload,
            this.ViewMenuDownloadCap,
            this.ViewMenuUploadCap,
            this.ViewMenuBlock,
            this.ViewMenuSpoof});
            this.ContextMenuViews.Name = "ContextMenuViews";
            this.ContextMenuViews.Size = new System.Drawing.Size(178, 180);
            // 
            // ViewMenuIP
            // 
            this.ViewMenuIP.Checked = true;
            this.ViewMenuIP.CheckOnClick = true;
            this.ViewMenuIP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ViewMenuIP.Name = "ViewMenuIP";
            this.ViewMenuIP.Size = new System.Drawing.Size(177, 22);
            this.ViewMenuIP.Text = "IP";
            this.ViewMenuIP.CheckStateChanged += new System.EventHandler(this.ViewMenuIP_CheckStateChanged);
            // 
            // ViewMenuMAC
            // 
            this.ViewMenuMAC.Checked = true;
            this.ViewMenuMAC.CheckOnClick = true;
            this.ViewMenuMAC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ViewMenuMAC.Name = "ViewMenuMAC";
            this.ViewMenuMAC.Size = new System.Drawing.Size(177, 22);
            this.ViewMenuMAC.Text = "Mac Address";
            this.ViewMenuMAC.CheckStateChanged += new System.EventHandler(this.ViewMenuMAC_CheckStateChanged);
            // 
            // ViewMenuDownload
            // 
            this.ViewMenuDownload.Checked = true;
            this.ViewMenuDownload.CheckOnClick = true;
            this.ViewMenuDownload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ViewMenuDownload.Name = "ViewMenuDownload";
            this.ViewMenuDownload.Size = new System.Drawing.Size(177, 22);
            this.ViewMenuDownload.Text = "Download";
            this.ViewMenuDownload.CheckStateChanged += new System.EventHandler(this.ViewMenuDownload_CheckStateChanged);
            // 
            // ViewMenuUpload
            // 
            this.ViewMenuUpload.Checked = true;
            this.ViewMenuUpload.CheckOnClick = true;
            this.ViewMenuUpload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ViewMenuUpload.Name = "ViewMenuUpload";
            this.ViewMenuUpload.Size = new System.Drawing.Size(177, 22);
            this.ViewMenuUpload.Text = "Upload";
            this.ViewMenuUpload.CheckStateChanged += new System.EventHandler(this.ViewMenuUpload_CheckStateChanged);
            // 
            // ViewMenuDownloadCap
            // 
            this.ViewMenuDownloadCap.Checked = true;
            this.ViewMenuDownloadCap.CheckOnClick = true;
            this.ViewMenuDownloadCap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ViewMenuDownloadCap.Name = "ViewMenuDownloadCap";
            this.ViewMenuDownloadCap.Size = new System.Drawing.Size(177, 22);
            this.ViewMenuDownloadCap.Text = "Download Capacity";
            this.ViewMenuDownloadCap.CheckStateChanged += new System.EventHandler(this.ViewMenuDownloadCap_CheckStateChanged);
            // 
            // ViewMenuUploadCap
            // 
            this.ViewMenuUploadCap.Checked = true;
            this.ViewMenuUploadCap.CheckOnClick = true;
            this.ViewMenuUploadCap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ViewMenuUploadCap.Name = "ViewMenuUploadCap";
            this.ViewMenuUploadCap.Size = new System.Drawing.Size(177, 22);
            this.ViewMenuUploadCap.Text = "Upload Capacity";
            this.ViewMenuUploadCap.CheckStateChanged += new System.EventHandler(this.ViewMenuUploadCap_CheckStateChanged);
            // 
            // ViewMenuBlock
            // 
            this.ViewMenuBlock.Checked = true;
            this.ViewMenuBlock.CheckOnClick = true;
            this.ViewMenuBlock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ViewMenuBlock.Name = "ViewMenuBlock";
            this.ViewMenuBlock.Size = new System.Drawing.Size(177, 22);
            this.ViewMenuBlock.Text = "Block";
            this.ViewMenuBlock.CheckStateChanged += new System.EventHandler(this.ViewMenuBlock_CheckStateChanged);
            // 
            // ViewMenuSpoof
            // 
            this.ViewMenuSpoof.CheckOnClick = true;
            this.ViewMenuSpoof.Name = "ViewMenuSpoof";
            this.ViewMenuSpoof.Size = new System.Drawing.Size(177, 22);
            this.ViewMenuSpoof.Text = "Spoof";
            this.ViewMenuSpoof.CheckStateChanged += new System.EventHandler(this.ViewMenuSpoof_CheckStateChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "toolStripButton1.Image.png");
            this.imageList1.Images.SetKeyName(1, "toolStripButton2.Image.png");
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // timerSpoof
            // 
            this.timerSpoof.Tick += new System.EventHandler(this.TimerSpoof_Tick);
            // 
            // SelfishNetTrayIcon
            // 
            this.SelfishNetTrayIcon.BalloonTipText = "SelfishNet is minimized";
            this.SelfishNetTrayIcon.BalloonTipTitle = "\"SelfishNet\"";
            this.SelfishNetTrayIcon.ContextMenuStrip = this.SelfishNetTray;
            this.SelfishNetTrayIcon.Text = "SelfishNet v3";
            this.SelfishNetTrayIcon.Visible = true;
            this.SelfishNetTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SelfishNetTrayIcon_MouseDoubleClick);
            // 
            // SelfishNetTray
            // 
            this.SelfishNetTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.SelfishNetTray.Name = "SelfishNetTray";
            this.SelfishNetTray.Size = new System.Drawing.Size(104, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Image = global::SelfishNetv3.Properties.Resources._167;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::SelfishNetv3.Properties.Resources._172;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // timerDiscovery
            // 
            this.timerDiscovery.Interval = 50;
            // 
            // ArpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 390);
            this.Controls.Add(this.treeGridView1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ArpForm";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelfishNet v3 (Minimum By Abdou.Kouach)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArpForm_FormClosing);
            this.Load += new System.EventHandler(this.ArpForm_Load);
            this.Shown += new System.EventHandler(this.ArpForm_Shown);
            this.Resize += new System.EventHandler(this.ArpForm_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeGridView1)).EndInit();
            this.ContextMenuViews.ResumeLayout(false);
            this.SelfishNetTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private AdvancedDataGridView.TreeGridView treeGridView1;
        private System.Windows.Forms.ContextMenuStrip ContextMenuViews;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timerSpoof;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.NotifyIcon SelfishNetTrayIcon;
        private System.Windows.Forms.ToolStripMenuItem ViewMenuIP;
        private System.Windows.Forms.ToolStripMenuItem ViewMenuMAC;
        private System.Windows.Forms.ToolStripMenuItem ViewMenuDownload;
        private System.Windows.Forms.ToolStripMenuItem ViewMenuUpload;
        private System.Windows.Forms.ToolStripMenuItem ViewMenuDownloadCap;
        private System.Windows.Forms.ToolStripMenuItem ViewMenuUploadCap;
        private System.Windows.Forms.ToolStripMenuItem ViewMenuBlock;
        private System.Windows.Forms.ToolStripMenuItem ViewMenuSpoof;
        private System.Windows.Forms.Timer timerDiscovery;
        private System.Windows.Forms.ContextMenuStrip SelfishNetTray;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private TreeGridColumn ColPCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPCIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPCMac;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUpload;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn ColDownCap;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn ColUploadCap;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColBlock;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSpoof;
    }
}

