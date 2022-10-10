namespace Vurdalakov.Native
{
    using System;
    using System.Security.Principal;
    using System.Text;

    public partial class NativeProcess : NativeHandle
    {
        public Int32 Id { get; private set; } = -1;

        public Boolean Open(Int32 processId, UInt32 desiredAccess)
        {
            var handle = NativeMethods.OpenProcess(desiredAccess, false, (UInt32)processId);
            return this.SetHandle("OpenProcess", handle);
        }

        public String QueryFullProcessImageName()
        {
            var stringBuilder = new StringBuilder(NativeMethods.MAX_PATH);
            var size = (UInt32)stringBuilder.Capacity;

            return NativeMethods.QueryFullProcessImageName(this.Handle, 0, stringBuilder, ref size) ? stringBuilder.ToString() : null;
        }

        public NativeAccessToken OpenProcessToken(UInt32 desiredAccess) => NativeMethods.OpenProcessToken(this.Handle, desiredAccess, out var token) ? new NativeAccessToken(token) : null;

        public SecurityIdentifier GetProcessOwner()
        {
            using (var accessToken = this.OpenProcessToken(NativeMethods.TOKEN_QUERY))
            {
                using (var nativeMemory = accessToken.GetTokenInformation(NativeMethods.TOKEN_INFORMATION_CLASS.TokenUser))
                {
                    var tokemUser = nativeMemory.ToStructure<NativeMethods.TOKEN_USER>();
                    return new SecurityIdentifier(tokemUser.User.Sid);
                }
            }
        }
    }
}
