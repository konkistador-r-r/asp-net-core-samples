using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{


    public class TelephonicCommunicationSample
    {
        public static void Test()
        {
            Console.WriteLine(string.Format("----- {0} -----", "TelephonicCommunicationSample"));

            var crier = new Crier();

            // Create some people and assign the crier.
            var arya = new Person("Arya Stark", crier);
            var cersei = new Person("Cersei Lannister", crier);
            var daenerys = new Person("Daenerys Targaryen", crier);
            // Without a tongue it's difficult to speak, so Ilyn remains silent and listens.
            var ilyn = new Person("Ilyn Payne", crier);
            var tyrion = new Person("Tyrion Lannister", crier);

            // Send messages from respective characters.
            arya.Say("Valar morghulis.");
            tyrion.Say("Never forget what you are, for surely the world will not.");
            daenerys.Say("Men are mad and gods are madder.");
            cersei.Say("When you play the game of thrones, you win or you die. There is no middle ground.");

            Console.ReadLine();
        }
    }
}
