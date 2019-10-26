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
            TrinityConfig.LogEchoOnConsole = true;
            TrinityConfig.LogToFile = true;
            TrinityConfig.CurrentRunningMode = RunningMode.Server;
            TrinityConfig.ClientMaxConn = 1;

            TrinityServer server = new TrinityServer();

            server.RegisterCommunicationModule<TrinityClientModule>();
            server.RegisterCommunicationModule<TripleStoreServiceModule>();

            server.Start();

            var myTriple =
                new Triple()
                {
                    GraphInstance = 0,
                    Url           = "http://www.inknowworks.semanticweb.ontology/persongraph",
                    HashCode      = Trinity.Core.Lib.HashHelper.HashString2Int64(Guid.NewGuid().ToString()),
                    Nodes = new List<INode>()
                    {
                        new INode()
                        {
                            GraphParent = Trinity.Core.Lib.CellIdFactory.NewCellId(),
                            GraphUri    = "http://www.inknowworks.semanticweb.ontology/persongraph",
                            HashCode    = Trinity.Core.Lib.HashHelper.HashString2Int64("http://www.inknowworks.semanticweb.ontology/persongraph"),
                            TypeOfNode  = NodeType.GraphLiteral
                        }
                    },
                    ObjectNode = new INode()
                    {
                        GraphParent = 0,
                        GraphUri    = "http://www.inknowworks.semanticweb.ontology/persongraph",
                        HashCode    = Trinity.Core.Lib.HashHelper.HashString2Int64(Guid.NewGuid().ToString()),
                        TripleType  = TripleSegmentPart.Object,
                        TypeOfNode  = NodeType.Literal,
                    },
                    SubjectNode  = new INode()
                    {
                    GraphParent = 0,
                    GraphUri = "http://www.inknowworks.semanticweb.ontology/persongraph",
                    HashCode = Trinity.Core.Lib.HashHelper.HashString2Int64(Guid.NewGuid().ToString()),
                    TripleType = TripleSegmentPart.Subject,
                    TypeOfNode = NodeType.GraphLiteral
                    },
                    PredicateNode = new INode()
                    {
                        GraphParent = 0,
                        GraphUri = "http://www.inknowworks.semanticweb.ontology/persongraph",
                        HashCode = Trinity.Core.Lib.HashHelper.HashString2Int64(Guid.NewGuid().ToString()),
                        TripleType = TripleSegmentPart.Predicate,
                        TypeOfNode = NodeType.Literal,
                    }
                };

            var tripleCollection = new List<Triple> { myTriple };

            // New up a Graph Entity 

            Graph myGraph = new Graph()
            {
                BaseUri = "http://www.inknowworks.semanticweb.ontology/",
                CellId  = Trinity.Core.Lib.CellIdFactory.NewCellId(),
                TripleCollection = tripleCollection
            };

            myTriple.GraphInstance = myGraph.CellId;

            Global.CloudStorage.SaveGraph(myGraph);

            //int i = 0;

            //while (true)
            //{
            //    var client = clientModule.Clients.FirstOrDefault();

            //    Console.WriteLine($"{clientModule.Clients.Count()} clients");

            //    // Test to see if Client has connected

            //    if (client != null)
            //    {
            //        try
            //        {
            //            using (var msg = new S1Writer("foo", i++))
            //                client.P1(msg).ContinueWith(t =>
            //                {
            //                    using (var rsp = t.Result)
            //                    {
            //                        Console.WriteLine($"Client responded: {rsp.foo}, {rsp.bar}");
            //                    }
            //                }, TaskContinuationOptions.RunContinuationsAsynchronously);
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex.ToString());
            //            --i;
            //        }
            //    }
            //    Thread.Sleep(1000);
            //}

            //var clientModule = server.GetCommunicationModule<TrinityClientModule>();
            //var tripleStoreServiceModule = server.GetCommunicationModule<TripleStoreServiceModule>();

            while (true) Thread.Sleep(1000000);

        }
    }

}
