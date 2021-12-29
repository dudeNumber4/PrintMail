using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PrintMailDomain
{
    public class PrintMailFileProcessor
    {
        // actual records within the data file
        private StringCollection _records = new StringCollection();

        public string FilePath { internal get; set; }
        public int FileSize { get; internal set; }

        public PrintMailFileCollection Process()
        {
            Debug.Assert(!string.IsNullOrEmpty(FilePath));
            FileSize = File.ReadAllBytes(FilePath).Length; // ToDo move this into InitialSplit when that is no longer stubbed
            var records = InitialSplit();
            var recordProcessor = new PrintMailRecordProcessor();
            try
            {
                recordProcessor.Process(records);
            }
            catch (Exception ex)
            {
                // ToDo: log
                Debug.Print($"Error processing records: {ex.Message}");
            }
            return recordProcessor.Records;
        }

        private StringCollection InitialSplit()
        {
            var result = new StringCollection();
            // assumes no file is massive
            //foreach (var line in File.ReadAllLines(FilePath))
            //{

            //}
            // stub
            result.Add($"Henry Robinson${Environment.NewLine}123 Main St.${Environment.NewLine}22548");
            // next record
            result.Add($"Shishu Hador${Environment.NewLine}555 Pensylvania Ave.${Environment.NewLine}366887");
            return result;
        }

    }
}
