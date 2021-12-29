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

        public async Task Handle(PrintFileNotification notification, CancellationToken cancellationToken)
            => await WriteFileAsync(notification.DTO, cancellationToken);

        public async ValueTask WriteFileAsync(FileName fileName, CancellationToken cancellationToken)
        {
            var channelWriter = new FileChannerWriter();
            while (await channelWriter.WaitToWriteAsync(cancellationToken))
            {
                var instance = GetInstance(fileName.name);
                if (channelWriter.TryWrite(instance))
                {
                    // pass to storage layer
                    await StoreController.ReadFile(channelWriter.ChannelForReading);
                    // ToDo: notifications would be another consumer of the channel.
                    var notifier = GetNotifier();
                    notifier.Configure(instance);
                    notifier.Notify();
                    return;
                }
            }

            throw new Exception("Unable to write file to channel");
        }

        private PrintFileInstance GetInstance(string filePath)
        {
            var fileProcessor = new PrintMailFileProcessor();
            var recordProcessor = new PrintMailRecordProcessor();
            fileProcessor.Process();
            var recordCollection = recordProcessor.Records;
            return new PrintFileInstance(fileProcessor.FileSize, filePath, recordCollection.Count);
        }

        // ToDo: plug into DI
        private IPrintFileInstanceNotifier GetNotifier() => new StubPrintFileInstanceNotifier();

    }
}
