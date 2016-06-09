namespace AutoDownloader
{
    partial class InfoAdd
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBack = new System.Windows.Forms.Panel();
            this.pnlInfoMain = new System.Windows.Forms.Panel();
            this.lblPath = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkDel = new System.Windows.Forms.CheckBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlBack.SuspendLayout();
            this.pnlInfoMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBack
            // 
            this.pnlBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlBack.Controls.Add(this.pnlInfoMain);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack.Location = new System.Drawing.Point(0, 0);
            this.pnlBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBack.Size = new System.Drawing.Size(651, 150);
            this.pnlBack.TabIndex = 0;
            // 
            // pnlInfoMain
            // 
            this.pnlInfoMain.BackColor = System.Drawing.Color.White;
            this.pnlInfoMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlInfoMain.Controls.Add(this.lblPath);
            this.pnlInfoMain.Controls.Add(this.label4);
            this.pnlInfoMain.Controls.Add(this.lblUrl);
            this.pnlInfoMain.Controls.Add(this.label2);
            this.pnlInfoMain.Controls.Add(this.chkDel);
            this.pnlInfoMain.Controls.Add(this.lblName);
            this.pnlInfoMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfoMain.Location = new System.Drawing.Point(3, 2);
            this.pnlInfoMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlInfoMain.Name = "pnlInfoMain";
            this.pnlInfoMain.Size = new System.Drawing.Size(645, 146);
            this.pnlInfoMain.TabIndex = 0;
            // 
            // lblPath
            // 
            this.lblPath.AutoEllipsis = true;
            this.lblPath.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPath.Location = new System.Drawing.Point(149, 92);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(460, 50);
            this.lblPath.TabIndex = 5;
            this.lblPath.Text = "C:\\hogehoge\\hogehoge\\hogehoge\\";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(5, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "保存ファイルパス：";
            // 
            // lblUrl
            // 
            this.lblUrl.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUrl.Location = new System.Drawing.Point(149, 50);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(460, 42);
            this.lblUrl.TabIndex = 3;
            this.lblUrl.Text = "http://*******";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(51, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "サイトURL：";
            // 
            // chkDel
            // 
            this.chkDel.Location = new System.Drawing.Point(615, 2);
            this.chkDel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkDel.Name = "chkDel";
            this.chkDel.Size = new System.Drawing.Size(29, 140);
            this.chkDel.TabIndex = 1;
            this.chkDel.UseVisualStyleBackColor = true;
            this.chkDel.CheckedChanged += new System.EventHandler(this.chkDel_CheckedChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblName.Location = new System.Drawing.Point(9, 12);
            this.lblName.Margin = new System.Windows.Forms.Padding(1);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(516, 27);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "授業名授業名授業名授業名授業名授業名";
            // 
            // InfoAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBack);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "InfoAdd";
            this.Size = new System.Drawing.Size(651, 150);
            this.pnlBack.ResumeLayout(false);
            this.pnlInfoMain.ResumeLayout(false);
            this.pnlInfoMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlBack;
        public System.Windows.Forms.Panel pnlInfoMain;
        public System.Windows.Forms.Label lblUrl;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox chkDel;
        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Label lblPath;
        public System.Windows.Forms.Label label4;

    }
}
