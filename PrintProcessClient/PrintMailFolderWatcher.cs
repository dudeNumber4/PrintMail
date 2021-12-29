using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintProcessClient
{
    internal static class PrintMailFolderWatcher
    {
        private static string _fileName = string.Empty;

        internal static string FileName => _fileName;

        internal static void Watch()
        {
            while (Directory.EnumerateFiles(PrintMailDto.PrintMailConstants.WATCH_DIR, "*.DAT").Count() == 0)
            {
                Task.Delay(500);
            }
            _fileName = Directory.EnumerateFiles(PrintMailDto.PrintMailConstants.WATCH_DIR, "*.DAT").ToList()[0];

            // I just can't get the FileSystemWatcher to work

            //using var watcher = new FileSystemWatcher(PrintMailDto.PrintMailConstants.WATCH_DIR, "*.DAT");
            //watcher.NotifyFilter = NotifyFilters.Attributes
            //                     | NotifyFilters.CreationTime
            //                     | NotifyFilters.DirectoryName
            //                     | NotifyFilters.FileName
            //                     | NotifyFilters.LastAccess
            //                     | NotifyFilters.LastWrite
            //                     | NotifyFilters.Security
            //                     | NotifyFilters.Size;
            //watcher.EnableRaisingEvents = true;
            //watcher.Created += FileCreated;
            //watcher.Renamed += Watcher_Renamed;
        }

        //private static void Watcher_Renamed(object sender, RenamedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private static void FileCreated(object sender, FileSystemEventArgs e)
        //{
        //    _fileName = e.FullPath;
        //}

    }
}
