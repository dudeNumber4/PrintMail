using MediatR;
using PrintMailNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrintMailDomain
{
    public class PrintFileEntity: INotificationHandler<PrintFileNotification>
    {
        public const string FILE_LOCATION = @"C:\temp\PrintMailFiles";

        public async Task Handle(PrintFileNotification notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return;
        }
    }
}
