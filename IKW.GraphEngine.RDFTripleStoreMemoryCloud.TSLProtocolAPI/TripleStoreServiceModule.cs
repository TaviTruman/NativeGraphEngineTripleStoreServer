using System;
using InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL;
using Trinity;
using Trinity.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKW.GraphEngine.RDFTripleStoreMemoryCloud.TSLProtocolAPI
{
    public class TripleStoreServiceModule: TripleStoreMemoryCloudServiceModuleBase
    {
        public override string GetModuleName() => "TripleStoreServiceModule";

        public override void StoreTripleHandler(StoreTripleRequestReader request, StoreTripleResponseWriter response)
        {
            Console.WriteLine($"StoreTripleHandler reached: CellId: { request.m_cellId}, " +
                              $"Triple.Subject-Node: {request.Triple.Subject}");

            response = new StoreTripleResponseWriter(request.Triple);

        }

        public override void StoreTripleAsyncHandler(StoreTripleRequestReader request, StoreTripleResponseWriter response)
        {
            Console.WriteLine($"StoreTripleAsyncHandler reached: CellId: { request.m_cellId}, " +
                              $"Triple.Subject-Node: {request.Triple.Subject}");

            response = new StoreTripleResponseWriter(request.Triple);
        }
    }
}
