namespace Vurdalakov.Native
{
    using System;
    using System.Runtime.InteropServices;

    public partial class NativeProcessSnapshot : NativeHandle
    {
        public Boolean Create()
        {
            var snapshot = NativeMethods.CreateToolhelp32Snapshot(NativeMethods.TH32CS_SNAPPROCESS, 0);
            return this.SetHandle("CreateToolhelp32Snapshot", snapshot);
        }

        public Boolean EnumerateProcesses(Func<NativeProcessSnapshotEntry, Boolean> callback)
        {
            var processEntry = new NativeMethods.PROCESSENTRY32();
            processEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(NativeMethods.PROCESSENTRY32));

            if (!NativeMethods.Process32First(this.Handle, ref processEntry))
            {
                this.SetLastError("Process32First");
                return false;
            }

            while (true)
            {
                if (!callback(new NativeProcessSnapshotEntry(processEntry)))
                {
                    break;
                }

                if (!NativeMethods.Process32Next(this.Handle, ref processEntry))
                {
                    if (NativeMethods.ERROR_NO_MORE_FILES == this.LastError)
                    {
                        break;
                    }
                    else
                    {
                        this.SetLastError("Process32Next");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
