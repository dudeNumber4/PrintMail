using MediatR;
using System;

namespace PrintMailNotifications
{
    public class PrintFileNotification : INotification
    {
        private FileName _fileName;
        public PrintFileNotification(string fileName) => _fileName = new FileName(fileName);
    }
}
