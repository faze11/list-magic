using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ListMagic
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static Mutex MergeMutex = new Mutex(true, "{EC8B433E-96B8-4214-AC4A-434B4FD48D5B}");
        //public static int WM_SETMERGEFILENAME = WinAPI.RegisterWindowMessage("WM_SETMERGEFILENAME");
        [STAThread]
        static void Main(string[] args)
        {
            CommandLineArgs clargs = new CommandLineArgs(args);
            try
            {
                // check for merge list action
                if (clargs.GetParam("a") == "merge")
                {
                    // implement mutex
                    if (MergeMutex.WaitOne(TimeSpan.Zero, true))
                    {
                        // no other instances, continue as normal
                        RunApplication(clargs);
                        MergeMutex.ReleaseMutex();
                    }
                    else
                    {
                        // send input file to existing open instance 
                        string input_file = clargs.GetParam("i");
                        Helpers.SendFileToOpenInstance(input_file);

                        // exit 
                        return;
                    }
                }
                else
                {
                    // run application as normal
                    RunApplication(clargs);
                }
            }
            catch(Exception ex)
            {
                // master exception catch
                Debug.Print("Master Exception Caught: " + ex.Message);
            }
        }
        static void RunApplication(CommandLineArgs args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain(args));
        }
    }
}
