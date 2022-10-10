namespace Vurdalakov.Native
{
    using System;
    using System.IO;
    using System.Security.Principal;

    public partial class NativeProcessInfo
    {
        public Int32 Id { get; private set; } = -1;

        public String ProcessName { get; private set; }

        public Int32 ParentId { get; private set; }

        public String MainModuleFilePath { get; private set; }

        public SecurityIdentifier Owner { get; private set; }

        private NativeProcessInfo(NativeProcessSnapshotEntry nativeProcessSnapshotEntry)
        {
            this.Id = nativeProcessSnapshotEntry.ProcessID;
            this.ProcessName = Path.GetFileNameWithoutExtension(nativeProcessSnapshotEntry.ExecutableFilePath);
            this.ParentId = nativeProcessSnapshotEntry.ParentProcessID;

            using (var nativeProcess = new NativeProcess())
            {
                this.MainModuleFilePath = nativeProcess.Open(this.Id, NativeMethods.PROCESS_QUERY_LIMITED_INFORMATION) ? nativeProcess .QueryFullProcessImageName(): null;
                this.Owner = nativeProcess.GetProcessOwner();
            }
        }

        public static NativeProcessInfo GetProcessById(Int32 processId)
        {
            using (var snapshot = new NativeProcessSnapshot())
            {
                if (!snapshot.Create())
                {
                    return null;
                }

                NativeProcessInfo nativeProcessInfo = null;

                snapshot.EnumerateProcesses(process =>
                {
                    if (processId != process.ProcessID)
                    {
                        return true;
                    }

                    nativeProcessInfo = new NativeProcessInfo(process);

                    return false;
                });

                return nativeProcessInfo;
            }
        }
    }
}
