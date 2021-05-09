using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using API;
using SRC;
using SRC.Ioc;
using SRC.LIB;
using System.ServiceModel;

namespace WCFWORKER
{
    public class WCFWorker : RoleEntryPoint
    {
        public override void Run()
        {
            while (true)
            {
                Thread.Sleep(10000);
                Trace.TraceInformation("Working");
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // Host the WCF
            CreateServiceHost();
            Trace.TraceInformation("WCFWORKER has started");

            return base.OnStart();
        }

        public override void OnStop()
        {
            base.OnStop();
            Trace.TraceInformation("WCFWORKER has stopped");
        }


        private void CreateServiceHost()
        {
            try
            {
                var container = new Container();
                var handler = container.Get<IHandlerCaller>();
                var animalService = new AnimalService(handler);
                ServiceHost serviceHost = new ServiceHost(animalService);


                // TODO: add some transport security for tcp.
                NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
                RoleInstanceEndpoint tcpEndPoint =
                    RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["TCPENDPOINT"];
                string tcpEndpoint = String.Format("net.tcp://{0}/AnimalService",
                    tcpEndPoint.IPEndpoint);
                serviceHost.AddServiceEndpoint(typeof(IAnimalService), binding, tcpEndpoint);


                serviceHost.Open();
                Trace.TraceInformation("Service is Running");
            }
            catch (Exception eX)
            {
                Trace.TraceInformation("Service can not be started Error Message [" + eX.Message + "]");

                // Also kill the worker.
                OnStop();
            }

        }
    }
}
