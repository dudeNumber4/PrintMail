using PrintMailDto;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintMailDomain
{
    public class PrintMailRecordProcessor
    {
        public PrintMailFileCollection Records { get; internal set; }

        public void Process(StringCollection rawRecords)
        {
            Records = new PrintMailFileCollection();  // ToDo: provide constructor with count
            foreach (var rawRecord in rawRecords)
            {
                Records.Add(Parse(rawRecord));
            }
        }

        private PrintMailRecord Parse(string rawRecord)
        {
            string[] fields = rawRecord.Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Debug.Assert(fields.Length == 3);
            return new PrintMailRecord(fields[0], fields[1], fields[2]);
        }

    }
}
