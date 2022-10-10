namespace Vurdalakov.Native
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    static partial class NativeFileLock
    {
        public static Int32[] FindProcesses(String filePath)
        {
            if (null == filePath)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            using (var nativeFile = new NativeFile())
            {
                if (Directory.Exists(filePath))
                {
                    if (!nativeFile.CreateFile(filePath, NativeMethods.GENERIC_READ | NativeMethods.GENERIC_WRITE, NativeMethods.FILE_SHARE_READ | NativeMethods.FILE_SHARE_WRITE, IntPtr.Zero,
                        NativeMethods.OPEN_EXISTING, NativeMethods.FILE_FLAG_BACKUP_SEMANTICS, IntPtr.Zero))
                    {
                        return null;
                    }
                }
                else
                {
                    if (!nativeFile.CreateFile(filePath, 0, NativeMethods.FILE_SHARE_READ | NativeMethods.FILE_SHARE_WRITE | NativeMethods.FILE_SHARE_DELETE, IntPtr.Zero,
                        NativeMethods.OPEN_EXISTING, NativeMethods.FILE_ATTRIBUTE_NORMAL, IntPtr.Zero))
                    {
                        return null;
                    }
                }

                using (var nativeMemory = new NativeMemory(0x10000))
                {
                    while (true)
                    {
                        if (nativeFile.NtQueryInformationFile(nativeMemory, NativeMethods.FILE_INFORMATION_CLASS.FileProcessIdsUsingFileInformation))
                        {
                            var ptr = nativeMemory.IntPtr;
                            var count = Marshal.ReadInt32(ptr);
                            ptr += 4;

                            var processIds = new Int32[count];

                            for (var i = 0; i < count; i++)
                            {
                                processIds[i] = Marshal.ReadInt32(ptr);
                                ptr += 4;
                            }

                            return processIds;
                        }

                        if (nativeFile.LastStatus != NativeMethods.STATUS_INFO_LENGTH_MISMATCH)
                        {
                            NativeError.Trace("NtQueryInformationFile", nativeFile.LastStatus);
                        }

                        nativeMemory.Double();
                    }
                }
            }
        }
    }
}
