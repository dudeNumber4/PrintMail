using PrintMailDto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PrintMailStore
{
    
    public static class StoreController
    {

        public static async Task ReadFile(Channel<FileName> channel)
        {
            var reader = new FileChannelReader(channel);
            while (!reader.ReadyToRead())
                ;   //  ToDo: add timeout with log/return
            var result = await reader.TryRead();
            // Would pass stream to ORM.
            if (result == null)
                Debug.Print($"Error Processing file {result.name}");
            else
                Debug.Print($"File {result.name} processed");
        }

    }

}
