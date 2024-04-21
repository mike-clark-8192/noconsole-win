using System;
using System.Runtime.InteropServices;
using System.Text;

namespace noconsole
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct STARTUPINFO
    {
        public Int32 cb;
        public string lpReserved;
        public string lpDesktop;
        public string lpTitle;
        public Int32 dwX;
        public Int32 dwY;
        public Int32 dwXSize;
        public Int32 dwYSize;
        public Int32 dwXCountChars;
        public Int32 dwYCountChars;
        public Int32 dwFillAttribute;
        public Int32 dwFlags;
        public Int16 wShowWindow;
        public Int16 cbReserved2;
        public IntPtr lpReserved2;
        public IntPtr hStdInput;
        public IntPtr hStdOutput;
        public IntPtr hStdError;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_INFORMATION
    {
        public IntPtr hProcess;
        public IntPtr hThread;
        public int dwProcessId;
        public int dwThreadId;
    }

    /// <summary>
    /// Interop methods.
    /// </summary>
    public static class NativeMethods
    {
        #region Constants

        public static readonly IntPtr NullPtr = IntPtr.Zero;
        public static readonly IntPtr InvalidIntPtr = new IntPtr(-1);

        public const uint NORMAL_PRIORITY_CLASS = 0x0020;
        public const uint CREATE_NO_WINDOW = 0x08000000;
        public const Int32 STARTF_USESTDHANDLES = 0x00000100;
        public const int ERROR_SUCCESS = 0;

        #endregion

        //------------------------------------------------------------------------------
        // CloseHandle
        //------------------------------------------------------------------------------
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);

        //------------------------------------------------------------------------------
        // CreateProcess
        //------------------------------------------------------------------------------
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateProcess
        (
            string lpApplicationName,
            [In, Out] StringBuilder lpCommandLine,
            IntPtr lpProcessAttributes,
            IntPtr lpThreadAttributes,
            [In, MarshalAs(UnmanagedType.Bool)]
            bool bInheritHandles,
            uint dwCreationFlags,
            IntPtr lpEnvironment,
            string lpCurrentDirectory,
            [In] ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInformation
        );

        //------------------------------------------------------------------------------
        // GetCommandLine
        //------------------------------------------------------------------------------
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr GetCommandLine();

    }

    public static class NativeMessageBox
    {
        public static uint MB_ABORTRETRYIGNORE = 0x00000002;
        public static uint MB_CANCELTRYCONTINUE = 0x00000006;
        public static uint MB_HELP = 0x00004000;
        public static uint MB_OK = 0x00000000;
        public static uint MB_OKCANCEL = 0x00000001;
        public static uint MB_RETRYCANCEL = 0x00000005;
        public static uint MB_YESNO = 0x00000004;
        public static uint MB_YESNOCANCEL = 0x00000003;

        public static uint MB_ICONEXCLAMATION = 0x00000030;
        public static uint MB_ICONWARNING = 0x00000030;
        public static uint MB_ICONINFORMATION = 0x00000040;
        public static uint MB_ICONASTERISK = 0x00000040;
        public static uint MB_ICONQUESTION = 0x00000020;
        public static uint MB_ICONSTOP = 0x00000010;
        public static uint MB_ICONERROR = 0x00000010;
        public static uint MB_ICONHAND = 0x00000010;

        public static uint MB_DEFBUTTON1 = 0x00000000;
        public static uint MB_DEFBUTTON2 = 0x00000100;
        public static uint MB_DEFBUTTON3 = 0x00000200;
        public static uint MB_DEFBUTTON4 = 0x00000300;

        public static int IDABORT = 3;
        public static int IDCANCEL = 2;
        public static int IDCONTINUE = 11;
        public static int IDIGNORE = 5;
        public static int IDNO = 7;
        public static int IDOK = 1;
        public static int IDRETRY = 4;
        public static int IDTRYAGAIN = 10;
        public static int IDYES = 6;


        //------------------------------------------------------------------------------
        // MessageBox
        //------------------------------------------------------------------------------
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);
    }
}
