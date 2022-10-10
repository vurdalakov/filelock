namespace Vurdalakov.Native
{
    using System;
    using System.Runtime.InteropServices;

    partial class NativeMethods
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern Boolean OpenProcessToken(IntPtr processHandle, UInt32 desiredAccess, out IntPtr tokenHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Boolean bInheritHandle, UInt32 dwProcessId);
    }
}
