namespace GVConverter
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
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.btnOpenConverterSelectDialog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxConverterPath = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbOutputFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLayoutEngine = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbInputFiles = new System.Windows.Forms.ListBox();
            this.cmsInputFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDeleteSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.pbConvertProgress = new System.Windows.Forms.ProgressBar();
            this.btnClear = new System.Windows.Forms.Button();
            this.ofdConverterSelectDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.cmsInputFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenConverterSelectDialog
            // 
            this.btnOpenConverterSelectDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenConverterSelectDialog.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.btnOpenConverterSelectDialog.Location = new System.Drawing.Point(620, 46);
            this.btnOpenConverterSelectDialog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpenConverterSelectDialog.Name = "btnOpenConverterSelectDialog";
            this.btnOpenConverterSelectDialog.Size = new System.Drawing.Size(78, 29);
            this.btnOpenConverterSelectDialog.TabIndex = 0;
            this.btnOpenConverterSelectDialog.Text = "参照...";
            this.btnOpenConverterSelectDialog.UseVisualStyleBackColor = true;
            this.btnOpenConverterSelectDialog.Click += new System.EventHandler(this.btnOpenConverterSelectDialog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Graphviz実行ファイルパス";
            // 
            // tbxConverterPath
            // 
            this.tbxConverterPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxConverterPath.Location = new System.Drawing.Point(13, 50);
            this.tbxConverterPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxConverterPath.Name = "tbxConverterPath";
            this.tbxConverterPath.Size = new System.Drawing.Size(601, 23);
            this.tbxConverterPath.TabIndex = 2;
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Location = new System.Drawing.Point(603, 423);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(95, 38);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "変換実行";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbOutputFormat);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbLayoutEngine);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnOpenConverterSelectDialog);
            this.groupBox1.Controls.Add(this.tbxConverterPath);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(710, 161);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "設定";
            // 
            // cbOutputFormat
            // 
            this.cbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputFormat.FormattingEnabled = true;
            this.cbOutputFormat.Items.AddRange(new object[] {
            "bmp",
            "canon",
            "cmap",
            "cmapx",
            "cmapx_np",
            "dot",
            "emf",
            "emfplus",
            "eps",
            "fig",
            "gd",
            "gd2",
            "gif",
            "gv",
            "imap",
            "imap_np",
            "ismap",
            "jpe",
            "jpeg",
            "jpg",
            "metafile",
            "pdf",
            "pic",
            "plain",
            "plain-ext",
            "png",
            "pov",
            "ps",
            "ps2",
            "svg",
            "svgz",
            "tif",
            "tiff",
            "tk",
            "vml",
            "vmlz",
            "vrml",
            "wbmp",
            "xdot",
            "xdot1.2",
            "xdot1.4"});
            this.cbOutputFormat.Location = new System.Drawing.Point(215, 110);
            this.cbOutputFormat.Name = "cbOutputFormat";
            this.cbOutputFormat.Size = new System.Drawing.Size(176, 23);
            this.cbOutputFormat.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "出力形式";
            // 
            // cbLayoutEngine
            // 
            this.cbLayoutEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLayoutEngine.FormattingEnabled = true;
            this.cbLayoutEngine.Items.AddRange(new object[] {
            "circo",
            "dot",
            "fdp",
            "neato",
            "nop",
            "nop1",
            "nop2",
            "osage",
            "patchwork",
            "sfdp",
            "twopi"});
            this.cbLayoutEngine.Location = new System.Drawing.Point(13, 110);
            this.cbLayoutEngine.Name = "cbLayoutEngine";
            this.cbLayoutEngine.Size = new System.Drawing.Size(176, 23);
            this.cbLayoutEngine.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "レイアウトエンジン";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lbInputFiles);
            this.groupBox2.Controls.Add(this.pbConvertProgress);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnConvert);
            this.groupBox2.Location = new System.Drawing.Point(12, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(710, 468);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "変換ファイル";
            // 
            // lbInputFiles
            // 
            this.lbInputFiles.AllowDrop = true;
            this.lbInputFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbInputFiles.ContextMenuStrip = this.cmsInputFiles;
            this.lbInputFiles.FormattingEnabled = true;
            this.lbInputFiles.HorizontalScrollbar = true;
            this.lbInputFiles.ItemHeight = 15;
            this.lbInputFiles.Location = new System.Drawing.Point(13, 22);
            this.lbInputFiles.Name = "lbInputFiles";
            this.lbInputFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbInputFiles.Size = new System.Drawing.Size(685, 394);
            this.lbInputFiles.Sorted = true;
            this.lbInputFiles.TabIndex = 6;
            this.lbInputFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbInputFiles_DragDrop);
            this.lbInputFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbInputFiles_DragEnter);
            // 
            // cmsInputFiles
            // 
            this.cmsInputFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDeleteSelected});
            this.cmsInputFiles.Name = "cmsInputFiles";
            this.cmsInputFiles.Size = new System.Drawing.Size(156, 26);
            this.cmsInputFiles.Opening += new System.ComponentModel.CancelEventHandler(this.cmsInputFiles_Opening);
            // 
            // tsmiDeleteSelected
            // 
            this.tsmiDeleteSelected.Name = "tsmiDeleteSelected";
            this.tsmiDeleteSelected.Size = new System.Drawing.Size(155, 22);
            this.tsmiDeleteSelected.Text = "選択項目を削除";
            this.tsmiDeleteSelected.Click += new System.EventHandler(this.tsmiDeleteSelected_Click);
            // 
            // pbConvertProgress
            // 
            this.pbConvertProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbConvertProgress.Location = new System.Drawing.Point(13, 438);
            this.pbConvertProgress.Name = "pbConvertProgress";
            this.pbConvertProgress.Size = new System.Drawing.Size(503, 23);
            this.pbConvertProgress.TabIndex = 5;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Location = new System.Drawing.Point(522, 438);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ofdConverterSelectDialog
            // 
            this.ofdConverterSelectDialog.DefaultExt = "exe";
            this.ofdConverterSelectDialog.FileName = "dot.exe";
            this.ofdConverterSelectDialog.Filter = "Graphviz実行ファイル|dot.exe";
            this.ofdConverterSelectDialog.Title = "Graphviz実行ファイル選択";
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnConvert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClear;
            this.ClientSize = new System.Drawing.Size(734, 661);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(450, 350);
            this.Name = "frmMain";
            this.Text = "GVConverter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.cmsInputFiles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenConverterSelectDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxConverterPath;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbLayoutEngine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbOutputFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar pbConvertProgress;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox lbInputFiles;
        private System.Windows.Forms.OpenFileDialog ofdConverterSelectDialog;
        private System.Windows.Forms.ContextMenuStrip cmsInputFiles;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteSelected;
    }
}

