namespace Vurdalakov.Native
{
    using System;

    public class NativeAccessToken : NativeHandle
    {
        public NativeAccessToken(IntPtr token)
            : base(token)
        {
        }

        public NativeMemory GetTokenInformation(NativeMethods.TOKEN_INFORMATION_CLASS tokenInformationClass)
        {
            NativeMethods.GetTokenInformation(this.Handle, tokenInformationClass, IntPtr.Zero, 0, out var requiredSize);

            var nativeMemory = new NativeMemory(requiredSize);

            if (NativeMethods.GetTokenInformation(this.Handle, tokenInformationClass, nativeMemory, nativeMemory.Size, out _))
            {
                return nativeMemory;
            }
            else
            {
                NativeError.Trace("GetTokenInformation");
            }

            nativeMemory.Dispose();
            return null;
        }
    }
}
