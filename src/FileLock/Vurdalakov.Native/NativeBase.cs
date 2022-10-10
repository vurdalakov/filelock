namespace Vurdalakov.Native
{
    using System;
    using System.Runtime.InteropServices;

    public abstract class NativeBase
    {
        public Int32 LastError { get; private set; } = NativeMethods.ERROR_SUCCESS;

        public UInt32 LastStatus { get; private set; } = NativeMethods.STATUS_SUCCESS;

        protected void SetLastError(String methodName) => this.SetLastError(methodName, Marshal.GetLastWin32Error());

        protected void SetLastError(String methodName, Int32 errorCode)
        {
            this.LastError = errorCode;

            if (this.LastError != NativeMethods.ERROR_SUCCESS)
            {
                NativeError.Trace(methodName, this.LastError);
            }
        }

        protected void SetLastStatus(String methodName, UInt32 statusCode)
        {
            this.LastStatus = statusCode;

            if (this.LastError != NativeMethods.STATUS_SUCCESS)
            {
                NativeError.Trace(methodName, this.LastStatus);
            }
        }
    }
}
