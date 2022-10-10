namespace Vurdalakov.Native
{
    using System;
    using System.Runtime.InteropServices;

    partial class NativeMethods
    {

        //  These are the generic rights.

        public const UInt32 GENERIC_WRITE = 0x40000000;
        public const UInt32 GENERIC_READ = 0x80000000;
        public const UInt32 GENERIC_EXECUTE = 0x20000000;
        public const UInt32 GENERIC_ALL = 0x10000000;

        [StructLayout(LayoutKind.Sequential)]
        public struct SID_AND_ATTRIBUTES
        {
            public IntPtr Sid;
            public UInt32 Attributes;
        }

        // Token Specific Access Rights.

        public const UInt32 TOKEN_ASSIGN_PRIMARY = 0x0001;
        public const UInt32 TOKEN_DUPLICATE = 0x0002;
        public const UInt32 TOKEN_IMPERSONATE = 0x0004;
        public const UInt32 TOKEN_QUERY = 0x0008;
        public const UInt32 TOKEN_QUERY_SOURCE = 0x0010;
        public const UInt32 TOKEN_ADJUST_PRIVILEGES = 0x0020;
        public const UInt32 TOKEN_ADJUST_GROUPS = 0x0040;
        public const UInt32 TOKEN_ADJUST_DEFAULT = 0x0080;
        public const UInt32 TOKEN_ADJUST_SESSIONID = 0x0100;

        // Token Information Classes.

        public enum TOKEN_INFORMATION_CLASS
        {
            TokenUser = 1,
            TokenGroups,
            TokenPrivileges,
            TokenOwner,
            TokenPrimaryGroup,
            TokenDefaultDacl,
            TokenSource,
            TokenType,
            TokenImpersonationLevel,
            TokenStatistics,
            TokenRestrictedSids,
            TokenSessionId,
            TokenGroupsAndPrivileges,
            TokenSessionReference,
            TokenSandBoxInert,
            TokenAuditPolicy,
            TokenOrigin,
            TokenElevationType,
            TokenLinkedToken,
            TokenElevation,
            TokenHasRestrictions,
            TokenAccessInformation,
            TokenVirtualizationAllowed,
            TokenVirtualizationEnabled,
            TokenIntegrityLevel,
            TokenUIAccess,
            TokenMandatoryPolicy,
            TokenLogonSid,
            TokenIsAppContainer,
            TokenCapabilities,
            TokenAppContainerSid,
            TokenAppContainerNumber,
            TokenUserClaimAttributes,
            TokenDeviceClaimAttributes,
            TokenRestrictedUserClaimAttributes,
            TokenRestrictedDeviceClaimAttributes,
            TokenDeviceGroups,
            TokenRestrictedDeviceGroups,
            TokenSecurityAttributes,
            TokenIsRestricted,
            TokenProcessTrustLevel,
            TokenPrivateNameSpace,
            TokenSingletonAttributes,
            TokenBnoIsolation,
            TokenChildProcessFlags,
            TokenIsLessPrivilegedAppContainer,
            TokenIsSandboxed,
            TokenOriginatingProcessTrustLevel,
            MaxTokenInfoClass
        }

        // Token information class structures

        [StructLayout(LayoutKind.Sequential)]
        public struct TOKEN_USER
        {
            public SID_AND_ATTRIBUTES User;
        }

        public const UInt32 PROCESS_CREATE_PROCESS = 0x0080;
        public const UInt32 PROCESS_CREATE_THREAD = 0x0002;
        public const UInt32 PROCESS_DUP_HANDLE = 0x0040;
        public const UInt32 PROCESS_QUERY_INFORMATION = 0x0400;
        public const UInt32 PROCESS_QUERY_LIMITED_INFORMATION = 0x1000;
        public const UInt32 PROCESS_SET_INFORMATION = 0x0200;
        public const UInt32 PROCESS_SET_QUOTA = 0x0100;
        public const UInt32 PROCESS_SUSPEND_RESUME = 0x0800;
        public const UInt32 PROCESS_TERMINATE = 0x0001;
        public const UInt32 PROCESS_VM_OPERATION = 0x0008;
        public const UInt32 PROCESS_VM_READ = 0x0010;
        public const UInt32 PROCESS_VM_WRITE = 0x0020;

        public const UInt32 FILE_SHARE_READ = 0x00000001;
        public const UInt32 FILE_SHARE_WRITE = 0x00000002;
        public const UInt32 FILE_SHARE_DELETE = 0x00000004;

        public const UInt32 FILE_ATTRIBUTE_READONLY = 0x00000001;
        public const UInt32 FILE_ATTRIBUTE_HIDDEN = 0x00000002;
        public const UInt32 FILE_ATTRIBUTE_SYSTEM = 0x00000004;
        public const UInt32 FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        public const UInt32 FILE_ATTRIBUTE_ARCHIVE = 0x00000020;
        public const UInt32 FILE_ATTRIBUTE_DEVICE = 0x00000040;
        public const UInt32 FILE_ATTRIBUTE_NORMAL = 0x00000080;
        public const UInt32 FILE_ATTRIBUTE_TEMPORARY = 0x00000100;
        public const UInt32 FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200;
        public const UInt32 FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400;
        public const UInt32 FILE_ATTRIBUTE_COMPRESSED = 0x00000800;
        public const UInt32 FILE_ATTRIBUTE_OFFLINE = 0x00001000;
        public const UInt32 FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000;
        public const UInt32 FILE_ATTRIBUTE_ENCRYPTED = 0x00004000;
        public const UInt32 FILE_ATTRIBUTE_INTEGRITY_STREAM = 0x00008000;
        public const UInt32 FILE_ATTRIBUTE_VIRTUAL = 0x00010000;
        public const UInt32 FILE_ATTRIBUTE_NO_SCRUB_DATA = 0x00020000;
        public const UInt32 FILE_ATTRIBUTE_EA = 0x00040000;
        public const UInt32 FILE_ATTRIBUTE_PINNED = 0x00080000;
        public const UInt32 FILE_ATTRIBUTE_UNPINNED = 0x00100000;
        public const UInt32 FILE_ATTRIBUTE_RECALL_ON_OPEN = 0x00040000;
        public const UInt32 FILE_ATTRIBUTE_RECALL_ON_DATA_ACCESS = 0x00400000;
    }
}
