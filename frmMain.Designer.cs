namespace ListMagic
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDupes = new System.Windows.Forms.TabPage();
            this.optDupesDupes = new System.Windows.Forms.CheckBox();
            this.optDupesOutput = new System.Windows.Forms.CheckBox();
            this.lblDupesInput = new System.Windows.Forms.Label();
            this.cmdDupesOutput = new System.Windows.Forms.Button();
            this.cmdDupesInput = new System.Windows.Forms.Button();
            this.txtDupesOutput = new System.Windows.Forms.TextBox();
            this.txtDupesInput = new System.Windows.Forms.TextBox();
            this.tabMerge = new System.Windows.Forms.TabPage();
            this.cmdMergeAdd = new System.Windows.Forms.Button();
            this.cmdMergeRemove = new System.Windows.Forms.Button();
            this.lblMergeFiles = new System.Windows.Forms.GroupBox();
            this.lstMergeFiles = new System.Windows.Forms.ListBox();
            this.lblMergeOutput = new System.Windows.Forms.Label();
            this.cmdMergeOutput = new System.Windows.Forms.Button();
            this.txtMergeOutput = new System.Windows.Forms.TextBox();
            this.tabBlacklist = new System.Windows.Forms.TabPage();
            this.optBlacklistIgnoreCase = new System.Windows.Forms.CheckBox();
            this.optBlacklistOutput = new System.Windows.Forms.CheckBox();
            this.lblBlacklistBL = new System.Windows.Forms.Label();
            this.lblBlacklistInput = new System.Windows.Forms.Label();
            this.cmdBlacklistOutput = new System.Windows.Forms.Button();
            this.cmdBlacklistBL = new System.Windows.Forms.Button();
            this.cmdBlacklistInput = new System.Windows.Forms.Button();
            this.txtBlacklistOutput = new System.Windows.Forms.TextBox();
            this.txtBlacklistBL = new System.Windows.Forms.TextBox();
            this.txtBlacklistInput = new System.Windows.Forms.TextBox();
            this.tabSplit = new System.Windows.Forms.TabPage();
            this.lblSplitLines = new System.Windows.Forms.Label();
            this.txtSplitLines = new System.Windows.Forms.TextBox();
            this.optSplitOutput = new System.Windows.Forms.CheckBox();
            this.lblSplitInput = new System.Windows.Forms.Label();
            this.cmdSplitOutput = new System.Windows.Forms.Button();
            this.cmdSplitInput = new System.Windows.Forms.Button();
            this.txtSplitOutput = new System.Windows.Forms.TextBox();
            this.txtSplitInput = new System.Windows.Forms.TextBox();
            this.tabRando = new System.Windows.Forms.TabPage();
            this.optRandoOutput = new System.Windows.Forms.CheckBox();
            this.lblRandoInput = new System.Windows.Forms.Label();
            this.cmdRandoOutput = new System.Windows.Forms.Button();
            this.cmdRandoInput = new System.Windows.Forms.Button();
            this.txtRandoOutput = new System.Windows.Forms.TextBox();
            this.txtRandoInput = new System.Windows.Forms.TextBox();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.cndSettingsInstallContext = new System.Windows.Forms.Button();
            this.cndSettingsUnInstallContext = new System.Windows.Forms.Button();
            this.cmdMainStart = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMainStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControl.SuspendLayout();
            this.tabDupes.SuspendLayout();
            this.tabMerge.SuspendLayout();
            this.lblMergeFiles.SuspendLayout();
            this.tabBlacklist.SuspendLayout();
            this.tabSplit.SuspendLayout();
            this.tabRando.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabDupes);
            this.tabControl.Controls.Add(this.tabMerge);
            this.tabControl.Controls.Add(this.tabBlacklist);
            this.tabControl.Controls.Add(this.tabSplit);
            this.tabControl.Controls.Add(this.tabRando);
            this.tabControl.Controls.Add(this.tabSettings);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Arial", 9F);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(526, 317);
            this.tabControl.TabIndex = 14;
            // 
            // tabDupes
            // 
            this.tabDupes.Controls.Add(this.optDupesDupes);
            this.tabDupes.Controls.Add(this.optDupesOutput);
            this.tabDupes.Controls.Add(this.lblDupesInput);
            this.tabDupes.Controls.Add(this.cmdDupesOutput);
            this.tabDupes.Controls.Add(this.cmdDupesInput);
            this.tabDupes.Controls.Add(this.txtDupesOutput);
            this.tabDupes.Controls.Add(this.txtDupesInput);
            this.tabDupes.Font = new System.Drawing.Font("Arial", 9F);
            this.tabDupes.Location = new System.Drawing.Point(4, 24);
            this.tabDupes.Name = "tabDupes";
            this.tabDupes.Padding = new System.Windows.Forms.Padding(3);
            this.tabDupes.Size = new System.Drawing.Size(518, 289);
            this.tabDupes.TabIndex = 0;
            this.tabDupes.Text = "Sort List";
            this.tabDupes.UseVisualStyleBackColor = true;
            // 
            // optDupesDupes
            // 
            this.optDupesDupes.AutoSize = true;
            this.optDupesDupes.Checked = true;
            this.optDupesDupes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optDupesDupes.Font = new System.Drawing.Font("Arial", 9F);
            this.optDupesDupes.Location = new System.Drawing.Point(81, 69);
            this.optDupesDupes.Name = "optDupesDupes";
            this.optDupesDupes.Size = new System.Drawing.Size(134, 19);
            this.optDupesDupes.TabIndex = 27;
            this.optDupesDupes.Text = "Remove Duplicates";
            this.optDupesDupes.UseVisualStyleBackColor = true;
            // 
            // optDupesOutput
            // 
            this.optDupesOutput.AutoSize = true;
            this.optDupesOutput.Font = new System.Drawing.Font("Arial", 9F);
            this.optDupesOutput.Location = new System.Drawing.Point(9, 45);
            this.optDupesOutput.Name = "optDupesOutput";
            this.optDupesOutput.Size = new System.Drawing.Size(65, 19);
            this.optDupesOutput.TabIndex = 20;
            this.optDupesOutput.Text = "Output:";
            this.optDupesOutput.UseVisualStyleBackColor = true;
            this.optDupesOutput.CheckedChanged += new System.EventHandler(this.optDupesSaveFile_CheckedChanged);
            // 
            // lblDupesInput
            // 
            this.lblDupesInput.AutoSize = true;
            this.lblDupesInput.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDupesInput.Location = new System.Drawing.Point(38, 15);
            this.lblDupesInput.Name = "lblDupesInput";
            this.lblDupesInput.Size = new System.Drawing.Size(37, 15);
            this.lblDupesInput.TabIndex = 19;
            this.lblDupesInput.Text = "Input:";
            // 
            // cmdDupesOutput
            // 
            this.cmdDupesOutput.Enabled = false;
            this.cmdDupesOutput.Font = new System.Drawing.Font("Arial", 9F);
            this.cmdDupesOutput.Location = new System.Drawing.Point(469, 39);
            this.cmdDupesOutput.Name = "cmdDupesOutput";
            this.cmdDupesOutput.Size = new System.Drawing.Size(37, 27);
            this.cmdDupesOutput.TabIndex = 17;
            this.cmdDupesOutput.Text = "...";
            this.cmdDupesOutput.UseVisualStyleBackColor = true;
            // 
            // cmdDupesInput
            // 
            this.cmdDupesInput.Font = new System.Drawing.Font("Arial", 9F);
            this.cmdDupesInput.Location = new System.Drawing.Point(469, 9);
            this.cmdDupesInput.Name = "cmdDupesInput";
            this.cmdDupesInput.Size = new System.Drawing.Size(37, 27);
            this.cmdDupesInput.TabIndex = 15;
            this.cmdDupesInput.Text = "...";
            this.cmdDupesInput.UseVisualStyleBackColor = true;
            // 
            // txtDupesOutput
            // 
            this.txtDupesOutput.AllowDrop = true;
            this.txtDupesOutput.Enabled = false;
            this.txtDupesOutput.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDupesOutput.Location = new System.Drawing.Point(81, 42);
            this.txtDupesOutput.Name = "txtDupesOutput";
            this.txtDupesOutput.Size = new System.Drawing.Size(382, 21);
            this.txtDupesOutput.TabIndex = 16;
            // 
            // txtDupesInput
            // 
            this.txtDupesInput.AllowDrop = true;
            this.txtDupesInput.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDupesInput.Location = new System.Drawing.Point(81, 12);
            this.txtDupesInput.Name = "txtDupesInput";
            this.txtDupesInput.Size = new System.Drawing.Size(382, 21);
            this.txtDupesInput.TabIndex = 14;
            // 
            // tabMerge
            // 
            this.tabMerge.Controls.Add(this.cmdMergeAdd);
            this.tabMerge.Controls.Add(this.cmdMergeRemove);
            this.tabMerge.Controls.Add(this.lblMergeFiles);
            this.tabMerge.Controls.Add(this.lblMergeOutput);
            this.tabMerge.Controls.Add(this.cmdMergeOutput);
            this.tabMerge.Controls.Add(this.txtMergeOutput);
            this.tabMerge.Location = new System.Drawing.Point(4, 24);
            this.tabMerge.Name = "tabMerge";
            this.tabMerge.Padding = new System.Windows.Forms.Padding(3);
            this.tabMerge.Size = new System.Drawing.Size(518, 289);
            this.tabMerge.TabIndex = 1;
            this.tabMerge.Text = "Merge Files";
            this.tabMerge.UseVisualStyleBackColor = true;
            // 
            // cmdMergeAdd
            // 
            this.cmdMergeAdd.Font = new System.Drawing.Font("Arial", 9F);
            this.cmdMergeAdd.Location = new System.Drawing.Point(364, 212);
            this.cmdMergeAdd.Name = "cmdMergeAdd";
            this.cmdMergeAdd.Size = new System.Drawing.Size(71, 27);
            this.cmdMergeAdd.TabIndex = 30;
            this.cmdMergeAdd.Text = "Add";
            this.cmdMergeAdd.UseVisualStyleBackColor = true;
            this.cmdMergeAdd.Click += new System.EventHandler(this.cmdMergeAdd_Click);
            // 
            // cmdMergeRemove
            // 
            this.cmdMergeRemove.Font = new System.Drawing.Font("Arial", 9F);
            this.cmdMergeRemove.Location = new System.Drawing.Point(441, 212);
            this.cmdMergeRemove.Name = "cmdMergeRemove";
            this.cmdMergeRemove.Size = new System.Drawing.Size(69, 27);
            this.cmdMergeRemove.TabIndex = 30;
            this.cmdMergeRemove.Text = "Remove";
            this.cmdMergeRemove.UseVisualStyleBackColor = true;
            this.cmdMergeRemove.Click += new System.EventHandler(this.cmdMergeRemove_Click);
            // 
            // lblMergeFiles
            // 
            this.lblMergeFiles.Controls.Add(this.lstMergeFiles);
            this.lblMergeFiles.Location = new System.Drawing.Point(13, 11);
            this.lblMergeFiles.Name = "lblMergeFiles";
            this.lblMergeFiles.Size = new System.Drawing.Size(497, 195);
            this.lblMergeFiles.TabIndex = 29;
            this.lblMergeFiles.TabStop = false;
            this.lblMergeFiles.Text = "Files to merge: 0";
            // 
            // lstMergeFiles
            // 
            this.lstMergeFiles.FormattingEnabled = true;
            this.lstMergeFiles.HorizontalScrollbar = true;
            this.lstMergeFiles.ItemHeight = 15;
            this.lstMergeFiles.Location = new System.Drawing.Point(6, 18);
            this.lstMergeFiles.Name = "lstMergeFiles";
            this.lstMergeFiles.Size = new System.Drawing.Size(485, 169);
            this.lstMergeFiles.TabIndex = 0;
            // 
            // lblMergeOutput
            // 
            this.lblMergeOutput.AutoSize = true;
            this.lblMergeOutput.Font = new System.Drawing.Font("Arial", 9F);
            this.lblMergeOutput.Location = new System.Drawing.Point(16, 252);
            this.lblMergeOutput.Name = "lblMergeOutput";
            this.lblMergeOutput.Size = new System.Drawing.Size(46, 15);
            this.lblMergeOutput.TabIndex = 28;
            this.lblMergeOutput.Text = "Output:";
            // 
            // cmdMergeOutput
            // 
            this.cmdMergeOutput.Font = new System.Drawing.Font("Arial", 9F);
            this.cmdMergeOutput.Location = new System.Drawing.Point(474, 246);
            this.cmdMergeOutput.Name = "cmdMergeOutput";
            this.cmdMergeOutput.Size = new System.Drawing.Size(37, 27);
            this.cmdMergeOutput.TabIndex = 27;
            this.cmdMergeOutput.Text = "...";
            this.cmdMergeOutput.UseVisualStyleBackColor = true;
            // 
            // txtMergeOutput
            // 
            this.txtMergeOutput.AllowDrop = true;
            this.txtMergeOutput.Font = new System.Drawing.Font("Arial", 9F);
            this.txtMergeOutput.Location = new System.Drawing.Point(63, 249);
            this.txtMergeOutput.Name = "txtMergeOutput";
            this.txtMergeOutput.Size = new System.Drawing.Size(405, 21);
            this.txtMergeOutput.TabIndex = 26;
            // 
            // tabBlacklist
            // 
            this.tabBlacklist.Controls.Add(this.optBlacklistIgnoreCase);
            this.tabBlacklist.Controls.Add(this.optBlacklistOutput);
            this.tabBlacklist.Controls.Add(this.lblBlacklistBL);
            this.tabBlacklist.Controls.Add(this.lblBlacklistInput);
            this.tabBlacklist.Controls.Add(this.cmdBlacklistOutput);
            this.tabBlacklist.Controls.Add(this.cmdBlacklistBL);
            this.tabBlacklist.Controls.Add(this.cmdBlacklistInput);
            this.tabBlacklist.Controls.Add(this.txtBlacklistOutput);
            this.tabBlacklist.Controls.Add(this.txtBlacklistBL);
            this.tabBlacklist.Controls.Add(this.txtBlacklistInput);
            this.tabBlacklist.Location = new System.Drawing.Point(4, 24);
            this.tabBlacklist.Name = "tabBlacklist";
            this.tabBlacklist.Size = new System.Drawing.Size(518, 289);
            this.tabBlacklist.TabIndex = 2;
            this.tabBlacklist.Text = "Extract Blacklist";
            this.tabBlacklist.UseVisualStyleBackColor = true;
            // 
            // optBlacklistIgnoreCase
            // 
            this.optBlacklistIgnoreCase.AutoSize = true;
            this.optBlacklistIgnoreCase.Checked = true;
            this.optBlacklistIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optBlacklistIgnoreCase.Font = new System.Drawing.Font("Arial", 9F);
            this.optBlacklistIgnoreCase.Location = new System.Drawing.Point(81, 96);
            this.optBlacklistIgnoreCase.Name = "optBlacklistIgnoreCase";
            this.optBlacklistIgnoreCase.Size = new System.Drawing.Size(94, 19);
            this.optBlacklistIgnoreCase.TabIndex = 26;
            this.optBlacklistIgnoreCase.Text = "Ignore Case";
            this.optBlacklistIgnoreCase.UseVisualStyleBackColor = true;
            this.optBlacklistIgnoreCase.CheckedChanged += new System.EventHandler(this.optBlacklistOutput_CheckedChanged);
            // 
            // optBlacklistOutput
            // 
            this.optBlacklistOutput.AutoSize = true;
            this.optBlacklistOutput.Font = new System.Drawing.Font("Arial", 9F);
            this.optBlacklistOutput.Location = new System.Drawing.Point(9, 72);
            this.optBlacklistOutput.Name = "optBlacklistOutput";
            this.optBlacklistOutput.Size = new System.Drawing.Size(65, 19);
            this.optBlacklistOutput.TabIndex = 26;
            this.optBlacklistOutput.Text = "Output:";
            this.optBlacklistOutput.UseVisualStyleBackColor = true;
            this.optBlacklistOutput.CheckedChanged += new System.EventHandler(this.optBlacklistOutput_CheckedChanged);
            // 
            // lblBlacklistBL
            // 
            this.lblBlacklistBL.AutoSize = true;
            this.lblBlacklistBL.Font = new System.Drawing.Font("Arial", 9F);
            this.lblBlacklistBL.Location = new System.Drawing.Point(18, 45);
            this.lblBlacklistBL.Name = "lblBlacklistBL";
            this.lblBlacklistBL.Size = new System.Drawing.Size(56, 15);
            this.lblBlacklistBL.TabIndex = 25;
            this.lblBlacklistBL.Text = "Blacklist:";
            // 
            // lblBlacklistInput
            // 
            this.lblBlacklistInput.AutoSize = true;
            this.lblBlacklistInput.Font = new System.Drawing.Font("Arial", 9F);
            this.lblBlacklistInput.Location = new System.Drawing.Point(38, 15);
            this.lblBlacklistInput.Name = "lblBlacklistInput";
            this.lblBlacklistInput.Size = new System.Drawing.Size(37, 15);
            this.lblBlacklistInput.TabIndex = 25;
            this.lblBlacklistInput.Text = "Input:";
            // 
            // cmdBlacklistOutput
            // 
            this.cmdBlacklistOutput.Enabled = false;
            this.cmdBlacklistOutput.Font = new System.Drawing.Font("Arial", 9F);
            this.cmdBlacklistOutput.Location = new System.Drawing.Point(469, 66);
            this.cmdBlacklistOutput.Name = "cmdBlacklistOutput";
            this.cmdBlacklistOutput.Size = new System.Drawing.Size(37, 27);
            this.cmdBlacklistOutput.TabIndex = 24;
            this.cmdBlacklistOutput.Text = "...";
            this.cmdBlacklistOutput.UseVisualStyleBackColor = true;
            // 
            // cmdBlacklistBL
            // 
            this.cmdBlacklistBL.Font = new System.Drawing.Font("Arial", 9F);
            this.cmdBlacklistBL.Location = new System.Drawing.Point(469, 39);
            this.cmdBlacklistBL.Name = "cmdBlacklistBL";
            this.cmdBlacklistBL.Size = new System.Drawing.Size(37, 27);
            this.cmdBlacklistBL.TabIndex = 24;
            this.cmdBlacklistBL.Text = "...";
            this.cmdBlacklistBL.UseVisualStyleBackColor = true;
            // 
            // cmdBlacklistInput
            // 
            this.cmdBlacklistInput.Font = new System.Drawing.Font("Arial", 9F);
            this.cmdBlacklistInput.Location = new System.Drawing.Point(469, 9);
            this.cmdBlacklistInput.Name = "cmdBlacklistInput";
            this.cmdBlacklistInput.Size = new System.Drawing.Size(37, 27);
            this.cmdBlacklistInput.TabIndex = 22;
            this.cmdBlacklistInput.Text = "...";
            this.cmdBlacklistInput.UseVisualStyleBackColor = true;
            // 
            // txtBlacklistOutput
            // 
            this.txtBlacklistOutput.AllowDrop = true;
            this.txtBlacklistOutput.Enabled = false;
            this.txtBlacklistOutput.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBlacklistOutput.Location = new System.Drawing.Point(81, 69);
            this.txtBlacklistOutput.Name = "txtBlacklistOutput";
            this.txtBlacklistOutput.Size = new System.Drawing.Size(382, 21);
            this.txtBlacklistOutput.TabIndex = 23;
            // 
            // txtBlacklistBL
            // 
            this.txtBlacklistBL.AllowDrop = true;
            this.txtBlacklistBL.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBlacklistBL.Location = new System.Drawing.Point(81, 42);
            this.txtBlacklistBL.Name = "txtBlacklistBL";
            this.txtBlacklistBL.Size = new System.Drawing.Size(382, 21);
            this.txtBlacklistBL.TabIndex = 23;
            // 
            // txtBlacklistInput
            // 
            this.txtBlacklistInput.AllowDrop = true;
            this.txtBlacklistInput.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBlacklistInput.Location = new System.Drawing.Point(81, 12);
            this.txtBlacklistInput.Name = "txtBlacklistInput";
            this.txtBlacklistInput.Size = new System.Drawing.Size(382, 21);
            this.txtBlacklistInput.TabIndex = 21;
            // 
            // tabSplit
            // 
            this.tabSplit.Controls.Add(this.lblSplitLines);
            this.tabSplit.Controls.Add(this.txtSplitLines);
            this.tabSplit.Controls.Add(this.optSplitOutput);
            this.tabSplit.Controls.Add(this.lblSplitInput);
            this.tabSplit.Controls.Add(this.cmdSplitOutput);
            this.tabSplit.Controls.Add(this.cmdSplitInput);
            this.tabSplit.Controls.Add(this.txtSplitOutput);
            this.tabSplit.Controls.Add(this.txtSplitInput);
            this.tabSplit.Location = new System.Drawing.Point(4, 24);
            this.tabSplit.Name = "tabSplit";
            this.tabSplit.Size = new System.Drawing.Size(518, 289);
            this.tabSplit.TabIndex = 3;
            this.tabSplit.Text = "Split List";
            this.tabSplit.UseVisualStyleBackColor = true;
            // 
            // lblSplitLines
            // 
            this.lblSplitLines.AutoSize = true;
            this.lblSplitLines.Font = new System.Drawing.Font("Arial", 9F);
            this.lblSplitLines.Location = new System.Drawing.Point(78, 74);
            this.lblSplitLines.Name = "lblSplitLines";
            this.lblSplitLines.Size = new System.Drawing.Size(108, 15);
            this.lblSplitLines.TabIndex = 28;
            this.lblSplitLines.Text = "Lines in each part:";
            // 
            // txtSplitLines
            // 
            this.txtSplitLines.AllowDrop = true;
            this.txtSplitLines.Font = new System.Drawing.Font("Arial", 9F);
            this.txtSplitLines.Location = new System.Drawing.Point(192, 71);
            this.txtSplitLines.Name = "txtSplitLines";
            this.txtSplitLines.Size = new System.Drawing.Size(77, 21);
            this.txtSplitLines.TabIndex = 27;
            this.txtSplitLines.Text = "5000";
            // 
            // optSplitOutput
            // 
            this.optSplitOutput.AutoSize = true;
            this.optSplitOutput.Font = new System.Drawing.Font("Arial", 9F);
            this.optSplitOutput.Location = new System.Drawing.Point(9, 45);
            this.optSplitOutput.Name = "optSplitOutput";
            this.optSplitOutput.Size = new System.Drawing.Size(65, 19);
            this.optSplitOutput.TabIndex = 26;
            this.optSplitOutput.Text = "Output:";
            this.optSplitOutput.UseVisualStyleBackColor = true;
            this.optSplitOutput.CheckedChanged += new System.EventHandler(this.optSplitOutput_CheckedChanged);
            // 
            // lblSplitInput
            // 
            this.lblSplitInput.AutoSize = true;
            this.lblSplitInput.Font = new System.Drawing.Font("Arial", 9F);
            this.lblSplitInput.Location = new System.Drawing.Point(38, 15);
            this.lblSplitInput.Name = "lblSplitInput";
            this.lblSplitInput.Size = new System.Drawing.Size(37, 15);
            this.lblSplitInput.TabIndex = 25;
            this.lblSplitInput.Text = "Input:";
            // 
            // cmdSplitOutput
            // 
            this.cmdSplitOutput.Enabled = false;
            this.cmdSplitOutput.Font = new System.Drawing.Font("Arial", 9F);
            this.cmdSplitOutput.Location = new System.Drawing.Point(469, 39);
            this.cmdSplitOutput.Name = "cmdSplitOutput";
            this.cmdSplitOutput.Size = new System.Drawing.Size(37, 27);
            this.cmdSplitOutput.TabIndex = 24;
            this.cmdSplitOutput.Text = "...";
            this.cmdSplitOutput.UseVisualStyleBackColor = true;
            // 
            // cmdSplitInput
            // 
            this.cmdSplitInput.Font = new System.Drawing.Font("Arial", 9F);
            this.cmdSplitInput.Location = new System.Drawing.Point(469, 9);
            this.cmdSplitInput.Name = "cmdSplitInput";
            this.cmdSplitInput.Size = new System.Drawing.Size(37, 27);
            this.cmdSplitInput.TabIndex = 22;
            this.cmdSplitInput.Text = "...";
            this.cmdSplitInput.UseVisualStyleBackColor = true;
            // 
            // txtSplitOutput
            // 
            this.txtSplitOutput.AllowDrop = true;
            this.txtSplitOutput.Enabled = false;
            this.txtSplitOutput.Font = new System.Drawing.Font("Arial", 9F);
            this.txtSplitOutput.Location = new System.Drawing.Point(81, 42);
            this.txtSplitOutput.Name = "txtSplitOutput";
            this.txtSplitOutput.Size = new System.Drawing.Size(382, 21);
            this.txtSplitOutput.TabIndex = 23;
            // 
            // txtSplitInput
            // 
            this.txtSplitInput.AllowDrop = true;
            this.txtSplitInput.Font = new System.Drawing.Font("Arial", 9F);
            this.txtSplitInput.Location = new System.Drawing.Point(81, 12);
            this.txtSplitInput.Name = "txtSplitInput";
            this.txtSplitInput.Size = new System.Drawing.Size(382, 21);
            this.txtSplitInput.TabIndex = 21;
            // 
            // tabRando
            // 
            this.tabRando.Controls.Add(this.optRandoOutput);
            this.tabRando.Controls.Add(this.lblRandoInput);
            this.tabRando.Controls.Add(this.cmdRandoOutput);
            this.tabRando.Controls.Add(this.cmdRandoInput);
            this.tabRando.Controls.Add(this.txtRandoOutput);
            this.tabRando.Controls.Add(this.txtRandoInput);
            this.tabRando.Location = new System.Drawing.Point(4, 24);
            this.tabRando.Name = "tabRando";
            this.tabRando.Size = new System.Drawing.Size(518, 289);
            this.tabRando.TabIndex = 4;
            this.tabRando.Text = "Randomize";
            this.tabRando.UseVisualStyleBackColor = true;
            // 
            // optRandoOutput
            // 
            this.optRandoOutput.AutoSize = true;
            this.optRandoOutput.Font = new System.Drawing.Font("Arial", 9F);
            this.optRandoOutput.Location = new System.Drawing.Point(9, 45);
            this.optRandoOutput.Name = "optRandoOutput";
            this.optRandoOutput.Size = new System.Drawing.Size(65, 19);
            this.optRandoOutput.TabIndex = 26;
            this.optRandoOutput.Text = "Output:";
            this.optRandoOutput.UseVisualStyleBackColor = true;
            this.optRandoOutput.CheckedChanged += new System.EventHandler(this.optRandoOutput_CheckedChanged);
            // 
            // lblRandoInput
            // 
            this.lblRandoInput.AutoSize = true;
            this.lblRandoInput.Font = new System.Drawing.Font("Arial", 9F);
            this.lblRandoInput.Location = new System.Drawing.Point(38, 15);
            this.lblRandoInput.Name = "lblRandoInput";
            this.lblRandoInput.Size = new System.Drawing.Size(37, 15);
            this.lblRandoInput.TabIndex = 25;
            this.lblRandoInput.Text = "Input:";
            // 
            // cmdRandoOutput
            // 
            this.cmdRandoOutput.Enabled = false;
            this.cmdRandoOutput.Font = new System.Drawing.Font("Arial", 9F);
            this.cmdRandoOutput.Location = new System.Drawing.Point(469, 39);
            this.cmdRandoOutput.Name = "cmdRandoOutput";
            this.cmdRandoOutput.Size = new System.Drawing.Size(37, 27);
            this.cmdRandoOutput.TabIndex = 24;
            this.cmdRandoOutput.Text = "...";
            this.cmdRandoOutput.UseVisualStyleBackColor = true;
            // 
            // cmdRandoInput
            // 
            this.cmdRandoInput.Font = new System.Drawing.Font("Arial", 9F);
            this.cmdRandoInput.Location = new System.Drawing.Point(469, 9);
            this.cmdRandoInput.Name = "cmdRandoInput";
            this.cmdRandoInput.Size = new System.Drawing.Size(37, 27);
            this.cmdRandoInput.TabIndex = 22;
            this.cmdRandoInput.Text = "...";
            this.cmdRandoInput.UseVisualStyleBackColor = true;
            // 
            // txtRandoOutput
            // 
            this.txtRandoOutput.AllowDrop = true;
            this.txtRandoOutput.Enabled = false;
            this.txtRandoOutput.Font = new System.Drawing.Font("Arial", 9F);
            this.txtRandoOutput.Location = new System.Drawing.Point(81, 42);
            this.txtRandoOutput.Name = "txtRandoOutput";
            this.txtRandoOutput.Size = new System.Drawing.Size(382, 21);
            this.txtRandoOutput.TabIndex = 23;
            // 
            // txtRandoInput
            // 
            this.txtRandoInput.AllowDrop = true;
            this.txtRandoInput.Font = new System.Drawing.Font("Arial", 9F);
            this.txtRandoInput.Location = new System.Drawing.Point(81, 12);
            this.txtRandoInput.Name = "txtRandoInput";
            this.txtRandoInput.Size = new System.Drawing.Size(382, 21);
            this.txtRandoInput.TabIndex = 21;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.cndSettingsInstallContext);
            this.tabSettings.Controls.Add(this.cndSettingsUnInstallContext);
            this.tabSettings.Location = new System.Drawing.Point(4, 24);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(518, 289);
            this.tabSettings.TabIndex = 5;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // cndSettingsInstallContext
            // 
            this.cndSettingsInstallContext.Location = new System.Drawing.Point(8, 9);
            this.cndSettingsInstallContext.Name = "cndSettingsInstallContext";
            this.cndSettingsInstallContext.Size = new System.Drawing.Size(146, 27);
            this.cndSettingsInstallContext.TabIndex = 0;
            this.cndSettingsInstallContext.Text = "Install Context Menu";
            this.cndSettingsInstallContext.UseVisualStyleBackColor = true;
            this.cndSettingsInstallContext.Click += new System.EventHandler(this.cndSettingsInstallContext_Click);
            // 
            // cndSettingsUnInstallContext
            // 
            this.cndSettingsUnInstallContext.Location = new System.Drawing.Point(160, 9);
            this.cndSettingsUnInstallContext.Name = "cndSettingsUnInstallContext";
            this.cndSettingsUnInstallContext.Size = new System.Drawing.Size(146, 27);
            this.cndSettingsUnInstallContext.TabIndex = 0;
            this.cndSettingsUnInstallContext.Text = "Uninstall Context Menu";
            this.cndSettingsUnInstallContext.UseVisualStyleBackColor = true;
            this.cndSettingsUnInstallContext.Click += new System.EventHandler(this.cndSettingsUnInstallContext_Click);
            // 
            // cmdMainStart
            // 
            this.cmdMainStart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdMainStart.Font = new System.Drawing.Font("Arial", 9F);
            this.cmdMainStart.Location = new System.Drawing.Point(0, 317);
            this.cmdMainStart.Name = "cmdMainStart";
            this.cmdMainStart.Size = new System.Drawing.Size(526, 41);
            this.cmdMainStart.TabIndex = 19;
            this.cmdMainStart.Text = "GO";
            this.cmdMainStart.UseVisualStyleBackColor = true;
            this.cmdMainStart.Click += new System.EventHandler(this.cmdMainStart_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblMainStatus,
            this.StatusProgress});
            this.statusBar.Location = new System.Drawing.Point(0, 358);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(526, 22);
            this.statusBar.TabIndex = 20;
            this.statusBar.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // lblMainStatus
            // 
            this.lblMainStatus.Name = "lblMainStatus";
            this.lblMainStatus.Size = new System.Drawing.Size(26, 17);
            this.lblMainStatus.Text = "Idle";
            // 
            // StatusProgress
            // 
            this.StatusProgress.Name = "StatusProgress";
            this.StatusProgress.Size = new System.Drawing.Size(100, 16);
            this.StatusProgress.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 380);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.cmdMainStart);
            this.Controls.Add(this.statusBar);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "List Magic";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl.ResumeLayout(false);
            this.tabDupes.ResumeLayout(false);
            this.tabDupes.PerformLayout();
            this.tabMerge.ResumeLayout(false);
            this.tabMerge.PerformLayout();
            this.lblMergeFiles.ResumeLayout(false);
            this.tabBlacklist.ResumeLayout(false);
            this.tabBlacklist.PerformLayout();
            this.tabSplit.ResumeLayout(false);
            this.tabSplit.PerformLayout();
            this.tabRando.ResumeLayout(false);
            this.tabRando.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Label lblDupesInput;
        private System.Windows.Forms.Button cmdDupesOutput;
        private System.Windows.Forms.Button cmdDupesInput;
        private System.Windows.Forms.TextBox txtDupesOutput;
        private System.Windows.Forms.TextBox txtDupesInput;
        private System.Windows.Forms.TabPage tabMerge;
        private System.Windows.Forms.CheckBox optDupesOutput;
        private System.Windows.Forms.TabPage tabDupes;
        private System.Windows.Forms.TabPage tabBlacklist;
        private System.Windows.Forms.TabPage tabSplit;
        private System.Windows.Forms.TabPage tabRando;
        private System.Windows.Forms.Button cmdMainStart;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblMainStatus;
        private System.Windows.Forms.CheckBox optRandoOutput;
        private System.Windows.Forms.Label lblRandoInput;
        private System.Windows.Forms.Button cmdRandoOutput;
        private System.Windows.Forms.Button cmdRandoInput;
        private System.Windows.Forms.TextBox txtRandoOutput;
        private System.Windows.Forms.TextBox txtRandoInput;
        private System.Windows.Forms.ToolStripProgressBar StatusProgress;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Button cndSettingsUnInstallContext;
        private System.Windows.Forms.Button cndSettingsInstallContext;
        private System.Windows.Forms.CheckBox optBlacklistOutput;
        private System.Windows.Forms.Label lblBlacklistBL;
        private System.Windows.Forms.Label lblBlacklistInput;
        private System.Windows.Forms.Button cmdBlacklistOutput;
        private System.Windows.Forms.Button cmdBlacklistBL;
        private System.Windows.Forms.Button cmdBlacklistInput;
        private System.Windows.Forms.TextBox txtBlacklistOutput;
        private System.Windows.Forms.TextBox txtBlacklistBL;
        private System.Windows.Forms.TextBox txtBlacklistInput;
        private System.Windows.Forms.CheckBox optBlacklistIgnoreCase;
        private System.Windows.Forms.GroupBox lblMergeFiles;
        private System.Windows.Forms.ListBox lstMergeFiles;
        private System.Windows.Forms.Label lblMergeOutput;
        private System.Windows.Forms.Button cmdMergeOutput;
        private System.Windows.Forms.TextBox txtMergeOutput;
        private System.Windows.Forms.Button cmdMergeAdd;
        private System.Windows.Forms.Button cmdMergeRemove;
        private System.Windows.Forms.Label lblSplitLines;
        private System.Windows.Forms.TextBox txtSplitLines;
        private System.Windows.Forms.CheckBox optSplitOutput;
        private System.Windows.Forms.Label lblSplitInput;
        private System.Windows.Forms.Button cmdSplitOutput;
        private System.Windows.Forms.Button cmdSplitInput;
        private System.Windows.Forms.TextBox txtSplitOutput;
        private System.Windows.Forms.TextBox txtSplitInput;
        private System.Windows.Forms.CheckBox optDupesDupes;
    }
}

