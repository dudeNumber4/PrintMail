using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService
{
    public class CustomerService : Customer.CustomerBase
    {
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerDataModel> GetCustomerInfo(CustomerFindModel request, ServerCallContext context)
        {
            CustomerDataModel result = new CustomerDataModel();

            // This is a sample code for demo
            // in real life scenarios this information should be fetched from the database
            // no data should be hardcoded in the application
            if (request.UserId == 1)
            {
                result.FirstName = "Mohamad";
                result.LastName = "Lawand";
            }
            else if (request.UserId == 2)
            {
                result.FirstName = "Richard";
                result.LastName = "Feynman";
            }
            else if (request.UserId == 3)
            {
                result.FirstName = "Bruce";
                result.LastName = "Wayne";
            }
            else
            {
                result.FirstName = "James";
                result.LastName = "Bond";
            }

            return Task.FromResult(result);
        }
    }
}
