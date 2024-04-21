using System;
using System.Runtime.InteropServices;

namespace noconsole
{

    public class Program
    {
        static void Main(string[] args)
        {
            string windowsDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            string cmdExe = System.IO.Path.Combine(windowsDir, "System32\\cmd.exe");
            string prefix = cmdExe + " /c ";
            IntPtr gclIntPtr = NativeMethods.GetCommandLine();
            string commandLine = Marshal.PtrToStringAuto(gclIntPtr);
            NoConsole.CreateProcess(commandLine, prefix, true);
        }
    }
}
