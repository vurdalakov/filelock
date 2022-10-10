namespace Vurdalakov.Native
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Security.Principal;

    internal class Program
    {
        static void Main(String[] args)
        {
            if (args.Length < 1)
            {
                var assembly = Assembly.GetCallingAssembly();
                Console.WriteLine($"{(assembly.GetCustomAttribute(typeof(AssemblyTitleAttribute)) as AssemblyTitleAttribute).Title} {assembly.GetName().Version} | {(assembly.GetCustomAttribute(typeof(AssemblyCopyrightAttribute)) as AssemblyCopyrightAttribute).Copyright} | https://github.com/vurdalakov/filelock");

                Console.WriteLine("(1) To show which process has locked a file or directory:");
                Console.WriteLine("    flock <file-or-directory-path>");
                Console.WriteLine("(2) To recursively find all locked files and directories:");
                Console.WriteLine("    flock -s");
                Console.WriteLine("    flock -s <directory-path>");

                return;
            }

            try
            {
                var arg0 = args[0];
                if ((2 == arg0.Length) && (('-' == arg0[0]) || ('/' == arg0[0])) && ('s' == Char.ToLowerInvariant(arg0[1])))
                {
                    FindLockedFiles(args.Length > 1 ? args[1] : Environment.CurrentDirectory);
                }
                else
                {
                    FindProcesses(arg0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
        }

        private static void FindProcesses(String path)
        {
            PrintPath(path);

            Int32[] processIds = null;

            processIds = NativeFileLock.FindProcesses(path);

            if (null == processIds)
            {
                Console.WriteLine("Cannot get process list");
                return;
            }

            if (0 == processIds.Length)
            {
                Console.WriteLine("Not locked");
                return;
            }

            PrintProcesses(processIds);
        }

        private static void FindLockedFiles(String directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);

            FindProcesses(directoryInfo);

            foreach (var fileSystemInfo in directoryInfo.EnumerateFileSystemInfos("*.*", SearchOption.AllDirectories))
            {
                FindProcesses(fileSystemInfo);
            }

            void FindProcesses(FileSystemInfo fileSystemInfo)
            {
                var processIds = NativeFileLock.FindProcesses(fileSystemInfo.FullName);

                if (processIds?.Length > 0)
                {
                    PrintPath(fileSystemInfo.FullName);
                    PrintProcesses(processIds);
                }
            }
        }

        private static void PrintPath(String path) => Console.WriteLine($"({(Directory.Exists(path) ? "Directory" : "File")}) {path}");

        private static void PrintProcesses(Int32[] processIds)
        {
            foreach (var processId in processIds)
            {
                var process = NativeProcessInfo.GetProcessById(processId);

                Console.WriteLine($"    {processId} '{process.ProcessName}' '{process.MainModuleFilePath}' '{process.Owner.Translate(typeof(NTAccount)).Value}'");
            }
        }
    }
}
