using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace ListMagic
{
    public class WinAPI
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
        [DllImport("user32.dll")]
        public static extern long SetCursorPos(int x, int y);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int ShowWindow(IntPtr hWnd, int cmdShow);
        [DllImport("user32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);
        [DllImport("user32.dll")]
        public static extern Boolean EnumChildWindows(int hWndParent, Delegate lpEnumFunc, int lParam);
        [DllImport("user32.dll")]
        public static extern Int32 GetWindowText(int hWnd, StringBuilder s, int nMaxCount);
        [DllImport("user32.dll")]
        public static extern Int32 GetWindowTextLength(int hwnd);
        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        public static extern int GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, string lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, [Out] StringBuilder lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(int hWnd, int Msg, int wparam, int lparam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(int hWnd, int Msg, Byte wparam, int lparam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref COPYDATASTRUCT cds); 

        [DllImport("user32.dll", EntryPoint = "PostMessage")]
        public static extern IntPtr PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "PostMessage")]
        public static extern IntPtr PostMessage(int hWnd, int Msg, int wParam, string lParam);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, ref System.Drawing.Rectangle rect);
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool IsWindowEnabled(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool EnableWindow(IntPtr hwnd, bool bEnable);
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool EnumWindows(EnumWindowsProc callback, IntPtr extraData);
        [DllImport("user32.dll")]
        public static extern Int32 GetClassName(IntPtr hWnd, StringBuilder s, int nMaxCount);
        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, ref WinAPI.INPUT pInputs, int cbSize);
        [DllImport("user32.dll", EntryPoint = "WindowFromPoint", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr WindowFromPoint(System.Drawing.Point point);
        [DllImport("user32.dll")]
        public static extern int RegisterWindowMessage(string message);

        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_CLOSE = 0x10;
        public const int WM_CLICK = 0x00F5;
        public const int SW_SHOWNORMAL = 1;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_RESTORE = 9;
        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;
        public const int PBM_GETPOS = 0x0408;

        public const int WM_SETTEXT = 0x000C;
        public const int BM_SETCHECK = 0x00F1;
        public const int WM_SETFOCUS = 0x0007;
        public const int WM_GETTEXT = 0x000D;
        public const int WM_GETTEXTLENGTH = 0x000E;
        public const int WM_COMMAND = 0x0111;
        public const int BM_CLICK = 0x00F5;
        public const int LB_ADDSTRING = 0x0180;
        public const int LB_ADDFILE = 0x0196;
        public const int HWND_BROADCAST = 0xffff;
        public const int WM_COPYDATA = 0x4A;

        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            public int dwData;
            public int cbData;
            public int lpData;
        }
        public static class VirtualMouse
        {
            // import the necessary API function so .NET can
            // marshall parameters appropriately
            [DllImport("user32.dll")]
            static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

            // constants for the mouse_input() API function
            private const int MOUSEEVENTF_MOVE = 0x0001;
            private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
            private const int MOUSEEVENTF_LEFTUP = 0x0004;
            private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
            private const int MOUSEEVENTF_RIGHTUP = 0x0010;
            private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
            private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
            private const int MOUSEEVENTF_ABSOLUTE = 0x8000;

            // simulates movement of the mouse.  parameters specify changes
            // in relative position.  positive values indicate movement
            // right or down
            public static void Move(int xDelta, int yDelta)
            {
                mouse_event(MOUSEEVENTF_MOVE, xDelta, yDelta, 0, 0);
            }


            // simulates movement of the mouse.  parameters specify an
            // absolute location, with the top left corner being the
            // origin
            public static void MoveTo(int x, int y)
            {
                mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, x, y, 0, 0);
            }


            // simulates a click-and-release action of the left mouse
            // button at its current position
            public static void LeftClick()
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            }
            public static void LeftClick(int x, int y)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
            }
        }
        public static string GetClassName(IntPtr hWnd, int bufferSize = 1024)
        {
            StringBuilder buffer = new StringBuilder(bufferSize);
            GetClassName(hWnd, buffer, bufferSize);
            return buffer.ToString();
        }
        public static void Click(IntPtr hWnd)
        {
            SendMessage(hWnd, WM_LBUTTONDOWN, 1, IntPtr.Zero);
            SendMessage(hWnd, WM_LBUTTONUP, 1, IntPtr.Zero);
        }
        public static void ClickLeftMouseButton()
        {
            WinAPI.INPUT pInputs = new WinAPI.INPUT();
            pInputs.type = WinAPI.SendInputEventType.InputMouse;
            pInputs.mkhi.mi.mouseData = 0U;
            pInputs.mkhi.mi.dwFlags = WinAPI.MouseEventFlags.MOUSEEVENTF_LEFTDOWN;
            int num1 = (int)WinAPI.SendInput(1U, ref pInputs, Marshal.SizeOf((object)new WinAPI.INPUT()));
            pInputs.mkhi.mi.dwFlags = WinAPI.MouseEventFlags.MOUSEEVENTF_LEFTUP;
            int num2 = (int)WinAPI.SendInput(1U, ref pInputs, Marshal.SizeOf((object)new WinAPI.INPUT()));
        }
        [Flags]
        public enum MouseEventFlags : uint
        {
            MOUSEEVENTF_MOVE = 1U,
            MOUSEEVENTF_LEFTDOWN = 2U,
            MOUSEEVENTF_LEFTUP = 4U,
            MOUSEEVENTF_RIGHTDOWN = 8U,
            MOUSEEVENTF_RIGHTUP = 16U,
            MOUSEEVENTF_MIDDLEDOWN = 32U,
            MOUSEEVENTF_MIDDLEUP = 64U,
            MOUSEEVENTF_XDOWN = 128U,
            MOUSEEVENTF_XUP = 256U,
            MOUSEEVENTF_WHEEL = 2048U,
            MOUSEEVENTF_VIRTUALDESK = 16384U,
            MOUSEEVENTF_ABSOLUTE = 32768U,
        }
        public struct POINT
        {
            public int x;
            public int y;
        }
        public struct INPUT
        {
            public WinAPI.SendInputEventType type;
            public WinAPI.MouseKeybdhardwareInputUnion mkhi;
        }
        public enum SendInputEventType
        {
            InputMouse,
            InputKeyboard,
            InputHardware,
        }
        [StructLayout(LayoutKind.Explicit)]
        public struct MouseKeybdhardwareInputUnion
        {
            [FieldOffset(0)]
            public WinAPI.MouseInputData mi;
            [FieldOffset(0)]
            public WinAPI.KEYBDINPUT ki;
            [FieldOffset(0)]
            public WinAPI.HARDWAREINPUT hi;
        }
        public struct MouseInputData
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public WinAPI.MouseEventFlags dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        public struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        public struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        public static void Pause(int miliseconds)
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            Application.DoEvents();
            while (stopWatch.Elapsed.TotalMilliseconds < miliseconds)
            {
                Application.DoEvents();
            }
            stopWatch.Stop();
        }
    }
}
