using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
namespace ListMagic
{
    class NpustWrapper
    {
        public class NpustWrapperException : Exception
        {
            public NpustWrapperException(string message) : base(message)
            {
            }
        }
        public static void KillProcessByName(string name)
        {
            foreach (var process in Process.GetProcessesByName(name))
            {
                process.Kill();
            }
        }
        public static bool SortList(string input_file, string output_file, bool killDupes, out string lines, out string dupes, Action<int> progressCallback = null)
        {
            if (output_file == null) output_file = input_file;
            lines = null;
            dupes = null;
            NpustWrapper npust = null;
            try
            {
                // open npust instance
                npust = new NpustWrapper(false);
                npust.Open(Application.StartupPath + "\\" + "npust.exe", true, true);
                if (npust.mainhWnd == IntPtr.Zero)
                {
                    // error launching npust
                    throw new NpustWrapperException("Unable to open Npust");
                }

                if (!npust.StartWizard())
                    throw new NpustWrapperException("Unable to begin wizard");

                if (killDupes)
                {
                    if (!npust.ChooseActions(ListActions.SingleListActions, ListActions.RearrangeList, ListActions.RemoveDuplicates))
                        throw new NpustWrapperException("Unable to set actions");
                }
                else
                {
                    if (!npust.ChooseActions(ListActions.SingleListActions, ListActions.RearrangeList))
                        throw new NpustWrapperException("Unable to set actions");
                }

                if (!npust.SetInputFile(input_file))
                    throw new NpustWrapperException("Unable to set input file");

                if (!npust.SetOutputFile(output_file))
                    throw new NpustWrapperException("Unable to set output file");

                if (!npust.SpecifyRearrangeMode(RearrangeMode.SortAlphabetically))
                    throw new NpustWrapperException("Unable to set rearrange mode");

                if (!npust.StartProcessing())
                    throw new NpustWrapperException("Unable to start processing");

                string npustResults = null;
                if (!npust.WaitForResult(out npustResults, (int progress) =>
                {
                    if (progressCallback != null) progressCallback.Invoke(progress);
                }))
                    throw new NpustWrapperException("Processing failed");

                if (!npust.Finish())
                    throw new NpustWrapperException("Unable to exit npust");

                // extract results
                if (killDupes)
                {
                    Match m = Regex.Match(npustResults, @"([0-9\,]+) email\(s\) sorted by entire email[\W]+([0-9\,]+) duplicate\(s\) found");

                    if (m == null || m.Groups.Count < 3)
                        return false;

                    lines = m.Groups[1].Value;
                    dupes = m.Groups[2].Value;

                    Debug.Print(string.Format("Done - {0} lines - {1} dupes", lines, dupes));
                }
                else
                {
                    Match m = Regex.Match(npustResults, @"([0-9\,]+) email\(s\) sorted by entire email");

                    if (m == null || m.Groups.Count < 2)
                        return false;

                    lines = m.Groups[1].Value;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool RandomizeFile(string input_file, string output_file, out string lines, Action<int> progressCallback = null)
        {
            if (output_file == null) output_file = input_file;
            lines = null;
            NpustWrapper npust = null;
            try
            {
                // open npust instance
                npust = new NpustWrapper(false);
                npust.Open(Application.StartupPath + "\\" + "npust.exe", true, true);
                if(npust.mainhWnd == IntPtr.Zero)
                {
                    // error launching npust
                    throw new NpustWrapperException("Unable to open Npust");
                }

                if(!npust.StartWizard())
                    throw new NpustWrapperException("Unable to begin wizard");

                if (!npust.ChooseActions(ListActions.SingleListActions, ListActions.RearrangeList))
                    throw new NpustWrapperException("Unable to set actions");

                if (!npust.SetInputFile(input_file))
                    throw new NpustWrapperException("Unable to set input file");

                if (!npust.SetOutputFile(output_file))
                    throw new NpustWrapperException("Unable to set output file");

                if (!npust.SpecifyRearrangeMode(RearrangeMode.Randomize))
                    throw new NpustWrapperException("Unable to set rearrange mode");

                if (!npust.StartProcessing())
                    throw new NpustWrapperException("Unable to start processing");

                string npustResults = null;
                if (!npust.WaitForResult(out npustResults, (int progress) =>
                {
                    if(progressCallback != null) progressCallback.Invoke(progress);
                }))
                    throw new NpustWrapperException("Processing failed");

                if (!npust.Finish())
                throw new NpustWrapperException("Unable to exit npust");

                Match m = Regex.Match(npustResults, @"([0-9\,]+) email\(s\) randomized");
                if (m == null || m.Groups.Count < 2)
                    return false;
                lines = m.Groups[1].Value;

                Debug.Print(string.Format("Done - Randomized {0} lines", lines));
                return true;
            }
            catch (NpustWrapperException ex)
            {
                // relay homemade exceptions
                if(npust != null) npust.Show();
                throw new NpustWrapperException(ex.Message);
            }
            catch (Exception ex)
            {
                // catch all other exceptions
                throw new NpustWrapperException("Uncaught exception: " + ex.Message);
            }
        }
        public static bool MergeFiles(string[] input_files, string output_file, Action<int> progressCallback = null)
        {
            NpustWrapper npust = null;
            try
            {
                // open npust instance
                npust = new NpustWrapper(false);
                npust.Open(Application.StartupPath + "\\" + "npust.exe", true, true);
                if (npust.mainhWnd == IntPtr.Zero)
                {
                    // error launching npust
                    throw new NpustWrapperException("Unable to open Npust");
                }

                if (!npust.StartWizard())
                    throw new NpustWrapperException("Unable to begin wizard");

                if (!npust.ChooseActions(ListActions.MergeLists))
                    throw new NpustWrapperException("Unable to set actions");

                
                if (!npust.SetMergeFiles(input_files, output_file))
                    throw new NpustWrapperException("Unable to set merge files");

                if (!npust.StartProcessing())
                    throw new NpustWrapperException("Unable to start processing");

                string npustResults = null;
                if (!npust.WaitForResult(out npustResults, (int progress) =>
                {
                    if (progressCallback != null) progressCallback.Invoke(progress);
                }))
                    throw new NpustWrapperException("Processing failed");

                if (!npust.Finish())
                    throw new NpustWrapperException("Unable to exit npust");

                return true;
            }
            catch (NpustWrapperException ex)
            {
                // relay homemade exceptions
                if (npust != null) npust.Show();
                throw new NpustWrapperException(ex.Message);
            }
            catch (Exception ex)
            {
                // catch all other exceptions
                throw new NpustWrapperException("Uncaught exception: " + ex.Message);
            }
        }
        public static bool SplitFile(string input_file, string output_file, int lines, out string file_count, Action<int> progressCallback = null)
        {
            if (output_file == null) output_file = input_file;
            file_count = null;
            NpustWrapper npust = null;
            try
            {
                // open npust instance
                npust = new NpustWrapper(false);
                npust.Open(Application.StartupPath + "\\" + "npust.exe", true, true);
                if (npust.mainhWnd == IntPtr.Zero)
                {
                    // error launching npust
                    throw new NpustWrapperException("Unable to open Npust");
                }

                if (!npust.StartWizard())
                    throw new NpustWrapperException("Unable to begin wizard");

                if (!npust.ChooseActions(ListActions.SingleListActions, ListActions.SplitList))
                    throw new NpustWrapperException("Unable to set actions");

                if (!npust.SetInputFile(input_file))
                    throw new NpustWrapperException("Unable to set input file");

                if (!npust.SetOutputFile(output_file))
                    throw new NpustWrapperException("Unable to set output file");

                if (!npust.SpecifySplitParameters(lines.ToString()))
                    throw new NpustWrapperException("Unable to set split parameters");

                if (!npust.StartProcessing())
                    throw new NpustWrapperException("Unable to start processing");

                string npustResults = null;
                if (!npust.WaitForResult(out npustResults, (int progress) =>
                {
                    if (progressCallback != null) progressCallback.Invoke(progress);
                }))
                    throw new NpustWrapperException("Processing failed");

                if (!npust.Finish())
                    throw new NpustWrapperException("Unable to exit npust");

                // extract results
                Match m = Regex.Match(npustResults, @"Email list was splitted into ([0-9\,]+) parts");
                if (m == null || m.Groups.Count < 2)
                    return false;
                file_count = m.Groups[1].Value;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IntPtr mainhWnd;
        public NpustWrapper(bool openInstance = true)
        {
            if (openInstance) this.Open();
        }

        public bool Open(string appPath = "npust.exe", bool killOpenWindows = true, bool hideGUI = true)
        {
            // return current window if already opened
            if (this.mainhWnd != IntPtr.Zero) return true;

            // kill all existing npusts for good measure
            try
            {
                if (killOpenWindows)
                {
                    NpustWrapper.KillProcessByName("npust");
                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                // launch process
                ProcessStartInfo startInfo = new ProcessStartInfo(appPath);
                Process p = Process.Start(startInfo);

                this.mainhWnd = p.MainWindowHandle;
                IntPtr mainWindow = IntPtr.Zero;
                while (this.mainhWnd == IntPtr.Zero || mainWindow == IntPtr.Zero)
                {
                    mainWindow = WinAPI.FindWindow("#32770", "Npust Email List Manager");
                    this.mainhWnd = p.MainWindowHandle;
                }

                // hide window so user doesnt have to see GUI
                if (hideGUI) this.Hide();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool StartWizard()
        {
            try
            {
                // location next button
                IntPtr nextbtn = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "Button", "&Next >");
                if (nextbtn == IntPtr.Zero)
                {
                    Debug.Print("Unable to locate next button");
                    return false;
                }

                // click next 
                Application.DoEvents();
                WinAPI.Click(nextbtn);
                Application.DoEvents();

                // wait for choose actions form to show
                IntPtr chooseActionsForm = IntPtr.Zero, singleListActions = IntPtr.Zero, filterList = IntPtr.Zero;
                while (chooseActionsForm == IntPtr.Zero || singleListActions == IntPtr.Zero || filterList == IntPtr.Zero)
                {
                    chooseActionsForm = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "#32770", "Npust Email List Manager - Choose Actions");
                    singleListActions = WinAPI.FindWindowEx(chooseActionsForm, IntPtr.Zero, "Button", "Single list actions");
                    filterList = WinAPI.FindWindowEx(chooseActionsForm, IntPtr.Zero, "Button", "Filter list (exclude specific emails)");
                    Application.DoEvents();
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool ChooseActions(params ListActions[] args)
        {
            try
            {
                // location choose actions form
                IntPtr chooseActionsForm = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "#32770", "Npust Email List Manager - Choose Actions");
                IntPtr singleListActions = WinAPI.FindWindowEx(chooseActionsForm, IntPtr.Zero, "Button", "Single list actions");
                IntPtr filterList = WinAPI.FindWindowEx(chooseActionsForm, IntPtr.Zero, "Button", "Filter list (exclude specific emails)");
                Application.DoEvents();

                if (chooseActionsForm == IntPtr.Zero || singleListActions == IntPtr.Zero || filterList == IntPtr.Zero)
                    return false;

                // locate all option checks
                Debug.Print("Setting options");

                IntPtr rearrangeList = WinAPI.FindWindowEx(chooseActionsForm, IntPtr.Zero, "Button", "Rearrange list (sort or randomize)");
                IntPtr removeDupes = WinAPI.FindWindowEx(chooseActionsForm, IntPtr.Zero, "Button", "Remove duplicates on sort");
                IntPtr includeEmail = WinAPI.FindWindowEx(chooseActionsForm, IntPtr.Zero, "Button", "Include specific email");
                IntPtr extractSublist = WinAPI.FindWindowEx(chooseActionsForm, IntPtr.Zero, "Button", "Extract random sublist");
                IntPtr splitList = WinAPI.FindWindowEx(chooseActionsForm, IntPtr.Zero, "Button", "Split list");
                IntPtr mergeLists = WinAPI.FindWindowEx(chooseActionsForm, IntPtr.Zero, "Button", "Merge lists into single list");

                // check selected options
                Application.DoEvents();
                WinAPI.SendMessage(singleListActions, WinAPI.BM_SETCHECK, args.Contains(ListActions.SingleListActions) ? 1 : 0, IntPtr.Zero);
                Application.DoEvents();
                WinAPI.SendMessage(filterList, WinAPI.BM_SETCHECK, args.Contains(ListActions.FilterList) ? 1 : 0, IntPtr.Zero);
                Application.DoEvents();
                WinAPI.SendMessage(rearrangeList, WinAPI.BM_SETCHECK, args.Contains(ListActions.RearrangeList) ? 1 : 0, IntPtr.Zero);
                Application.DoEvents();
                WinAPI.SendMessage(removeDupes, WinAPI.BM_SETCHECK, args.Contains(ListActions.RemoveDuplicates) ? 1 : 0, IntPtr.Zero);
                Application.DoEvents();
                WinAPI.SendMessage(includeEmail, WinAPI.BM_SETCHECK, args.Contains(ListActions.IncludeSpecificEmail) ? 1 : 0, IntPtr.Zero);
                Application.DoEvents();
                WinAPI.SendMessage(extractSublist, WinAPI.BM_SETCHECK, args.Contains(ListActions.ExtractSublist) ? 1 : 0, IntPtr.Zero);
                Application.DoEvents();
                WinAPI.SendMessage(splitList, WinAPI.BM_SETCHECK, args.Contains(ListActions.SplitList) ? 1 : 0, IntPtr.Zero);
                Application.DoEvents();
                WinAPI.SendMessage(mergeLists, WinAPI.BM_SETCHECK, args.Contains(ListActions.MergeLists) ? 1 : 0, IntPtr.Zero);
                Application.DoEvents();


                // click next
                IntPtr nextbtn = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "Button", "&Next >");
                Application.DoEvents();
                WinAPI.Click(nextbtn);
                Application.DoEvents();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool SetInputFile(string filename)
        {
            try
            {
                // wait for input file form
                IntPtr inputForm = IntPtr.Zero, input_file_edit = IntPtr.Zero;
                while (inputForm == IntPtr.Zero || input_file_edit == IntPtr.Zero)
                {
                    inputForm = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "#32770", "Npust Email List Manager - Specify Input Filename");
                    input_file_edit = WinAPI.FindWindowEx(inputForm, IntPtr.Zero, "Edit", "");
                    Application.DoEvents();
                }

                // set text
                Application.DoEvents();
                WinAPI.SendMessage(input_file_edit, WinAPI.WM_SETTEXT, 0, filename);
                Application.DoEvents();

                // click next
                IntPtr nextbtn = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "Button", "&Next >");
                Application.DoEvents();
                WinAPI.Click(nextbtn);
                Application.DoEvents();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SetOutputFile(string filename)
        {
            try
            {
                // wait for summary page
                IntPtr outputForm = IntPtr.Zero, output_file_edit = IntPtr.Zero;
                while (outputForm == IntPtr.Zero || output_file_edit == IntPtr.Zero)
                {
                    Application.DoEvents();
                    outputForm = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "#32770", "Npust Email List Manager - Specify Output Filename");
                    output_file_edit = WinAPI.FindWindowEx(outputForm, IntPtr.Zero, "Edit", "");
                    Application.DoEvents();
                }

                // set text
                Application.DoEvents();
                WinAPI.SendMessage(output_file_edit, WinAPI.WM_SETTEXT, 0, filename);
                Application.DoEvents();

                // next again
                IntPtr nextbtn = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "Button", "&Next >");
                Application.DoEvents();
                WinAPI.Click(nextbtn);
                Application.DoEvents();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SpecifyRearrangeMode(RearrangeMode mode)
        {
            try
            {
                // wait for rearrange form
                IntPtr rearrangeForm = IntPtr.Zero;
                IntPtr sortAlpha = IntPtr.Zero;

                while (rearrangeForm == IntPtr.Zero || sortAlpha == IntPtr.Zero)
                {
                    Application.DoEvents();
                    rearrangeForm = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "#32770", "Npust Email List Manager - Specify Rearrange Mode");
                    sortAlpha = WinAPI.FindWindowEx(rearrangeForm, IntPtr.Zero, "Button", "Sort alphabetically by entire email");
                    Application.DoEvents();
                }


                IntPtr sortDomain = WinAPI.FindWindowEx(rearrangeForm, IntPtr.Zero, "Button", "Sort alphabetically by domain, then by username");
                IntPtr sortRandom = WinAPI.FindWindowEx(rearrangeForm, IntPtr.Zero, "Button", "Randomize list");

                WinAPI.SendMessage(sortAlpha, WinAPI.BM_SETCHECK, mode == RearrangeMode.SortAlphabetically ? 1 : 0, IntPtr.Zero);
                WinAPI.SendMessage(sortDomain, WinAPI.BM_SETCHECK, mode == RearrangeMode.SortByDomain ? 1 : 0, IntPtr.Zero);
                WinAPI.SendMessage(sortRandom, WinAPI.BM_SETCHECK, mode == RearrangeMode.Randomize ? 1 : 0, IntPtr.Zero);

                // next again
                IntPtr nextbtn = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "Button", "&Next >");
                Application.DoEvents();
                WinAPI.Click(nextbtn);
                Application.DoEvents();

                // wait for summary page
                IntPtr summaryForm = IntPtr.Zero;
                while (summaryForm == IntPtr.Zero)
                {
                    Application.DoEvents();
                    summaryForm = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "#32770", "Npust Email List Manager - Summary Information");
                    Application.DoEvents();
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool StartProcessing()
        {
            try
            {
                IntPtr summaryPage = IntPtr.Zero, summaryLabel = IntPtr.Zero;
                while (summaryPage == IntPtr.Zero || summaryLabel == IntPtr.Zero)
                {
                    Application.DoEvents();
                    summaryPage = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "#32770", "Npust Email List Manager - Summary Information");
                    summaryLabel = WinAPI.FindWindowEx(summaryPage, IntPtr.Zero, "Static", "Summary Information");
                    Application.DoEvents();
                }

                // submit process
                IntPtr nextbtn = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "Button", "&Next >");
                Application.DoEvents();
                WinAPI.Click(nextbtn);
                Application.DoEvents();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool WaitForResult(out string results, Action<int> updateStatusCallback = null)
        {
            results = null;
            try
            {
                Debug.Print("Waiting for work to complete");
                IntPtr completeLbl = IntPtr.Zero;
                IntPtr donehWnd = IntPtr.Zero;
                IntPtr processingWin = IntPtr.Zero;
                IntPtr progressBar = IntPtr.Zero;
                while (donehWnd == IntPtr.Zero || completeLbl == IntPtr.Zero)
                {
                    if (updateStatusCallback != null)
                    {
                        // attempt to get status bar
                        processingWin = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "#32770", "Npust Email List Manager - Processing...");
                        if (processingWin != IntPtr.Zero)
                        {

                            progressBar = WinAPI.FindWindowEx(processingWin, IntPtr.Zero, "msctls_progress32", null);
                            if (progressBar != IntPtr.Zero)
                            {
                                int val = WinAPI.SendMessage(progressBar, WinAPI.PBM_GETPOS, 0, 0);
                                if (val < 0) val = 0;
                                if (val > 100) val = 100;
                                updateStatusCallback.Invoke(val);
                            }
                        }
                    }
                    donehWnd = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "#32770", "Npust Email List Manager");
                    completeLbl = WinAPI.FindWindowEx(donehWnd, IntPtr.Zero, "Static", "Completing the Npust\nEmail List Manager");
                    Application.DoEvents();
                    WinAPI.Pause(500);
                }
                // msctls_progress32

                // get response data
                IntPtr infohWnd = WinAPI.FindWindowEx(donehWnd, IntPtr.Zero, "Edit", null);
                int size = WinAPI.SendMessage((int)infohWnd, WinAPI.WM_GETTEXTLENGTH, 0, 0).ToInt32();
                StringBuilder info = new StringBuilder(size);
                WinAPI.SendMessage(infohWnd, WinAPI.WM_GETTEXT, size, info);

                results = info.ToString();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Finish()
        {
            try
            {
                // click finish
                IntPtr finishBtn = IntPtr.Zero;
                while(finishBtn == IntPtr.Zero)
                {
                    finishBtn = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "Button", "Finish");
                }
                Application.DoEvents();
                WinAPI.Click(finishBtn);
                Application.DoEvents();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SetMergeFiles(string[] filenames, string output_file)
        {
            try
            {
                // wait for input file form
                IntPtr mergeForm = IntPtr.Zero, input_listbox = IntPtr.Zero, output_edit = IntPtr.Zero;
                while (mergeForm == IntPtr.Zero || input_listbox == IntPtr.Zero || output_edit == IntPtr.Zero)
                {
                    mergeForm = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "#32770", "Npust Email List Manager - Specify Lists to Merge");
                    input_listbox = WinAPI.FindWindowEx(mergeForm, IntPtr.Zero, "ListBox", "");
                    output_edit = WinAPI.FindWindowEx(mergeForm, IntPtr.Zero, "Edit", "");
                    Application.DoEvents();
                }

                // add input files
                foreach (string file in filenames)
                {
                    Application.DoEvents();
                    WinAPI.SendMessage(input_listbox, WinAPI.LB_ADDSTRING, 0, file);
                    Application.DoEvents();
                }

                // set output file
                Application.DoEvents();
                WinAPI.SendMessage(output_edit, WinAPI.WM_SETTEXT, 0, output_file);
                Application.DoEvents();

                // click next
                IntPtr nextbtn = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "Button", "&Next >");
                Application.DoEvents();
                WinAPI.Click(nextbtn);
                Application.DoEvents();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SpecifySplitParameters(string lines)
        {
            try
            {
                // wait for input file form
                IntPtr splitForm = IntPtr.Zero, splitByNum = IntPtr.Zero, lines_edit = IntPtr.Zero;
                while (splitForm == IntPtr.Zero || splitByNum == IntPtr.Zero || lines_edit == IntPtr.Zero)
                {
                    splitForm = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "#32770", "Npust Email List Manager - Specify Split Parameters");
                    splitByNum = WinAPI.FindWindowEx(splitForm, IntPtr.Zero, "Button", "Split by number of emails");
                    lines_edit = WinAPI.FindWindowEx(splitForm, IntPtr.Zero, "Edit", null);
                    Application.DoEvents();
                }
                IntPtr splitBySize = WinAPI.FindWindowEx(splitForm, IntPtr.Zero, "Button", "Split by size");

                // check split by number of emails
                Application.DoEvents();
                WinAPI.SendMessage(splitByNum, WinAPI.BM_SETCHECK, 1, IntPtr.Zero);
                Application.DoEvents();
                WinAPI.SendMessage(splitBySize, WinAPI.BM_SETCHECK, 0, IntPtr.Zero);
                Application.DoEvents();

                // set emails in each part value
                Application.DoEvents();
                WinAPI.SendMessage(lines_edit, WinAPI.WM_SETTEXT, 0, lines);
                Application.DoEvents();

                // click next
                IntPtr nextbtn = WinAPI.FindWindowEx(this.mainhWnd, IntPtr.Zero, "Button", "&Next >");
                Application.DoEvents();
                WinAPI.Click(nextbtn);
                Application.DoEvents();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Show()
        {
            WinAPI.ShowWindow(this.mainhWnd, WinAPI.SW_SHOW);
        }
        public void Hide()
        {
            WinAPI.ShowWindow(this.mainhWnd, WinAPI.SW_HIDE);
        }
        public enum ListActions { SingleListActions, MergeLists, FilterList, RearrangeList, RemoveDuplicates, IncludeSpecificEmail, ExtractSublist, SplitList };
        public enum RearrangeMode { SortAlphabetically, SortByDomain, Randomize };
    }
}
