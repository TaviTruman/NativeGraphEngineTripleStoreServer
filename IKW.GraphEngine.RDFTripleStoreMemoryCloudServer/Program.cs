using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IKW.GraphEngine.RDFTripleStoreMemoryCloud.TSLProtocolAPI;
using Trinity;
using Trinity.Client.TrinityClientModule;
using Trinity.Network;
using InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL;

namespace IKW.GraphEngine.RDFTripleStoreMemoryCloudServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TrinityConfig.LoggingLevel = Trinity.Diagnostics.LogLevel.Debug;
            //TrinityConfig.LogEchoOnConsole = false;
            TrinityServer server = new TrinityServer();

            server.RegisterCommunicationModule<TrinityClientModule>();

            server.RegisterCommunicationModule<TripleStoreServiceModule>();

            server.Start();

            var myTriple =
                new Triple()
                {
                    GraphInstance = 0,
                    HashCode = 1,
                    Nodes = new System.Collections.Generic.List<INode>()
                    {
                        new INode()
                        {
                            GraphParent = 0,
                            GraphUri    = "http://www.inknowworks.semanticweb.ontology/persongraph",
                            HashCode    = 0,
                            TypeOfNode  = NodeType.GraphLiteral
                        }
                    }
                };

            var tripleCollection = new List<Triple> { myTriple };

            Graph myGraph = new Graph()
            {
                BaseUri = "http://www.inknowworks.semanticweb.ontology/",
                CellId = 0,
                TripleCollection = tripleCollection
            };

            Global.LocalStorage.SaveGraph(myGraph);

            //var clientModule = server.GetCommunicationModule<TrinityClientModule>();
            //var tripleStoreServiceModule = server.GetCommunicationModule<TripleStoreServiceModule>();

            while (true) Thread.Sleep(1000000);

        }
    }

}
