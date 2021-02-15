using System.ServiceModel;

namespace WCFSamples.HelloWCF.Client
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