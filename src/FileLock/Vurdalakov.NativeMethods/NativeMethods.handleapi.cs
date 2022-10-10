namespace Vurdalakov.Native
{
    using System;
    using System.Runtime.InteropServices;

    partial class NativeMethods
    {
        public const Int32 INVALID_HANDLE_VALUE = -1;

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Boolean CloseHandle(IntPtr hObject);
    }
}
