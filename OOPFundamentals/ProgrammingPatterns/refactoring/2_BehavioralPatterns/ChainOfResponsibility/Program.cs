using System;
using ChainOfResponsibility.AnimalFeedChain;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample 1
            // The client should be able to send a request to any handler, not
            // just the first one in the chain.
            //Console.WriteLine("Chain: Monkey > Squirrel > Dog\n");
            //var monkey = AnimalFeedChainClient.SetUpAnimalFeedChain1();
            //AnimalFeedChainClient.ClientCode(monkey);
            //Console.WriteLine();

            //Console.WriteLine("Subchain: Squirrel > Dog\n");
            //var squirrel = AnimalFeedChainClient.SetUpAnimalFeedChain2();
            //AnimalFeedChainClient.ClientCode(squirrel);

            // Sample 2
            Console.WriteLine("Chain: Authentication > Authorization\n");
            var accessChain = CheckAccessChainClient.SetUpChain();
            CheckAccessChainClient.ClientCode(accessChain);
        }
    }
}
