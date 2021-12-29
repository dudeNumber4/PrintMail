using PrintMailDto;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PrintMailStore
{
    
    internal class FileChannelReader
    {

        private readonly Channel<PrintFileInstance> _channel;

        public FileChannelReader(Channel<PrintFileInstance> channel) => _channel = channel;

        // ToDo: utilize the channel to pass stream
        public async Task<PrintFileInstance> TryRead()
        {
            try
            {
                return await _channel.Reader.ReadAsync(CancellationToken.None);
            }
            catch (Exception ex)
            {
                // log
                Debug.Print(ex.Message);
                return null;
            }
        }

        public bool ReadyToRead(CancellationToken cancellationToken = default) => _channel.Reader.WaitToReadAsync(cancellationToken).IsCompleted;

    }

}
