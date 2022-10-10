namespace Vurdalakov.Native
{
    using System;
    using System.ComponentModel;

    public static class NativeError
    {
        public static Win32Exception Trace(String methodName) => NativeError.Trace(methodName, new Win32Exception());

        public static Win32Exception Trace(String methodName, Int32 errorCode) => NativeError.Trace(methodName, new Win32Exception(errorCode));

        public static Win32Exception Trace(String methodName, UInt32 statusCode) => NativeError.Trace(methodName, new Win32Exception((Int32)statusCode));

        private static Win32Exception Trace(String methodName, Win32Exception ex)
        {
            var errorCode = ex.ErrorCode < 0 ? $"0x{ex.ErrorCode:X8}" : $"{ex.ErrorCode}";
            var message = $"Error: function '{methodName}' failed with error {errorCode} '{ex.Message}'";

            System.Diagnostics.Trace.WriteLine(message);
            Console.WriteLine(message);

            return ex;
        }
    }
}
