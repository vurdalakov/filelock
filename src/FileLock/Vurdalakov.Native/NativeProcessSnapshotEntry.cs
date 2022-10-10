namespace Vurdalakov.Native
{
    using System;

    public class NativeProcessSnapshotEntry
    {
        public Int32 ProcessID { get; }

        public UInt32 NumberOfThreads { get; }

        public Int32 ParentProcessID { get; }

        public Int32 BasePriorityThread { get; }

        public String ExecutableFilePath { get; }

        internal NativeProcessSnapshotEntry(NativeMethods.PROCESSENTRY32 entry)
        {
            this.ProcessID = (Int32)entry.th32ProcessID;
            this.NumberOfThreads = entry.cntThreads;
            this.ParentProcessID = (Int32)entry.th32ParentProcessID;
            this.BasePriorityThread = entry.pcPriClassBase;
            this.ExecutableFilePath = entry.szExeFile;
        }
    }
}
