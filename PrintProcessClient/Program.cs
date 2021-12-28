using static System.Console;
using System.Threading.Tasks;
using Grpc.Net.Client;
using PrintProcessClient;
using System;

using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new PrintFileProcessor.PrintFileProcessorClient(channel);
FileReply fileReply = null;
try
{
    fileReply = await client.ProcessAsync(new FileRequest { Name = "1.txt" });
    WriteLine($"Response: {fileReply.Message}");
}
catch (Exception e)
{
    WriteLine($"Error encountered: ${e.Message}");
}
WriteLine("Press any key to exit...");
ReadKey();