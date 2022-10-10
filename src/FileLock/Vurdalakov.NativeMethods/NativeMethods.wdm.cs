namespace Vurdalakov.Native
{
    partial class NativeMethods
    {
        //https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_file_information_class
        public enum FILE_INFORMATION_CLASS
        {
            FileProcessIdsUsingFileInformation = 47,
        }
    }
}
