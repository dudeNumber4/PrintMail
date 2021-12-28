using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using PrintMailDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintProcessService
{
    public class PrintFileProcessorService : PrintFileProcessor.PrintFileProcessorBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PrintFileProcessorService> _logger;
        
        public PrintFileProcessorService(ILogger<PrintFileProcessorService> logger, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public override Task<FileReply> Process(FileRequest request, ServerCallContext context)
        {
            try
            {
                _mediator.Publish(new PrintFileNotification(request.Name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Task.FromResult(new FileReply
            {
                Message = $"File [{request.Name}] has been submitted for processing."
            });
        }
    }
}
