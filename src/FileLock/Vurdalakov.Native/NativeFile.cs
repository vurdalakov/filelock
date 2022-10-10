namespace Vurdalakov.Native
{
    using System;

    public sealed class NativeFile : NativeHandle
    {
        public Boolean CreateFile(String filePath, UInt32 dwDesiredAccess, UInt32 dwShareMode, IntPtr lpSecurityAttributes, UInt32 dwCreationDisposition, UInt32 dwFlagsAndAttributes, IntPtr hTemplateFile)
        {
            var handle = NativeMethods.CreateFile(filePath, dwDesiredAccess, dwShareMode, lpSecurityAttributes, dwCreationDisposition, dwFlagsAndAttributes, hTemplateFile);
            return this.SetHandle("CreateFile", handle);
        }

        public Boolean NtQueryInformationFile(NativeMemory nativeMemory, NativeMethods.FILE_INFORMATION_CLASS fileInformationClass)
        {
            var statusBlock = new NativeMethods.IO_STATUS_BLOCK();
            this.SetLastStatus("NtQueryInformationFile", NativeMethods.NtQueryInformationFile(this.Handle, ref statusBlock, nativeMemory.IntPtr, nativeMemory.USize, (Int32)fileInformationClass));
            return NativeMethods.STATUS_SUCCESS == this.LastStatus;
        }
    }
}
