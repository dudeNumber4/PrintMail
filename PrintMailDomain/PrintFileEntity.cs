using MediatR;
using PrintMailDto;
using PrintMailStore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PrintMailDomain
{

    public class PrintFileEntity: INotificationHandler<PrintFileNotification>
    {
        public const string FILE_LOCATION = @"C:\temp\PrintMailFiles";

        public async Task Handle(PrintFileNotification notification, CancellationToken cancellationToken)
            => await WriteFileAsync(notification.DTO, cancellationToken);

        public async ValueTask WriteFileAsync(FileName fileName, CancellationToken cancellationToken)
        {
            var channelWriter = new FileChannerWriter();
            while (await channelWriter.WaitToWriteAsync(cancellationToken))
            {
                if (channelWriter.TryWrite(fileName))
                {
                    await StoreController.ReadFile(channelWriter.ChannelForReading);
                    return;
                }
            }

            throw new Exception("Unable to write file to channel");
        }
    }
}
