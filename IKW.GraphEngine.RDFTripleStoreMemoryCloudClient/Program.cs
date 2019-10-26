using System;
using System.Threading;
using System.Threading.Tasks;
using IKW.GraphEngine.RDFTripleStoreMemoryCloud.TSLProtocolAPI;
using Trinity.Client;
using InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL;
using InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL.TripleStoreMemoryCloudServiceModule;
using Trinity;
using Trinity.Client.TrinityClientModule;
using static Trinity.TrinityConfig;

namespace IKW.GraphEngine.RDFTripleStoreMemoryCloudClient
{
    class Program
    {
        private static TrinityClient client; 

        static async Task Main(string[] args)
        {
            LoggingLevel = Trinity.Diagnostics.LogLevel.Debug;
            client       = new TrinityClient("localhost:5304");

            client.RegisterCommunicationModule<TripleStoreServiceModule>();
            //client.RegisterCommunicationModule<TrinityClientModule>();
            client.Start();

            var clientModule = client.GetCommunicationModule<TrinityClientModule>();

            var clientModuleInstance = clientModule.Clients;

            var tctm = Global.CloudStorage.GetCommunicationModule<TripleStoreServiceModule>();

            while (true)
            {
                try
                {
                    var tripleStatement = new TripleStatement()
                    {
                        BaseUri = @"http:\\www.inknowworks.semanticweb\ontology",
                        Subject = "GraphEngine",
                        Predicate = "IsAwesome",
                        Object = "DataManagementSystem"
                    };

                    using (var message = new StoreTripleRequestWriter(tripleStatement))
                    using (var rsp = client.StoreTriple(message))
                    {
                        if (rsp != null) Console.WriteLine($"Server responses with rsp code={rsp.Triple.BaseUri}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                await Task.Delay(1000);
            }
        }
    }
}
