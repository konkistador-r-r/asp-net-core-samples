using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFSamples.HelloWCF.Server
{
	class Service : IContract
	{
		// CONTRACT realization
		public void Say(string input)
		{
			Console.WriteLine("Message received, message body: {0}", input);
		}

		public string SayWithResponce(string input)
		{
			Console.WriteLine("Message received, message body: {0}", input);

			return "OK!";
		}
	}
}
