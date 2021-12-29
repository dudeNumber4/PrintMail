using static System.Console;
using System.Threading.Tasks;
using Grpc.Net.Client;
using PrintProcessClient;
using System;
using System.IO;

Console.WriteLine("Waiting for file to process...");
PrintMailFolderWatcher.Watch();

using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new PrintFileProcessor.PrintFileProcessorClient(channel);
FileReply fileReply = null;
try
{
    fileReply = await client.ProcessAsync(new FileRequest { Name = PrintMailFolderWatcher.FileName });
    WriteLine($"Response: {fileReply.Message}");
}
catch (Exception e)
{
    WriteLine($"Error encountered: ${e.Message}");
}
finally
{
    // would move to some processed location, etc.
    if (File.Exists(PrintMailFolderWatcher.FileName))
    {
        File.Delete(PrintMailFolderWatcher.FileName);
    }
}
WriteLine("Press any key to exit...");
ReadKey();