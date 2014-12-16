namespace CSV_Splitter
{
    partial class frm_CSV_Splitter
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
            System.Windows.Forms.GroupBox grpbox_outputOptions;
            System.Windows.Forms.Label lbl_numItems;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CSV_Splitter));
            this.txt_outFolder = new System.Windows.Forms.TextBox();
            this.btn_selectOutPath = new System.Windows.Forms.Button();
            this.tabcSplitOpts = new System.Windows.Forms.TabControl();
            this.tabEvenSplit = new System.Windows.Forms.TabPage();
            this.numUD_numPerFile = new System.Windows.Forms.NumericUpDown();
            this.lbl_numItemsPerFile = new System.Windows.Forms.Label();
            this.numUD_numFiles = new System.Windows.Forms.NumericUpDown();
            this.lbl_numOutputFiles = new System.Windows.Forms.Label();
            this.tabSplitUnevenly = new System.Windows.Forms.TabPage();
            this.dgvUnevenSplit = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.numOutFilesUneven = new System.Windows.Forms.NumericUpDown();
            this.tabSplitSortCode = new System.Windows.Forms.TabPage();
            this.lblSortCodes = new System.Windows.Forms.Label();
            this.txt_infile = new System.Windows.Forms.TextBox();
            this.btn_SelectCSV = new System.Windows.Forms.Button();
            this.grpbox_inputFile = new System.Windows.Forms.GroupBox();
            this.txt_numItems = new System.Windows.Forms.TextBox();
            this.ofd_inputCSV = new System.Windows.Forms.OpenFileDialog();
            this.fbd_outputFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_split = new System.Windows.Forms.Button();
            grpbox_outputOptions = new System.Windows.Forms.GroupBox();
            lbl_numItems = new System.Windows.Forms.Label();
            grpbox_outputOptions.SuspendLayout();
            this.tabcSplitOpts.SuspendLayout();
            this.tabEvenSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_numPerFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_numFiles)).BeginInit();
            this.tabSplitUnevenly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnevenSplit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutFilesUneven)).BeginInit();
            this.tabSplitSortCode.SuspendLayout();
            this.grpbox_inputFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbox_outputOptions
            // 
            grpbox_outputOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            grpbox_outputOptions.BackColor = System.Drawing.SystemColors.Window;
            grpbox_outputOptions.Controls.Add(this.txt_outFolder);
            grpbox_outputOptions.Controls.Add(this.btn_selectOutPath);
            grpbox_outputOptions.Location = new System.Drawing.Point(12, 98);
            grpbox_outputOptions.Name = "grpbox_outputOptions";
            grpbox_outputOptions.Size = new System.Drawing.Size(401, 217);
            grpbox_outputOptions.TabIndex = 4;
            grpbox_outputOptions.TabStop = false;
            grpbox_outputOptions.Text = "Output Options:";
            // 
            // txt_outFolder
            // 
            this.txt_outFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_outFolder.BackColor = System.Drawing.SystemColors.Window;
            this.txt_outFolder.Location = new System.Drawing.Point(6, 48);
            this.txt_outFolder.Name = "txt_outFolder";
            this.txt_outFolder.ReadOnly = true;
            this.txt_outFolder.Size = new System.Drawing.Size(389, 20);
            this.txt_outFolder.TabIndex = 13;
            // 
            // btn_selectOutPath
            // 
            this.btn_selectOutPath.Location = new System.Drawing.Point(6, 19);
            this.btn_selectOutPath.Name = "btn_selectOutPath";
            this.btn_selectOutPath.Size = new System.Drawing.Size(126, 23);
            this.btn_selectOutPath.TabIndex = 12;
            this.btn_selectOutPath.Text = "Select Output Folder";
            this.btn_selectOutPath.UseVisualStyleBackColor = true;
            this.btn_selectOutPath.Click += new System.EventHandler(this.btn_selectOutPath_Click);
            // 
            // lbl_numItems
            // 
            lbl_numItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            lbl_numItems.AutoSize = true;
            lbl_numItems.Location = new System.Drawing.Point(161, 24);
            lbl_numItems.Name = "lbl_numItems";
            lbl_numItems.Size = new System.Drawing.Size(124, 13);
            lbl_numItems.TabIndex = 3;
            lbl_numItems.Text = "Number of records in file:";
            // 
            // tabcSplitOpts
            // 
            this.tabcSplitOpts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabcSplitOpts.Controls.Add(this.tabEvenSplit);
            this.tabcSplitOpts.Controls.Add(this.tabSplitUnevenly);
            this.tabcSplitOpts.Controls.Add(this.tabSplitSortCode);
            this.tabcSplitOpts.Enabled = false;
            this.tabcSplitOpts.Location = new System.Drawing.Point(419, 12);
            this.tabcSplitOpts.Name = "tabcSplitOpts";
            this.tabcSplitOpts.SelectedIndex = 0;
            this.tabcSplitOpts.Size = new System.Drawing.Size(253, 347);
            this.tabcSplitOpts.TabIndex = 15;
            // 
            // tabEvenSplit
            // 
            this.tabEvenSplit.BackColor = System.Drawing.SystemColors.Window;
            this.tabEvenSplit.Controls.Add(this.numUD_numPerFile);
            this.tabEvenSplit.Controls.Add(this.lbl_numItemsPerFile);
            this.tabEvenSplit.Controls.Add(this.numUD_numFiles);
            this.tabEvenSplit.Controls.Add(this.lbl_numOutputFiles);
            this.tabEvenSplit.Location = new System.Drawing.Point(4, 22);
            this.tabEvenSplit.Name = "tabEvenSplit";
            this.tabEvenSplit.Padding = new System.Windows.Forms.Padding(3);
            this.tabEvenSplit.Size = new System.Drawing.Size(245, 321);
            this.tabEvenSplit.TabIndex = 0;
            this.tabEvenSplit.Text = "Split Evenly";
            this.tabEvenSplit.Enter += new System.EventHandler(this.tabEvenSplit_Enter);
            // 
            // numUD_numPerFile
            // 
            this.numUD_numPerFile.Location = new System.Drawing.Point(143, 36);
            this.numUD_numPerFile.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUD_numPerFile.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUD_numPerFile.Name = "numUD_numPerFile";
            this.numUD_numPerFile.Size = new System.Drawing.Size(96, 20);
            this.numUD_numPerFile.TabIndex = 11;
            this.numUD_numPerFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numUD_numPerFile.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUD_numPerFile.ValueChanged += new System.EventHandler(this.numUD_numPerFile_ValueChanged);
            // 
            // lbl_numItemsPerFile
            // 
            this.lbl_numItemsPerFile.AutoSize = true;
            this.lbl_numItemsPerFile.Location = new System.Drawing.Point(6, 36);
            this.lbl_numItemsPerFile.Name = "lbl_numItemsPerFile";
            this.lbl_numItemsPerFile.Size = new System.Drawing.Size(131, 13);
            this.lbl_numItemsPerFile.TabIndex = 6;
            this.lbl_numItemsPerFile.Text = "Number of records per file:";
            // 
            // numUD_numFiles
            // 
            this.numUD_numFiles.Location = new System.Drawing.Point(143, 6);
            this.numUD_numFiles.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUD_numFiles.Name = "numUD_numFiles";
            this.numUD_numFiles.Size = new System.Drawing.Size(96, 20);
            this.numUD_numFiles.TabIndex = 10;
            this.numUD_numFiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numUD_numFiles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUD_numFiles.ValueChanged += new System.EventHandler(this.numUD_numFiles_ValueChanged);
            // 
            // lbl_numOutputFiles
            // 
            this.lbl_numOutputFiles.AutoSize = true;
            this.lbl_numOutputFiles.Location = new System.Drawing.Point(24, 8);
            this.lbl_numOutputFiles.Name = "lbl_numOutputFiles";
            this.lbl_numOutputFiles.Size = new System.Drawing.Size(113, 13);
            this.lbl_numOutputFiles.TabIndex = 4;
            this.lbl_numOutputFiles.Text = "Number of output files:";
            // 
            // tabSplitUnevenly
            // 
            this.tabSplitUnevenly.BackColor = System.Drawing.SystemColors.Window;
            this.tabSplitUnevenly.Controls.Add(this.dgvUnevenSplit);
            this.tabSplitUnevenly.Controls.Add(this.label1);
            this.tabSplitUnevenly.Controls.Add(this.numOutFilesUneven);
            this.tabSplitUnevenly.Location = new System.Drawing.Point(4, 22);
            this.tabSplitUnevenly.Name = "tabSplitUnevenly";
            this.tabSplitUnevenly.Padding = new System.Windows.Forms.Padding(3);
            this.tabSplitUnevenly.Size = new System.Drawing.Size(245, 321);
            this.tabSplitUnevenly.TabIndex = 1;
            this.tabSplitUnevenly.Text = "Split Unevenly";
            this.tabSplitUnevenly.Enter += new System.EventHandler(this.tabSplitUnevenly_Enter);
            // 
            // dgvUnevenSplit
            // 
            this.dgvUnevenSplit.AllowUserToAddRows = false;
            this.dgvUnevenSplit.AllowUserToDeleteRows = false;
            this.dgvUnevenSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUnevenSplit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnevenSplit.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvUnevenSplit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnevenSplit.GridColor = System.Drawing.SystemColors.Window;
            this.dgvUnevenSplit.Location = new System.Drawing.Point(6, 32);
            this.dgvUnevenSplit.Name = "dgvUnevenSplit";
            this.dgvUnevenSplit.Size = new System.Drawing.Size(233, 283);
            this.dgvUnevenSplit.TabIndex = 13;
            this.dgvUnevenSplit.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnevenSplit_CellEndEdit);
            this.dgvUnevenSplit.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvUnevenSplit_CellValidating);
            this.dgvUnevenSplit.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnevenSplit_CellValueChanged);
            this.dgvUnevenSplit.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvUnevenSplit_EditingControlShowing);
            this.dgvUnevenSplit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvUnevenSplit_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Number of output files:";
            // 
            // numOutFilesUneven
            // 
            this.numOutFilesUneven.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numOutFilesUneven.Location = new System.Drawing.Point(143, 6);
            this.numOutFilesUneven.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numOutFilesUneven.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numOutFilesUneven.Name = "numOutFilesUneven";
            this.numOutFilesUneven.Size = new System.Drawing.Size(96, 20);
            this.numOutFilesUneven.TabIndex = 11;
            this.numOutFilesUneven.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numOutFilesUneven.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numOutFilesUneven.ValueChanged += new System.EventHandler(this.numOutFilesUneven_ValueChanged);
            // 
            // tabSplitSortCode
            // 
            this.tabSplitSortCode.BackColor = System.Drawing.SystemColors.Window;
            this.tabSplitSortCode.Controls.Add(this.lblSortCodes);
            this.tabSplitSortCode.Location = new System.Drawing.Point(4, 22);
            this.tabSplitSortCode.Name = "tabSplitSortCode";
            this.tabSplitSortCode.Padding = new System.Windows.Forms.Padding(3);
            this.tabSplitSortCode.Size = new System.Drawing.Size(245, 321);
            this.tabSplitSortCode.TabIndex = 2;
            this.tabSplitSortCode.Text = "Split By Sort Codes";
            this.tabSplitSortCode.Enter += new System.EventHandler(this.tabSplitSortCode_Enter);
            // 
            // lblSortCodes
            // 
            this.lblSortCodes.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblSortCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSortCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSortCodes.Location = new System.Drawing.Point(6, 20);
            this.lblSortCodes.Name = "lblSortCodes";
            this.lblSortCodes.Size = new System.Drawing.Size(233, 106);
            this.lblSortCodes.TabIndex = 0;
            this.lblSortCodes.Text = "Split By Sort Code 1";
            this.lblSortCodes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSortCodes.UseCompatibleTextRendering = true;
            // 
            // txt_infile
            // 
            this.txt_infile.BackColor = System.Drawing.SystemColors.Window;
            this.txt_infile.Location = new System.Drawing.Point(6, 51);
            this.txt_infile.Name = "txt_infile";
            this.txt_infile.ReadOnly = true;
            this.txt_infile.Size = new System.Drawing.Size(389, 20);
            this.txt_infile.TabIndex = 0;
            // 
            // btn_SelectCSV
            // 
            this.btn_SelectCSV.Location = new System.Drawing.Point(6, 19);
            this.btn_SelectCSV.Name = "btn_SelectCSV";
            this.btn_SelectCSV.Size = new System.Drawing.Size(126, 23);
            this.btn_SelectCSV.TabIndex = 1;
            this.btn_SelectCSV.Text = "Select CSV";
            this.btn_SelectCSV.UseVisualStyleBackColor = true;
            this.btn_SelectCSV.Click += new System.EventHandler(this.btn_SelectCSV_Click);
            // 
            // grpbox_inputFile
            // 
            this.grpbox_inputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbox_inputFile.BackColor = System.Drawing.SystemColors.Window;
            this.grpbox_inputFile.Controls.Add(this.txt_numItems);
            this.grpbox_inputFile.Controls.Add(lbl_numItems);
            this.grpbox_inputFile.Controls.Add(this.btn_SelectCSV);
            this.grpbox_inputFile.Controls.Add(this.txt_infile);
            this.grpbox_inputFile.Location = new System.Drawing.Point(12, 12);
            this.grpbox_inputFile.Name = "grpbox_inputFile";
            this.grpbox_inputFile.Size = new System.Drawing.Size(401, 80);
            this.grpbox_inputFile.TabIndex = 3;
            this.grpbox_inputFile.TabStop = false;
            this.grpbox_inputFile.Text = "Input File:";
            // 
            // txt_numItems
            // 
            this.txt_numItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_numItems.BackColor = System.Drawing.SystemColors.Window;
            this.txt_numItems.Location = new System.Drawing.Point(291, 19);
            this.txt_numItems.Name = "txt_numItems";
            this.txt_numItems.ReadOnly = true;
            this.txt_numItems.Size = new System.Drawing.Size(104, 20);
            this.txt_numItems.TabIndex = 5;
            this.txt_numItems.TextChanged += new System.EventHandler(this.txt_numItems_TextChanged);
            // 
            // ofd_inputCSV
            // 
            this.ofd_inputCSV.Filter = "\"CSV Files\"|*.csv";
            // 
            // btn_split
            // 
            this.btn_split.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_split.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_split.Location = new System.Drawing.Point(18, 321);
            this.btn_split.Name = "btn_split";
            this.btn_split.Size = new System.Drawing.Size(395, 29);
            this.btn_split.TabIndex = 14;
            this.btn_split.Text = "Split";
            this.btn_split.UseVisualStyleBackColor = true;
            this.btn_split.Click += new System.EventHandler(this.btn_split_Click);
            // 
            // frm_CSV_Splitter
            // 
            this.AcceptButton = this.btn_split;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(684, 362);
            this.Controls.Add(grpbox_outputOptions);
            this.Controls.Add(this.btn_split);
            this.Controls.Add(this.tabcSplitOpts);
            this.Controls.Add(this.grpbox_inputFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "frm_CSV_Splitter";
            this.Text = "CSV Splitter";
            grpbox_outputOptions.ResumeLayout(false);
            grpbox_outputOptions.PerformLayout();
            this.tabcSplitOpts.ResumeLayout(false);
            this.tabEvenSplit.ResumeLayout(false);
            this.tabEvenSplit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_numPerFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_numFiles)).EndInit();
            this.tabSplitUnevenly.ResumeLayout(false);
            this.tabSplitUnevenly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnevenSplit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutFilesUneven)).EndInit();
            this.tabSplitSortCode.ResumeLayout(false);
            this.grpbox_inputFile.ResumeLayout(false);
            this.grpbox_inputFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_infile;
        private System.Windows.Forms.Button btn_SelectCSV;
        private System.Windows.Forms.GroupBox grpbox_inputFile;
        private System.Windows.Forms.Label lbl_numOutputFiles;
        private System.Windows.Forms.Label lbl_numItemsPerFile;
        private System.Windows.Forms.NumericUpDown numUD_numPerFile;
        private System.Windows.Forms.NumericUpDown numUD_numFiles;
        private System.Windows.Forms.TextBox txt_numItems;
        private System.Windows.Forms.OpenFileDialog ofd_inputCSV;
        private System.Windows.Forms.FolderBrowserDialog fbd_outputFolder;
        private System.Windows.Forms.TextBox txt_outFolder;
        private System.Windows.Forms.Button btn_selectOutPath;
        private System.Windows.Forms.Button btn_split;
        private System.Windows.Forms.TabControl tabcSplitOpts;
        private System.Windows.Forms.TabPage tabEvenSplit;
        private System.Windows.Forms.TabPage tabSplitUnevenly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numOutFilesUneven;
        private System.Windows.Forms.DataGridView dgvUnevenSplit;
        private System.Windows.Forms.TabPage tabSplitSortCode;
        private System.Windows.Forms.Label lblSortCodes;
    }
}

