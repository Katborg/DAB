using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personkartotek
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var Aarhus = new PostNumber(8000, "Århus C");
            IAdress street = new Adress("The Street", ref Aarhus);
            IAdress street2 = new Adress("The Street2", ref Aarhus);


            Person jasper = new Person("Jasper","", "Anderson","Friend",street);
            Person jonathan = new Person("Jonathan", "", "Anderson", "Friend", street);
            Person john = new Person("john", "", "Jepserson", "Friend", street2);


            jasper.Print();
            jonathan.Print();


            JoinPersonAdress.printList();

            JoinPersonAdress.CorrectAdress("The Street", "Street 5");

            jasper.AddAlternativeAdress(ref street2, "GirlFriend");

            jasper.Print();
            jonathan.Print();


            Console.WriteLine("\nwho lives at the Street 5:");
            var livesHere = JoinPersonAdress.GetAllAdresseOccupant(street);

            foreach (var VARIABLE in livesHere)
            {
                Console.WriteLine(VARIABLE.Person.Fornavn.ToString());
            }


            Console.WriteLine("\nwhat adresse are in postNumber 8000");
            var postlive = JoinPostNumberList.GetAllAdressesInPostNumber(Aarhus);
            foreach (var VARIABLE in postlive)
            {
                Console.WriteLine(VARIABLE.Adress.VejNavnOgNummer);
            }


            JoinPostNumberList.printList();
            
            Console.Read();

        }
    }
}
