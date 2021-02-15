using System;
using System.ServiceModel;

namespace WCFSamples.HelloWCF.Client
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "Client";

			Uri address = new Uri("http://localhost:4000/IContract"); // ADDRESS (A) - where to whait incoming messages
			var binding = new BasicHttpBinding();                     // BINDING (B) - how to exchange messages

			//															 CONTRACT (C)- specifing contract
			var endpoint = new EndpointAddress(address);             // Endpoint
			var factory = new ChannelFactory<IContract>(binding, endpoint);
			IContract channel = factory.CreateChannel();			// Use Channel Factory to create channel (PROXY)

			channel.Say("Hello WCF!");								// use channel to send and receive messages

			var responce = channel.SayWithResponce("Hello with responce!");
			Console.WriteLine("Server responce: {0}", responce);
			Console.ReadKey();
		}
	}
}
