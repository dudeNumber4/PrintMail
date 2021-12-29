using PrintMailDto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintMailDomain
{
    public class StubPrintFileInstanceNotifier : IPrintFileInstanceNotifier
    {

        private string _transmission;  // ToDo: unsure of requirement here, where this originates.
        private int _recordCount;
        private string _emailAddress = "client@somebank.com";  // ToDo: unsure where this originates.
        private readonly DateTime _notificationTime = DateTime.Now;

        public void Configure(PrintFileInstance instance)
        {
            _transmission = instance.GetHashCode().ToString();
            _recordCount = instance.RecordCount;
        }

        public void Notify()
        {
            Console.WriteLine(NotificationMessage());
        }

        private string NotificationMessage()
        {
            Debug.Assert(!string.IsNullOrEmpty(_transmission));
            return $"PrintMail File Processed:{Environment.NewLine}Transmission: {_transmission}" +
                   $"{Environment.NewLine}Record Count: {_recordCount}{Environment.NewLine}Time: {_notificationTime.ToLongTimeString()}{Environment.NewLine}" +
                   $"Mailed to ${_emailAddress}";
        }
    }
}
