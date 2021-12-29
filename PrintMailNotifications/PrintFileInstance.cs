using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintMailDto
{
    public record PrintFileInstance(int FileSize, string FilePath, int RecordCount)
    {
        // ToDo: make time-zone relevant times
        public DateTime ArrivalTime { get; internal set; } = DateTime.Now;

        // ToDo: We're reading the file twice, once in domain; once here.  See FileChannelReader
        public string RawText { get; internal set; } = File.Exists(FilePath) ? File.ReadAllText(FilePath) : string.Empty;
    }
}
