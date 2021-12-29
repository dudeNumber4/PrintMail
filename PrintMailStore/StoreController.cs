using PrintMailDto;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PrintMailStore
{
    
    public static class StoreController
    {

        public static async Task ReadFile(Channel<PrintFileInstance> channel)
        {
            var reader = new FileChannelReader(channel);
            while (!reader.ReadyToRead())
                ;   //  ToDo: add timeout with log/return
            PrintFileInstance result = await reader.TryRead();
            if (result == null)
                Debug.Print($"Error Processing file {result.FilePath}");
            else
            {
                if (Persist(result))
                    Debug.Print($"File [{result.FilePath}] processed");
                else
                    Debug.Print($"Unable to process file: [{result.FilePath}]");
            }
        }

        private static bool Persist(PrintFileInstance instance)
        {
            var readModel = GetReadModelInstance();
            (readModel as PrintMailFileReadModel).FileInstance = instance;
            return readModel.Apply();
        }

        /// ToDo: see Startup; is added to container, other objects in the object graph would have to additionally be added
        private static IReadModel GetReadModelInstance() => new PrintMailFileReadModel();

    }

}
