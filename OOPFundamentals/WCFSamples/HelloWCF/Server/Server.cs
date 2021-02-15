using System;
using System.ServiceModel;

namespace WCFSamples.HelloWCF.Server
{
	class Server
	{
		static void Main(string[] args)
		{
			Console.Title = "Server";
			
			Uri address = new Uri("http://localhost:4000/IContract"); // ADDRESS (A) - where to whait incoming messages
			var binding = new BasicHttpBinding();                     // BINDING (B) - how to exchange messages
			Type contract = typeof(IContract);                        // CONTRACT(C) - specifing contract

			var host = new ServiceHost(typeof(Service));			  // Host provider
			host.AddServiceEndpoint(contract, binding, address);	  // Endpoint	
			host.Open();                                              // Start address listenig

			Console.WriteLine("Application is ready to receive messages");
			Console.ReadKey();

			host.Close();                                             // Stop address listenig
		}
	}
}
