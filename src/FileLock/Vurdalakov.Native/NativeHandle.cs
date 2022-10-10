namespace Vurdalakov.Native
{
    using System;
    using System.Runtime.InteropServices;

    public partial class NativeHandle : NativeBase, IDisposable
    {
        public IntPtr Handle { get; private set; } = new IntPtr(NativeMethods.INVALID_HANDLE_VALUE);

        public Boolean IsHandleValid => this.Handle.ToInt32() != NativeMethods.INVALID_HANDLE_VALUE;

        public NativeHandle()
        {
        }

        public NativeHandle(IntPtr handle) => this.Handle = handle;

        protected Boolean SetHandle(String methodName, IntPtr handle)
        {
            this.Handle = handle;
            this.SetLastError(methodName, this.IsHandleValid ? 0 : Marshal.GetLastWin32Error());
            return this.IsHandleValid;
        }

        // IDisposable

        private Boolean _isDisposed;

        protected virtual void Dispose(Boolean disposing)
        {
            if (!this._isDisposed)
            {
                if (disposing)
                {
                    // dispose managed objects
                }

                // free unmanaged objects

                if (this.IsHandleValid)
                {
                    NativeMethods.CloseHandle(this.Handle);
                    this.Handle = new IntPtr(NativeMethods.INVALID_HANDLE_VALUE);
                }

                this._isDisposed = true;
            }
        }

        ~NativeHandle() => this.Dispose(disposing: false);

        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
