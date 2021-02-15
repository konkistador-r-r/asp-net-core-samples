using System.ServiceModel;

namespace WCFSamples.HelloWCF.Server
{
	[ServiceContract]
	interface IContract
	{
		[OperationContract]
		void Say(string input);
		[OperationContract]
		string SayWithResponce(string input);
	}
}