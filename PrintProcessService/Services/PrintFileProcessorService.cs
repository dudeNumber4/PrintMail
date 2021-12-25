using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintProcessService
{
    public class PrintFileProcessorService : PrintFileProcessor.PrintFileProcessorBase
    {
        private readonly ILogger<PrintFileProcessorService> _logger;
        public PrintFileProcessorService(ILogger<PrintFileProcessorService> logger)
        {
            _logger = logger;
        }

        public override Task<FileReply> Process(FileRequest request, ServerCallContext context)
        {
            return Task.FromResult(new FileReply
            {
                Message = $"File [{request.Name}] has been processed"
            });
        }
    }
}
