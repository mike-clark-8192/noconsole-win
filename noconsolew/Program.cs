using System;
using System.Runtime.InteropServices;

namespace noconsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            IntPtr gclIntPtr = NativeMethods.GetCommandLine();
            string commandLine = Marshal.PtrToStringAuto(gclIntPtr);
            NoConsole.CreateProcess(commandLine, null, true);
        }
    }
}
