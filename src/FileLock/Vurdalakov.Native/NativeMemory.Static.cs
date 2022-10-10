namespace Vurdalakov.Native
{
    using System;
    using System.Runtime.InteropServices;

    partial class NativeMemory
    {
        // size of

        public static Int32 SizeOf<T>() => Marshal.SizeOf(typeof(T));

        // byte array

        public static Byte[] PtrToByteArray(IntPtr ptr, Int32 startIndex, Int32 length)
        {
            var offset = new IntPtr(ptr.ToInt64() + startIndex);
            return NativeMemory.PtrToByteArray(offset, length);
        }

        public static Byte[] PtrToByteArray(IntPtr ptr, Int32 length)
        {
            var array = new Byte[length];
            Marshal.Copy(ptr, array, 0, length);
            return array;
        }

        public static IntPtr ByteArrayToPtr(Byte[] array, Int32 startIndex, Int32 length)
        {
            var ptr = Marshal.AllocHGlobal(length);
            Marshal.Copy(array, startIndex, ptr, length);
            return ptr;
        }

        public static IntPtr ByteArrayToPtr(Byte[] array) => ByteArrayToPtr(array, 0, array.Length);

        // structure

        public static IntPtr StructureToPtr(Object structure, Boolean deleteOld = false)
        {
            var size = Marshal.SizeOf(structure);
            var ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(structure, ptr, deleteOld);
            return ptr;
        }

        public static T PtrToStructure<T>(IntPtr ptr) => (T)Marshal.PtrToStructure(ptr, typeof(T));

        // array of structures

        public static T[] PtrToArray<T>(IntPtr ptr, Int32 startIndex, Int32 length)
        {
            var array = new T[length];

            var size = NativeMemory.SizeOf<T>();
            var offset = ptr.ToInt64() + startIndex * size;

            for (var i = 0; i < length; i++)
            {
                var itemPtr = new IntPtr(offset);
                array[i] = Marshal.PtrToStructure<T>(itemPtr);
                offset += size;
            }

            return array;
        }

        public static T[] PtrToArray<T>(IntPtr ptr, Int32 length) => NativeMemory.PtrToArray<T>(ptr, 0, length);
    }
}
