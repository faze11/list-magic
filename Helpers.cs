using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace ListMagic
{
    public static class Helpers
    {
        public static bool CreateShellExtension(string commandName, string display, string command)
        {
            RegistryKey baseKey = null, shellKey = null, customKey = null, commandKey = null;
            try
            {
                baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                shellKey = baseKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);

                customKey = Helpers.OpenKey(shellKey, commandName);
                customKey.SetValue("", display);
                commandKey = Helpers.OpenKey(customKey, "command");
                commandKey.SetValue("", command);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (baseKey != null) baseKey.Close();
                if (shellKey != null) shellKey.Close();
                if (customKey != null) customKey.Close();
                if (commandKey != null) commandKey.Close();
            }
        }
        public static bool DeleteShellExtension(string commandName)
        {
            RegistryKey baseKey = null, shellKey = null;
            try
            {
                baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                shellKey = baseKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);

                if (!Helpers.RemoveKey(shellKey, commandName))
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (baseKey != null) baseKey.Close();
                if (shellKey != null) shellKey.Close();
            }
        }
        public static bool CreateContextMenu(string name, string icon, string verb, string position, string subcommands)
        {
            RegistryKey baseKey = null, shellKey = null, customKey = null;
            try
            {
                baseKey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64);
                shellKey = baseKey.OpenSubKey("*\\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);

                customKey = Helpers.OpenKey(shellKey, name);

                customKey.SetValue("Icon", icon, RegistryValueKind.String);
                customKey.SetValue("MUIVerb", verb, RegistryValueKind.String);
                customKey.SetValue("Position", position, RegistryValueKind.String);
                customKey.SetValue("SubCommands", subcommands, RegistryValueKind.String);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (baseKey != null) baseKey.Close();
                if (shellKey != null) shellKey.Close();
                if (customKey != null) customKey.Close();
            }
        }
        public static bool DeleteContextMenu(string name)
        {
            RegistryKey baseKey = null, shellKey = null;
            try
            {
                baseKey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64);
                shellKey = baseKey.OpenSubKey("*\\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);

                if (!Helpers.RemoveKey(shellKey, name))
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (baseKey != null) baseKey.Close();
                if (shellKey != null) shellKey.Close();
            }
        }
        public static RegistryKey OpenKey(RegistryKey master, string sub)
        {
            try
            {
                RegistryKey key = master.OpenSubKey(sub, RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                if (key == null)
                {
                    key = master.CreateSubKey(sub);
                    //key.Close();
                    //key = master.OpenSubKey(sub, true);
                }
                return key;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public static bool RemoveKey(RegistryKey master, string sub)
        {
            try
            {
                master.DeleteSubKeyTree(sub, false);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static void SendFileToOpenInstance(string message)
        {
            WinAPI.COPYDATASTRUCT cds;
            cds.dwData = 0;
            cds.lpData = (int)Marshal.StringToHGlobalAnsi(message);
            cds.cbData = message.Length;
            bool foundOne = false;

            while (foundOne == false)
            {
                foreach (Process p in Process.GetProcesses())
                {
                    if (p == Process.GetCurrentProcess()) continue;
                    if (p.MainWindowTitle.StartsWith("ListMagic"))
                    {
                        if (p.MainWindowHandle != IntPtr.Zero) foundOne = true;
                        WinAPI.SendMessage(p.MainWindowHandle, (int)WinAPI.WM_COPYDATA, IntPtr.Zero, ref cds);
                    }
                }
            }
        }
    }

    public class CommandLineArgs
    {
        public List<string> Options = new List<string>();
        public Dictionary<string, string> Params = new Dictionary<string, string>();
        public string GetParam(string key)
        {
            if (!Params.ContainsKey(key)) return null;
            return Params[key];
        }
        public bool Option(string option)
        {
            return Options.Contains(option);
        }
        public CommandLineArgs(string[] args)
        {
            string last_arg = null;
            foreach (string arg in args)
            {
                if(arg.StartsWith("--"))
                {
                    // option
                    Options.Add(arg.Substring(2));
                }
                else if (arg.StartsWith("-"))
                {
                    // is trigger
                    last_arg = arg.Substring(1);
                }
                else
                {
                    // is param
                    if (last_arg != null)
                    {
                        Params.Add(last_arg, arg);
                        last_arg = null;
                    }
                }
            }
        }
    }
}
