using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ListMagic
{
    public partial class frmMain : Form
    {
        // TODO:
        //  [ ] merge files from context menu doesn't catch all files some times
        //  [ ] add some sort of timeout catch for npust winapi functions 

        // ========================================================
        // =================== MAIN
        // ========================================================
        public string[] CommandLineActions = new string[] { "sort", "merge", "blacklist", "split", "randomize" };
        public bool CloseAppWhenComplete = false;
        public bool RunningFromCommandLine = false;
        public bool AutoRun = false;
        public bool IdleHandled = false;
        public List<Size> TabSizes = new List<Size>()
        {
            new Size(525, 117), // dupes
			new Size(525, 305), // merge
			new Size(525, 143), // blacklist
            new Size(525, 125), // split
			new Size(525, 100), // rando
			new Size(525, 100), // settings
		};

        List<string> mergeFiles = new List<string>();
        public frmMain(CommandLineArgs args)
        {
            //lstMergeFiles.DoubleClick += (object sender, EventArgs e) =>
            // {
            //     MessageBox.Show(string.Join("\r\n", mergeFiles.ToArray()));
            // };
            // check if command line action is set
            if (args.Params.ContainsKey("a") && CommandLineActions.Contains(args.Params["a"]))
            {
                RunningFromCommandLine = true;
            }

            InitializeComponent();
            this.FormClosing += FrmMain_FormClosing;

            // enable drag drop for all file txt fields
            EnableDragDrop(new TextBox[] {
                txtDupesInput, txtDupesOutput,
                txtRandoInput, txtRandoOutput,
                txtBlacklistOutput, txtBlacklistInput, txtBlacklistBL,
                txtMergeOutput,
                txtSplitInput, txtSplitOutput
            });

            // set multi dragdrop for merge files
            HandleMergeListboxEvents();

            // set all load button events
            SetFileLoader(cmdDupesInput, txtDupesInput, "Input File");
            SetFileLoader(cmdDupesOutput, txtDupesOutput, "Output File");
            SetFileLoader(cmdRandoInput, txtRandoInput, "Input File");
            SetFileLoader(cmdRandoOutput, txtRandoOutput, "Output File");
            SetFileLoader(cmdBlacklistInput, txtBlacklistInput, "Input File");
            SetFileLoader(cmdBlacklistBL, txtBlacklistBL, "Blacklist File");
            SetFileLoader(cmdBlacklistOutput, txtBlacklistOutput, "Output File");
            SetFileLoader(cmdMergeOutput, txtMergeOutput, "Output File");
            SetFileLoader(cmdSplitInput, txtSplitInput, "Input File");
            SetFileLoader(cmdSplitOutput, txtSplitOutput, "Output File");

            // handle tab changes
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            SwitchTab(0);

            if (RunningFromCommandLine) HandleCommandLineAction(args.Params["a"], args);

            Application.Idle += new EventHandler((object sender, EventArgs e) =>
            {
                if (IdleHandled) return;
                IdleHandled = true;
                // check auto run
                if (this.AutoRun)
                    cmdMainStart_Click(null, null);
            });
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            // set app version in header
            Version version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            this.Text = this.Text + " v" + version.ToString();
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // close all open npust windows
            NpustWrapper.KillProcessByName("npust");
            //Application.Exit();
            Environment.Exit(0);
        }
        public void HandleCommandLineAction(string action, CommandLineArgs args)
        {
            string input = null, output = null, blacklist = null, lines = null;
            switch(action)
            {
                case "sort":
                    input = args.GetParam("i");
                    output = args.GetParam("o");
                    if (output == null)
                    {
                        optDupesOutput.Checked = false;
                        //output = input;
                    }
                    else
                        optDupesOutput.Checked = true;

                    txtDupesInput.Text = input;
                    txtDupesOutput.Text = output;
                    optDupesDupes.Checked = args.Option("killdupes");
                    SwitchTab(0);
                    break;
                case "merge":
                    input = args.GetParam("i");
                    if(!lstMergeFiles.Items.Contains(input)) lstMergeFiles.Items.Add(input);

                    lblMergeFiles.Text = string.Format("Files to merge: {0}", lstMergeFiles.Items.Count);

                    SwitchTab(1);
                    break;
                case "blacklist":
                    input = args.GetParam("i");
                    blacklist = args.GetParam("b");
                    output = args.GetParam("o");
                    if (output == null)
                    {
                        optBlacklistOutput.Checked = false;
                        //output = input;
                    }
                    else
                        optBlacklistOutput.Checked = true;

                    txtBlacklistInput.Text = input;
                    txtBlacklistBL.Text = blacklist;
                    txtBlacklistOutput.Text = output;
                    SwitchTab(2);
                    break;
                case "split":
                    input = args.GetParam("i");
                    lines = args.GetParam("l");
                    output = args.GetParam("o");
                    if (output == null)
                    {
                        optSplitOutput.Checked = false;
                        //output = input;
                    }
                    else
                        optSplitOutput.Checked = true;
                    if (lines == null) lines = "5000";

                    txtSplitInput.Text = input;
                    txtSplitOutput.Text = output;
                    txtSplitLines.Text = lines;
                    SwitchTab(3);
                    break;
                case "randomize":
                    input = args.GetParam("i");
                    output = args.GetParam("o");
                    if (output == null)
                    {
                        optRandoOutput.Checked = false;
                        output = input;
                    }
                    else
                        optRandoOutput.Checked = true;

                    txtRandoInput.Text = input;
                    txtRandoOutput.Text = output;
                    SwitchTab(4);
                    break;
            }
            if (args.Option("autoclose")) this.CloseAppWhenComplete = true;
            if (args.Option("autorun")) this.AutoRun = true;
        }
        private void cmdMainStart_Click(object sender, EventArgs e)
        {
            cmdMainStart.Enabled = false;
            switch (tabControl.SelectedIndex)
            {
                case 0: // dupes
                    SortList();
                    break;
                case 1: // merge
                    MergeLists();
                    break;
                case 2: // blacklist
                    ExtractBlacklist();
                    break;
                case 3: // split
                    SplitList();
                    break;
                case 4: // rando
                    RandomizeFile();
                    break;
                case 5:
                    break;
            }
            cmdMainStart.Enabled = true;

            // auto close app if option set
            if (this.CloseAppWhenComplete)
                FrmMain_FormClosing(null, null);
        }
        public void HandleStatusBar(int progress)
        {
            if (progress > 0)
            {
                StatusProgress.Visible = true;
                StatusProgress.Value = progress;
            }
        }
        protected override void WndProc(ref Message m)
        {
            try
            {
                // handle merge files being pushed from other instances
                if (m.Msg == WinAPI.WM_COPYDATA)
                {
                    WinAPI.COPYDATASTRUCT CD =
                    (WinAPI.COPYDATASTRUCT)m.GetLParam(typeof(WinAPI.COPYDATASTRUCT));
                    byte[] B = new byte[CD.cbData];
                    IntPtr lpData = new IntPtr(CD.lpData);
                    Marshal.Copy(lpData, B, 0, CD.cbData);
                    string strData = Encoding.Default.GetString(B);

                    Debug.Print("Incoming message: " + strData);

                    mergeFiles.Add(strData);
                    if (!lstMergeFiles.Items.Contains(strData))
                        lstMergeFiles.Items.Add(strData);

                    lblMergeFiles.Text = string.Format("Files to merge: {0}", lstMergeFiles.Items.Count);

                    SwitchTab(1);
                }
            }
            catch (Exception ex)
            {
            }
            base.WndProc(ref m);
        }
        // form resizer functions
        public int TitleHeight()
        {
            int TitlebarHeight = this.Height - this.ClientSize.Height - (2 * BorderWidth());
            return TitlebarHeight;
        }
        public int BorderWidth()
        {
            int BorderWidth = (this.Width - this.ClientSize.Width) / 2;
            return BorderWidth;
        }
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // top height =110;
            int defaultHeight = TitleHeight() + cmdMainStart.Height + statusBar.Height + 16;
            switch (tabControl.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    cmdMainStart.Enabled = true;
                    this.Width = TabSizes[tabControl.SelectedIndex].Width + (BorderWidth() * 2);
                    this.Height = defaultHeight + TabSizes[tabControl.SelectedIndex].Height;
                    break;
                case 5:
                    cmdMainStart.Enabled = false;
                    this.Width = TabSizes[tabControl.SelectedIndex].Width + (BorderWidth() * 2);
                    this.Height = defaultHeight + TabSizes[tabControl.SelectedIndex].Height;
                    break;
                default:
                    break;
            }
        }

        // ========================================================
        // =================== TAB - KILL DUPES 
        // ========================================================
        private void optDupesSaveFile_CheckedChanged(object sender, EventArgs e)
        {
            txtDupesOutput.Enabled = optDupesOutput.Checked;
            cmdDupesOutput.Enabled = optDupesOutput.Checked;
        }
        public void SortList()
        {
            string inputFile = txtDupesInput.Text;
            string outputFile = inputFile;
            if (!RequireFile("Input File", inputFile, true)) return;
            if (optDupesOutput.Checked == true)
                outputFile = txtDupesOutput.Text;
            if (!RequireFile("Output File", outputFile, false)) return;
            bool killDupes = optDupesDupes.Checked;

            string lines = null, dupes = null;
            try
            {
                Status("Processing...");
                if (NpustWrapper.SortList(inputFile, outputFile, killDupes, out lines, out dupes, this.HandleStatusBar))
                {
                    if(killDupes)
                        Status("Success: Sorted {0} lines, {1} dupes", lines, dupes);
                    else
                        Status("Success: Sorted {0} lines", lines);
                }
                else
                    Status("Error: Unable to process list(s)");
            }
            catch (NpustWrapper.NpustWrapperException ex)
            {
                Status("Error: {0}", ex.Message);
            }
            finally
            {
                StatusProgress.Visible = false;
            }
        }

        // ========================================================
        // =================== TAB - MERGE FILES 
        // ========================================================
        public void HandleMergeListboxEvents()
        {
            lstMergeFiles.AllowDrop = true;
            lstMergeFiles.DragDrop += (object sender, DragEventArgs e) => {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                    foreach (string item in fileNames)
                    {
                        if (!lstMergeFiles.Items.Contains(item))
                            lstMergeFiles.Items.Add(item);
                    }
                    lblMergeFiles.Text = string.Format("Files to merge: {0}", lstMergeFiles.Items.Count);
                }
            };
            lstMergeFiles.DragEnter += (object sender, DragEventArgs e) => {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            };
            lstMergeFiles.DoubleClick += (object sender, EventArgs e) =>
            {
                var selectedItem = lstMergeFiles.SelectedItem;
                if (selectedItem == null) return;
                lstMergeFiles.Items.RemoveAt(lstMergeFiles.SelectedIndex);
                lblMergeFiles.Text = string.Format("Files to merge: {0}", lstMergeFiles.Items.Count);
            };
        }
        private void cmdMergeAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string[] files = FileChooser.LoadMulti("Text Files (*.txt)|*.txt|All Files (*.*)|*.*", null, "Choose Files to Merge");
                if (files == null)
                    return;

                foreach(string item in files)
                {
                    if(File.Exists(item) && !lstMergeFiles.Items.Contains(item))
                        lstMergeFiles.Items.Add(item);
                }
                lblMergeFiles.Text = string.Format("Files to merge: {0}", lstMergeFiles.Items.Count);
            }
            catch (Exception ex)
            {
            }
        }
        private void cmdMergeRemove_Click(object sender, EventArgs e)
        {
            var selectedItem = lstMergeFiles.SelectedItem;
            if (selectedItem == null) return;
            lstMergeFiles.Items.RemoveAt(lstMergeFiles.SelectedIndex);
            lblMergeFiles.Text = string.Format("Files to merge: {0}", lstMergeFiles.Items.Count);
        }
        public void MergeLists()
        {

            string outputFile = txtMergeOutput.Text;
            if (!RequireFile("Output File", outputFile, false)) return;

            List<string> files = new List<string>();
            foreach(string item in lstMergeFiles.Items)
            {
                files.Add(item);
            }
            if (files.Count < 2)
            {
                Status("Error: Select at least 2 files to merge");
                return;
            }
            foreach (string file in files)
            {
                if (!RequireFile("One of the merge files", (string)file, true)) return;
            }

            
            try
            {
                Status("Processing...");
                if (NpustWrapper.MergeFiles(files.ToArray(), outputFile, this.HandleStatusBar))
                    Status("Success: Merged {0} files", files.Count);
                else
                    Status("Error: Unable to process list(s)");
            }
            catch (NpustWrapper.NpustWrapperException ex)
            {
                Status("Error: {0}", ex.Message);
            }
            finally
            {
                StatusProgress.Visible = false;
            }
        }

        // ========================================================
        // =================== TAB - EXTRACT BLACKLIST 
        // ========================================================
        private void optBlacklistOutput_CheckedChanged(object sender, EventArgs e)
        {
            txtBlacklistOutput.Enabled = optBlacklistOutput.Checked;
            cmdBlacklistOutput.Enabled = optBlacklistOutput.Checked;
        }
        public void ExtractBlacklist()
        {
            string inputFile = txtBlacklistInput.Text;
            string blacklistFile = txtBlacklistBL.Text;
            string outputFile = inputFile;
            if (!RequireFile("Input File", inputFile, true)) return;
            if (!RequireFile("Blacklist File", blacklistFile, true)) return;
            if (optBlacklistOutput.Checked == true)
                outputFile = txtBlacklistOutput.Text;
            if (!RequireFile("Output File", outputFile, false)) return;

            try
            {
                int total = 0, cleaned = 0;
                Status("Processing...");
                StringComparison compareType = optBlacklistIgnoreCase.Checked ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
                if (SimpleListClean(inputFile, blacklistFile, outputFile, out total, out cleaned, compareType))
                    Status("Success: Extracted {0:n0} items from {1:n0} lines", total-cleaned, total);
                else
                    Status("Error: Unable to process list(s)");
            }
            catch (NpustWrapper.NpustWrapperException ex)
            {
                Status("Error: {0}", ex.Message);
            }
        }
        public static bool SimpleListClean(string inputFile, string blacklistFile, string outputFile, out int cntTotal, out int cntCleaned, StringComparison comparison)
        {
            cntCleaned = 0;
            cntTotal = 0;
            try
            {
                string[] data = File.ReadAllLines(inputFile);
                string[] blacklist = File.ReadAllLines(blacklistFile);
                string[] cleaned = data.Except(blacklist).ToArray();
                cntTotal = data.Count();
                cntCleaned = cleaned.Count();

                File.WriteAllLines(outputFile, cleaned);

                return true;
            }
            catch { return false; }
            finally
            {
            }
        }

        // ========================================================
        // =================== TAB - SPLIT LIST
        // ========================================================
        private void optSplitOutput_CheckedChanged(object sender, EventArgs e)
        {
            txtSplitOutput.Enabled = optSplitOutput.Checked;
            cmdSplitOutput.Enabled = optSplitOutput.Checked;
        }
        public void SplitList()
        {
            string inputFile = txtSplitInput.Text;
            string lineCount = txtSplitLines.Text;
            string outputFile = inputFile;
            if (!RequireFile("Input File", inputFile, true)) return;
            if (optSplitOutput.Checked == true)
                outputFile = txtSplitOutput.Text;
            if (!RequireFile("Output File", outputFile, false)) return;

            try
            {
                int lines = Int32.Parse(txtSplitLines.Text);
                if(lines < 0)
                {
                    Status("Error: Invalid line count value");
                    return;
                }

                string file_count = null;
                Status("Processing...");
                if (NpustWrapper.SplitFile(inputFile, outputFile, lines, out file_count, this.HandleStatusBar))
                    Status("Success: Split into {0} files", file_count);
                else
                    Status("Error: Unable to process list(s)");
            }
            catch (Exception ex)
            {
                Status("Error: {0}", ex.Message);
            }
        }

        // ========================================================
        // =================== TAB - RANDOMIZE 
        // ========================================================
        private void optRandoOutput_CheckedChanged(object sender, EventArgs e)
        {
            txtRandoOutput.Enabled = optRandoOutput.Checked;
            cmdRandoOutput.Enabled = optRandoOutput.Checked;
        }
        public void RandomizeFile()
        {
            string inputFile = txtRandoInput.Text;
            string outputFile = inputFile;
            if (!RequireFile("Input File", inputFile, true)) return;
            if (optRandoOutput.Checked == true)
                outputFile = txtRandoOutput.Text;
            if (!RequireFile("Output File", outputFile, false)) return;

            string lines = null;

            try
            {
                Status("Processing...");
                if(NpustWrapper.RandomizeFile(inputFile, outputFile, out lines, this.HandleStatusBar))
                    Status("Success: Randomized {0} lines", lines);
                else
                    Status("Error: Unable to process list(s)");
            }
            catch ( NpustWrapper.NpustWrapperException ex)
            {
                Status("Error: {0}", ex.Message);
            }
            finally
            {
                StatusProgress.Visible = false;
            }
        }

        // ========================================================
        // =================== TAB - SETTINGS 
        // ========================================================
        private void cndSettingsInstallContext_Click(object sender, EventArgs e)
        {
            try
            {
                if (!InstallContextMenuItems())
                    MessageBox.Show("Error creating context menu entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Security.SecurityException ex)
            {
                // need admin rights
                MessageBox.Show("Error: Could not create context menu entry, need Administrator privileges.  Launch the app as Administrator and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cndSettingsUnInstallContext_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UnInstallContextMenuItems())
                    MessageBox.Show("Error creating context menu entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Security.SecurityException ex)
            {
                // need admin rights
                MessageBox.Show("Error: Could not create context menu entry, need Administrator privileges.  Launch the app as Administrator and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // helper functions
        public static void EnableDragDrop(TextBox[] controls)
        {
            foreach (TextBox txt in controls)
            {
                EnableDragDrop(txt);
            }
        }
        public static void EnableDragDrop(TextBox control)
        {
            control.AllowDrop = true;
            control.DragDrop += (object sender, DragEventArgs e) => {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                    TextBox tb = (TextBox)sender;
                    tb.Text = fileNames[0];
                    tb.SelectionStart = tb.TextLength;
                }
            };
            control.DragEnter += (object sender, DragEventArgs e) => {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            };
        }
        public void SetFileLoader(Button btn, TextBox txt, string name)
        {
            btn.Click += (object sender, EventArgs e) =>
            {
                LoadFile(txt, name);
            };
        }
        public void Status(string status, params object[] args)
        {
            lblMainStatus.Text = string.Format(status, args);
        }
        public bool RequireFile(string name, string file, bool mustExist = false)
        {
            if (string.IsNullOrEmpty(file) || file.Trim() == "")
            {
                // file not properly set
                Status("Error: Choose {0}", name);
                //MessageBox.Show(string.Format("{0}: File not found\r{1}", name, file), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (mustExist && !File.Exists(file))
            {
                // file does not exist
                Status("Error: {0} not found", name);
                return false;
            }

            return true;
        }
        public bool LoadFile(TextBox txtbox, string name="File")
        {
            try
            {
                string file = FileChooser.Load("Text Files (*.txt)|*.txt|All Files (*.*)|*.*", null, "Choose " + name);
                if (file != null)
                {
                    txtbox.Text = file;
                    txtbox.SelectionStart = txtbox.TextLength;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool InstallContextMenuItems()
        {
            try
            {
                string thisExe = Application.StartupPath + "\\" + System.AppDomain.CurrentDomain.FriendlyName;
                string fixedPath = thisExe.Replace("\\", "\\\\");

                // create shell extension commands
                if (!Helpers.CreateShellExtension("ListMagic.Dupes", "Dedupe File", string.Format("\"{0}\" -a sort -i \"%1\" --killdupes --autorun --autoclose", fixedPath)))
                    return false;
                if (!Helpers.CreateShellExtension("ListMagic.Sort", "Sort File", string.Format("\"{0}\" -a sort -i \"%1\" --autorun --autoclose", fixedPath)))
                    return false;
                if (!Helpers.CreateShellExtension("ListMagic.Merge", "Merge Files", string.Format("\"{0}\" -a merge -i \"%1\"", fixedPath)))
                    return false;
                if (!Helpers.CreateShellExtension("ListMagic.Blacklist", "Extract Blacklist", string.Format("\"{0}\" -a blacklist -i \"%1\"", fixedPath)))
                    return false;
                if (!Helpers.CreateShellExtension("ListMagic.Split", "Split File", string.Format("\"{0}\" -a split -i \"%1\"", fixedPath)))
                    return false;
                if (!Helpers.CreateShellExtension("ListMagic.Randomize", "Randomize File", string.Format("\"{0}\" -a randomize -i \"%1\" --autorun --autoclose", fixedPath)))
                    return false;

                // create context menu entry
                if (!Helpers.CreateContextMenu("List Magic", fixedPath, "List Magic", "Middle", "ListMagic.Dupes;|;ListMagic.Sort;ListMagic.Randomize;ListMagic.Merge;ListMagic.Blacklist;ListMagic.Split"))
                    return false;

                return true;
            }
            catch (System.Security.SecurityException sex)
            {
                // need admin rights
                throw sex;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UnInstallContextMenuItems()
        {
            try
            {
                // remove all shell extension commands
                bool errors = false;
                if (!Helpers.DeleteShellExtension("ListMagic.Dupes"))
                    errors = true;
                if (!Helpers.DeleteShellExtension("ListMagic.Merge"))
                    errors = true;
                if (!Helpers.DeleteShellExtension("ListMagic.Blacklist"))
                    errors = true;
                if (!Helpers.DeleteShellExtension("ListMagic.Split"))
                    errors = true;
                if (!Helpers.DeleteShellExtension("ListMagic.Randomize"))
                    errors = true;

                // remove context menu entry
                if (!Helpers.DeleteContextMenu("List Magic"))
                    return false;

                //if (errors) return false;
                return true;
            }
            catch (System.Security.SecurityException sex)
            {
                // need admin rights
                throw sex;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void SwitchTab(int index)
        {
            tabControl.SelectedIndex = index;
            TabControl_SelectedIndexChanged(null, null);
        }



    }
}
