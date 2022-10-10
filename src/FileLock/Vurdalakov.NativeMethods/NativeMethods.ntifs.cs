namespace Vurdalakov.Native
{
    using System;
    using System.Runtime.InteropServices;

    partial class NativeMethods
    {
        [DllImport("ntdll.dll")]
        public static extern UInt32 NtQueryInformationFile(IntPtr fileHandle, ref IO_STATUS_BLOCK IoStatusBlock, IntPtr fileInformation, UInt32 length, Int32 fileInformationClass);
    }
}
