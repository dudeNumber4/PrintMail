using PrintMailDto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PrintMailDomain
{
    
    public class FileChannerWriter
    {

        private readonly Channel<PrintFileInstance> _channel = Channel.CreateUnbounded<PrintFileInstance>();
        public Channel<PrintFileInstance> ChannelForReading => _channel;

        /// <summary>
        /// Would write file stream to channel.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TryWrite(PrintFileInstance item) => _channel.Writer.TryWrite(item);

        /// <summary>
        /// Would normally ensure channel ready.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ValueTask<bool> WaitToWriteAsync(CancellationToken cancellationToken = default) => _channel.Writer.WaitToWriteAsync(cancellationToken);
    }

}
