using static System.Console;
using System.Threading.Tasks;
using Grpc.Net.Client;
using PrintProcessClient;

using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new PrintFileProcessor.PrintFileProcessorClient(channel);
var reply = await client.ProcessAsync(new FileRequest { Name = "1.txt" });
WriteLine($"Response: {reply.Message}");
WriteLine("Press any key to exit...");
ReadKey();