namespace Vurdalakov.Native
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    partial class NativeMethods
    {
        public const UInt32 FILE_FLAG_WRITE_THROUGH = 0x80000000;
        public const UInt32 FILE_FLAG_OVERLAPPED = 0x40000000;
        public const UInt32 FILE_FLAG_NO_BUFFERING = 0x20000000;
        public const UInt32 FILE_FLAG_RANDOM_ACCESS = 0x10000000;
        public const UInt32 FILE_FLAG_SEQUENTIAL_SCAN = 0x08000000;
        public const UInt32 FILE_FLAG_DELETE_ON_CLOSE = 0x04000000;
        public const UInt32 FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;
        public const UInt32 FILE_FLAG_POSIX_SEMANTICS = 0x01000000;
        public const UInt32 FILE_FLAG_SESSION_AWARE = 0x00800000;
        public const UInt32 FILE_FLAG_OPEN_REPARSE_POINT = 0x00200000;
        public const UInt32 FILE_FLAG_OPEN_NO_RECALL = 0x00100000;
        public const UInt32 FILE_FLAG_FIRST_PIPE_INSTANCE = 0x00080000;

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern Boolean QueryFullProcessImageName(IntPtr hProcess, UInt32 dwFlags, StringBuilder lpExeName, ref UInt32 lpdwSize);
    }
}
