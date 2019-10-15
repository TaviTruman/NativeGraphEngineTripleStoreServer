using System;
using System.Threading;
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

        static void Main(string[] args)
        {
            LoggingLevel = Trinity.Diagnostics.LogLevel.Debug;
            client       = new TrinityClient("localhost:5304");

            client.RegisterCommunicationModule<TripleStoreServiceModule>();
            //client.RegisterCommunicationModule<TrinityClientModule>();
            client.Start();

            var clientModule = client.GetCommunicationModule<TrinityClientModule>();

            var clientModuleInstance = clientModule.Clients;

            //client.P1(new S1Writer("Test", 100));

            var tctm = Global.CloudStorage.GetCommunicationModule<TripleStoreServiceModule>();

            tctm?.StoreTriple(0, new StoreTripleRequestWriter(new TripleStatement()
            {
                BaseUri = @"http:\\www.inknowworks.semanticweb\ontology",
                Subject = "GraphEngine",
                Predicate = "IsAwesome",
                Object = "DataManagementSystem"
            }));


            while (true) Thread.Sleep(1000000);
        }
    }
}
