namespace Vurdalakov.Native
{
    using System;
    using System.Runtime.InteropServices;

    partial class NativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateToolhelp32Snapshot(UInt32 flags, UInt32 processID);

        public const UInt32 TH32CS_SNAPHEAPLIST = 0x00000001;
        public const UInt32 TH32CS_SNAPPROCESS = 0x00000002;
        public const UInt32 TH32CS_SNAPTHREAD = 0x00000004;
        public const UInt32 TH32CS_SNAPMODULE = 0x00000008;
        public const UInt32 TH32CS_SNAPMODULE32 = 0x00000010;
        public const UInt32 TH32CS_SNAPALL = TH32CS_SNAPHEAPLIST | TH32CS_SNAPPROCESS | TH32CS_SNAPTHREAD | TH32CS_SNAPMODULE;
        public const UInt32 TH32CS_INHERIT = 0x80000000;

        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESSENTRY32
        {
            public UInt32 dwSize;
            public UInt32 cntUsage;
            public UInt32 th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public UInt32 th32ModuleID;
            public UInt32 cntThreads;
            public UInt32 th32ParentProcessID;
            public Int32 pcPriClassBase;
            public UInt32 dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public String szExeFile;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Boolean Process32First(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Boolean Process32Next(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);
    }
}
