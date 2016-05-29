using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace RsExternalApi
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance. 
    /// </summary>
    internal sealed class RsExternalApi : StatelessService
    {
        public RsExternalApi(StatelessServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (like tcp, http) for this service instance.
        /// </summary>
        /// <returns>The collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(serviceContext => new OwinCommunicationListener(Startup.ConfigureApp, serviceContext, ServiceEventSource.Current, "ServiceEndpoint"))
            };
        }

        protected override Task RunAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult("");
            //cancellationToken.ThrowIfCancellationRequested();
            //List<Task> runners = new List<Task>();

            //foreach (ActorId id in this.actorIds)
            //{
            //    IVisualObjectActor actorProxy = ActorProxy.Create<IVisualObjectActor>(id, this.ActorServiceUri);

            //    Task t = Task.Run(
            //        async () =>
            //        {
            //            while (true)
            //            {
            //                cancellationToken.ThrowIfCancellationRequested();

            //                try
            //                {
            //                    this.objectBox.SetObjectString(id, await actorProxy.GetStateAsJsonAsync());
            //                }
            //                catch (Exception)
            //                {
            //                    // ignore the exceptions
            //                    this.objectBox.SetObjectString(id, string.Empty);
            //                }
            //                finally
            //                {
            //                    this.objectBox.computeJson();
            //                }

            //                await Task.Delay(TimeSpan.FromMilliseconds(10));
            //            }
            //        }
            //        ,
            //        cancellationToken);

            //    runners.Add(t);
            //}

            //return Task.WhenAll(runners);
        }
    }
}
