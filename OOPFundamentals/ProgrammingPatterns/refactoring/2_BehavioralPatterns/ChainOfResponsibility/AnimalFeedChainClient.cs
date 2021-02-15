using System;
using System.Collections.Generic;
using System.Text;
using ChainOfResponsibility.AnimalFeedChain;

namespace ChainOfResponsibility
{
    public class AnimalFeedChainClient
    {
        // The client code is usually suited to work with a single handler. In
        // most cases, it is not even aware that the handler is part of a chain.
        public static AbstractHandler SetUpAnimalFeedChain1()
        {
            // The other part of the client code constructs the actual chain.
            var monkey = new MonkeyHandler();
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();

            monkey.SetNext(squirrel).SetNext(dog);

            return monkey;
        }

        public static AbstractHandler SetUpAnimalFeedChain2()
        {
            // The other part of the client code constructs the actual chain.
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();

            squirrel.SetNext(dog);

            return squirrel;
        }

        // The client code is usually suited to work with a single handler. In
        // most cases, it is not even aware that the handler is part of a chain.
        public static void ClientCode(AbstractHandler handler)
        {
            foreach (var food in new List<string> { "Nut", "Banana", "Cup of coffee" })
            {
                Console.WriteLine($"Client: Who wants a {food}?");

                var result = handler.Handle(food);

                if (result != null)
                {
                    Console.Write($"   {result}");
                }
                else
                {
                    Console.WriteLine($"   {food} was left untouched.");
                }
            }
        }
    }
}
