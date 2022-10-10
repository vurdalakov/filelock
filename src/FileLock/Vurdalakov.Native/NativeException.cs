namespace Vurdalakov.Native
{
    using System;
    using System.ComponentModel;

    public class NativeException : Win32Exception
    {
        public NativeException()
            : base()
        {
        }

        public NativeException(Int32 error)
            : base(error)
        {
        }

        public NativeException(Int32 error, String message)
            : base(error, message)
        {
        }

        public NativeException(String message)
            : base(message)
        {
        }

        public NativeException(UInt32 error)
            : base(unchecked((Int32)error))
        {
        }

        public NativeException(UInt32 error, String message)
            : base((Int32)error, message)
        {
        }
    }
}
