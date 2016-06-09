namespace AutoDownloader
{
    partial class frmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.今すぐデータを取得するToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最新バージョンの確認ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ソフトウェアについてToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbInterval = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkNotify = new System.Windows.Forms.CheckBox();
            this.RefreshInterval = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最新バージョンの確認ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.開発者への要望ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.autoDownloaderのバージョン情報ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.chkAutorun = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "AutoDownloader";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettings,
            this.今すぐデータを取得するToolStripMenuItem,
            this.最新バージョンの確認ToolStripMenuItem,
            this.toolStripSeparator1,
            this.ソフトウェアについてToolStripMenuItem,
            this.終了ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(246, 120);
            // 
            // menuSettings
            // 
            this.menuSettings.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(245, 22);
            this.menuSettings.Text = "設定";
            this.menuSettings.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // 今すぐデータを取得するToolStripMenuItem
            // 
            this.今すぐデータを取得するToolStripMenuItem.Name = "今すぐデータを取得するToolStripMenuItem";
            this.今すぐデータを取得するToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.今すぐデータを取得するToolStripMenuItem.Text = "今すぐデータを取得する";
            this.今すぐデータを取得するToolStripMenuItem.Click += new System.EventHandler(this.今すぐデータを取得するToolStripMenuItem_Click);
            // 
            // 最新バージョンの確認ToolStripMenuItem
            // 
            this.最新バージョンの確認ToolStripMenuItem.Name = "最新バージョンの確認ToolStripMenuItem";
            this.最新バージョンの確認ToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.最新バージョンの確認ToolStripMenuItem.Text = "最新バージョンの確認";
            this.最新バージョンの確認ToolStripMenuItem.Click += new System.EventHandler(this.最新バージョンの確認ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(242, 6);
            // 
            // ソフトウェアについてToolStripMenuItem
            // 
            this.ソフトウェアについてToolStripMenuItem.Name = "ソフトウェアについてToolStripMenuItem";
            this.ソフトウェアについてToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.ソフトウェアについてToolStripMenuItem.Text = "AutoDownloader のバージョン情報";
            this.ソフトウェアについてToolStripMenuItem.Click += new System.EventHandler(this.ソフトウェアについてToolStripMenuItem_Click);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(10, 487);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "更新間隔：";
            // 
            // cmbInterval
            // 
            this.cmbInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterval.Font = new System.Drawing.Font("MS UI Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbInterval.FormattingEnabled = true;
            this.cmbInterval.Items.AddRange(new object[] {
            "5 分",
            "10 分",
            "30 分",
            "1 時間",
            "6 時間",
            "12 時間",
            "1 日"});
            this.cmbInterval.Location = new System.Drawing.Point(86, 484);
            this.cmbInterval.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbInterval.Name = "cmbInterval";
            this.cmbInterval.Size = new System.Drawing.Size(92, 22);
            this.cmbInterval.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAdd.Location = new System.Drawing.Point(50, 445);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 32);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "＋";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDel.Location = new System.Drawing.Point(13, 445);
            this.btnDel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(33, 32);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "－";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(519, 411);
            this.pnlMain.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOK.Location = new System.Drawing.Point(440, 484);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(68, 21);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkNotify
            // 
            this.chkNotify.AutoSize = true;
            this.chkNotify.Location = new System.Drawing.Point(182, 488);
            this.chkNotify.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkNotify.Name = "chkNotify";
            this.chkNotify.Size = new System.Drawing.Size(103, 16);
            this.chkNotify.TabIndex = 7;
            this.chkNotify.Text = "通知をオンにする";
            this.chkNotify.UseVisualStyleBackColor = true;
            // 
            // RefreshInterval
            // 
            this.RefreshInterval.Interval = 3600000;
            this.RefreshInterval.Tick += new System.EventHandler(this.RefreshInterval_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.ヘルプToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(519, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了ToolStripMenuItem1});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // 終了ToolStripMenuItem1
            // 
            this.終了ToolStripMenuItem1.Name = "終了ToolStripMenuItem1";
            this.終了ToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.終了ToolStripMenuItem1.Text = "終了";
            this.終了ToolStripMenuItem1.Click += new System.EventHandler(this.終了ToolStripMenuItem1_Click);
            // 
            // ヘルプToolStripMenuItem
            // 
            this.ヘルプToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.最新バージョンの確認ToolStripMenuItem1,
            this.開発者への要望ToolStripMenuItem,
            this.toolStripSeparator2,
            this.autoDownloaderのバージョン情報ToolStripMenuItem});
            this.ヘルプToolStripMenuItem.Name = "ヘルプToolStripMenuItem";
            this.ヘルプToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ヘルプToolStripMenuItem.Text = "ヘルプ";
            // 
            // 最新バージョンの確認ToolStripMenuItem1
            // 
            this.最新バージョンの確認ToolStripMenuItem1.Name = "最新バージョンの確認ToolStripMenuItem1";
            this.最新バージョンの確認ToolStripMenuItem1.Size = new System.Drawing.Size(245, 22);
            this.最新バージョンの確認ToolStripMenuItem1.Text = "最新バージョンの確認";
            this.最新バージョンの確認ToolStripMenuItem1.Click += new System.EventHandler(this.最新バージョンの確認ToolStripMenuItem1_Click);
            // 
            // 開発者への要望ToolStripMenuItem
            // 
            this.開発者への要望ToolStripMenuItem.Name = "開発者への要望ToolStripMenuItem";
            this.開発者への要望ToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.開発者への要望ToolStripMenuItem.Text = "開発者への問い合わせ・要望";
            this.開発者への要望ToolStripMenuItem.Click += new System.EventHandler(this.開発者への要望ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(242, 6);
            // 
            // autoDownloaderのバージョン情報ToolStripMenuItem
            // 
            this.autoDownloaderのバージョン情報ToolStripMenuItem.Name = "autoDownloaderのバージョン情報ToolStripMenuItem";
            this.autoDownloaderのバージョン情報ToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.autoDownloaderのバージョン情報ToolStripMenuItem.Text = "AutoDownloader のバージョン情報";
            this.autoDownloaderのバージョン情報ToolStripMenuItem.Click += new System.EventHandler(this.autoDownloaderのバージョン情報ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(368, 484);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 21);
            this.button1.TabIndex = 9;
            this.button1.Text = "今すぐ更新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkAutorun
            // 
            this.chkAutorun.AutoSize = true;
            this.chkAutorun.Location = new System.Drawing.Point(182, 462);
            this.chkAutorun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkAutorun.Name = "chkAutorun";
            this.chkAutorun.Size = new System.Drawing.Size(201, 16);
            this.chkAutorun.TabIndex = 10;
            this.chkAutorun.Text = "Windows起動時に自動的に起動する";
            this.chkAutorun.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 517);
            this.Controls.Add(this.chkAutorun);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.chkNotify);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbInterval);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMain";
            this.Text = "AutoDownloader - 設定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbInterval;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.FlowLayoutPanel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem ソフトウェアについてToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkNotify;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        public System.Windows.Forms.Timer RefreshInterval;
        public System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripMenuItem 最新バージョンの確認ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ヘルプToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最新バージョンの確認ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem autoDownloaderのバージョン情報ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開発者への要望ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 今すぐデータを取得するToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkAutorun;
        //private InfoAdd infoAdd1;
        //private InfoAdd infoAdd2;
    }
}

