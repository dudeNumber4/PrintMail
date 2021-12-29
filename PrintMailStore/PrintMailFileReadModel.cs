using PrintMailDto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintMailStore
{

    /// <summary>
    /// Stub for readmodel that represents data table
    /// </summary>
    public class PrintMailFileReadModel: IReadModel
    {
        public PrintFileInstance FileInstance { internal get; set; }

        // Same props as in PrintFileInstance, but readmodel generally must have fields mapping to table.
        public string FileName { get; internal set; }
        public int RecordCount { get; internal set; }
        public int FileSize { get; internal set; }
        public DateTime ArrivalTime { get; set; }
        public string RawText { get; set; }

        public bool Apply()
        {
            var result = false;
            if (FileInstance != null)
            {
                try
                {
                    Persist();
                }
                catch (Exception e)
                {
                    Debug.Print($"Error persisting file details: ${e.Message}");
                }
            }
            return result;
        }

        private void Persist()
        {
            // ToDo: set properties and persist however this would utilize ORM, or simply write directly using ADO, etc.
            ;
        }

    }
}
