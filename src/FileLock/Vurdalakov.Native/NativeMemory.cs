namespace Vurdalakov.Native
{
    using System;
    using System.Runtime.InteropServices;

    public sealed partial class NativeMemory : IDisposable
    {
        public IntPtr IntPtr { get; private set; }

        public Int32 Size { get; private set; }

        public UInt32 USize => (UInt32)this.Size;

        public NativeMemory(Int32 memorySizeInBytes)
        {
            this.Size = memorySizeInBytes;
            this.IntPtr = Marshal.AllocHGlobal(this.Size);
        }

        public NativeMemory(UInt32 memorySizeInBytes)
            : this((Int32)memorySizeInBytes)
        {
        }

        public NativeMemory(Int64 memorySizeInBytes)
            : this((Int32)memorySizeInBytes)
        {
        }

        public NativeMemory(UInt64 memorySizeInBytes)
            : this((Int32)memorySizeInBytes)
        {
        }

        public NativeMemory(Type type)
            : this(Marshal.SizeOf(type))
        {
        }

        public void Dispose() => Marshal.FreeHGlobal(this.IntPtr);

        public Int32 ToInt32() => this.IntPtr.ToInt32();

        public Int64 ToInt64() => this.IntPtr.ToInt64();

        public String ToStringAnsi() => Marshal.PtrToStringAnsi(this.IntPtr);

        public String ToStringUni() => Marshal.PtrToStringUni(this.IntPtr);

        public Byte[] ToByteArray(Int32 startIndex, Int32 length) => NativeMemory.PtrToByteArray(this.IntPtr, startIndex, length);

        public Byte[] ToByteArray(Int32 length) => NativeMemory.PtrToByteArray(this.IntPtr, length);

        public T ToStructure<T>() => NativeMemory.PtrToStructure<T>(this.IntPtr);

        public T[] ToArray<T>(Int32 startIndex, Int32 length) => NativeMemory.PtrToArray<T>(this.IntPtr, startIndex, length);

        public T[] ToArray<T>(Int32 length) => NativeMemory.PtrToArray<T>(this.IntPtr, length);

        public static implicit operator IntPtr(NativeMemory NativeMemory) => NativeMemory.IntPtr;

        public void Resize(Int32 newSize)
        {
            if (this.Size != newSize)
            {
                Marshal.FreeHGlobal(this.IntPtr);

                this.Size = newSize;
                this.IntPtr = Marshal.AllocHGlobal(this.Size);
            }
        }

        public void Double() => this.Resize(this.Size * 2);
    }
}
