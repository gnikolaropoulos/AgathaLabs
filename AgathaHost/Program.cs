using System;
using System.Configuration;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using Agatha.ServiceLayer;
using Agatha.ServiceLayer.WCF;
using Castle.Windsor;
using SoftwareBytes.AgathaHost;
using SoftwareBytes.AgathaMessages;

namespace Softwarebytes.AgathaHost
{
	class Program
	{
		static void Main(string[] args)
		{
			InitializeAgatha();
			Uri baseAddress = new Uri(ConfigurationManager.AppSettings["Address_Backend"]);
			ServiceHost host = new ServiceHost(typeof(WcfRequestProcessor),baseAddress);
			host.Open();

			String address = @"http://localhost:8080/";
			ServiceHost crossHost = new ServiceHost(typeof(CrossDomainService), new Uri(address));
			crossHost.AddServiceEndpoint(typeof(ICrossDomainService), new WebHttpBinding(), "").Behaviors.Add(new WebHttpBehavior());
			ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
			smb.HttpGetEnabled = true;
			crossHost.Description.Behaviors.Add(smb);
			crossHost.Open();
			Console.WriteLine("Server is up and running... Press any key to stop");
			Console.ReadKey();
			host.Close();
			crossHost.Close();
		}

		private static void InitializeAgatha()
		{
			new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(),
				typeof(EchoRequest).Assembly, new Agatha.Castle.Container(new WindsorContainer())).Initialize();
		}
	}
}
