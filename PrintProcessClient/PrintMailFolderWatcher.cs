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
            using var watcher = new FileSystemWatcher(PrintMailDto.PrintMailConstants.WATCH_DIR);
            watcher.Created += FileAdded;
        }

        private static void FileAdded(object sender, FileSystemEventArgs e) => _fileName = e.FullPath;

    }
}
