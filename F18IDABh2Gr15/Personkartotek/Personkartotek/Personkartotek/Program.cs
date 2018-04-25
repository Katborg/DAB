using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Personkartotek
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
               // IPostNumberList postNumberList;
                var Aarhus = new PostNumber(8000, "Århus C");
                var Aabenraa = new PostNumber(6200, "Aabenraa");
                //postNumberList.City = Aarhus;


                IAdress street  = new Adress("The Street", ref Aabenraa);
                IAdress street1 = new Adress("The Street1", ref Aabenraa);
                IAdress street2 = new Adress("The Street2", ref Aarhus);
                IAdress street3 = new Adress("The Street3", ref Aarhus);

                Person Jens = new Person("Jens", "", "Jaltesen", "Friend", street);
                Person Jarl = new Person("Jarl", "", "Jensen", "Friend", street1);
                Person jasper = new Person("Jasper", "", "Anderson", "Friend", street2);
                Person jonathan = new Person("Jonathan", "", "Anderson", "Friend", street2);
                Person john = new Person("john", "", "Jepserson", "Friend", street3);


            }
        }
        //static void Main(string[] args)
        //{

        //    var Aarhus = new PostNumber(8000, "Århus C");
        //    IAdress street = new Adress("The Street", ref Aarhus);
        //    IAdress street2 = new Adress("The Street2", ref Aarhus);


        //    Person jasper = new Person("Jasper","", "Anderson","Friend",street);
        //    Person jonathan = new Person("Jonathan", "", "Anderson", "Friend", street);
        //    Person john = new Person("john", "", "Jepserson", "Friend", street2);


        //    jasper.Print();
        //    jonathan.Print();


        //    JoinPersonAdress.printList();

        //    JoinPersonAdress.CorrectAdress("The Street", "Street 5");

        //    jasper.AddAlternativeAdress(ref street2, "GirlFriend");

        //    jasper.Print();
        //    jonathan.Print();


        //    Console.WriteLine("\nwho lives at the Street 5:");
        //    var livesHere = JoinPersonAdress.GetAllAdresseOccupant(street);

        //    foreach (var VARIABLE in livesHere)
        //    {
        //        Console.WriteLine(VARIABLE.Person.Fornavn.ToString());
        //    }


        //    Console.WriteLine("\nwhat adresse are in postNumber 8000");
        //    var postlive = JoinPostNumberList.GetAllAdressesInPostNumber(Aarhus);
        //    foreach (var VARIABLE in postlive)
        //    {
        //        Console.WriteLine(VARIABLE.Adress.VejNavnOgNummer);
        //    }


        //    JoinPostNumberList.printList();

        //    Console.Read();

        //}

        public class BloggingContext : DbContext
        {
            public DbSet<IAdress> Adresses { get; set; }
            public DbSet<Person> Persons { get; set; }
            public DbSet<PostNumber> PostNumbers { get; set; }
            public DbSet<ITelefone> Phones { get; set; }

        }
    }
}
