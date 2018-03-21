using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Handin22
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new PersonContext())
            {
                //Persons
                var P1 = new Person()
                {
                    firstName = "Chis",
                    middleName = "",
                    lastName = "Broberg",
                    type = "Student"

                };

                var P2 = new Person()
                {
                    firstName = "Soeren",
                    middleName = "",
                    lastName = "Katborg",
                    type = "Student"

                };

                var P3 = new Person()
                {
                    firstName = "Lars",
                    middleName = "Leksikon",
                    lastName = "Holm",
                    type = "Student"
                };
                var personList = new List<Person>()
                {
                P1,P2,P3
                 };

                //ZipCodes
                var AarhusCZip = new ZipCode()
                {
                    Zip = "8000"
                };
                var AabenraaZip = new ZipCode()
                {
                    Zip = "6200"
                };
                //Cities
                var Aarhus = new City()
                {
                    Name = "Aarhus",
                    zipCode = AarhusCZip
                };
                var Aabenraa = new City()
                {
                    Name = "Aabenraa",
                    zipCode = AabenraaZip
                };
                AarhusCZip.City = Aarhus;
                AabenraaZip.City = Aabenraa;


                //Adresses
                var adress = new Adress()
                {
                    Street = "Ceresbyen",
                    Number = "11A 2.1",
                    City = Aarhus,
                    Persons = personList
                };

                var adress1 = new Adress()
                {
                    Street = "Norretoft",
                    Number = "25",
                    City = Aabenraa,
                    Persons = personList
                };

                var aAdresses = new List<Adress>()
                { adress, adress1};
                //Adding  primary adresses
                P1.PAdress = adress;
                P2.PAdress = adress;
                P3.PAdress = adress1;
                //Adding alternative adresses
                P1.AAdresses = aAdresses;
                P2.AAdresses = aAdresses;
                P3.AAdresses = aAdresses;

                //Adding people to db
                db.persons.Add(P1);
                db.persons.Add(P2);
                db.persons.Add(P3);

                //Adding Adresses to db
                db.adresses.Add(adress);
                db.adresses.Add(adress1);

                //Adding Zipcodes to db
                db.zipCodes.Add(AarhusCZip);
                db.zipCodes.Add(AabenraaZip);

                //Adding cities to db
                db.Cities.Add(Aabenraa);
                db.Cities.Add(Aarhus);

                //Display persons
                var Pquery = from b in db.persons orderby b.firstName select b;
                Console.WriteLine("All persons in DB: ");
                foreach (var item in Pquery)
                {
                    Console.WriteLine(item.firstName + item.lastName);
                }

                //Display Adresses
                var Aquery = from b in db.adresses orderby b.Street select b;
                Console.WriteLine("All adresses in DB: ");
                foreach (var item in Aquery)
                {
                    Console.WriteLine(item.Street + item.Number);
                }

                //Display zipcodes
                var Zquery = from b in db.zipCodes orderby b.City select b;
                Console.WriteLine("All persons in DB: ");
                foreach (var item in Zquery)
                {
                    Console.WriteLine(item.Zip + item.City);
                }

                //Display Cities
                var Cquery = from b in db.Cities orderby b.Name select b;
                Console.WriteLine("All persons in DB: ");
                foreach (var item in Cquery)
                {
                    Console.WriteLine(item.Name + item.zipCode);
                }
                Console.ReadKey();
            }
        }
        public class PersonContext : DbContext
        {
            public DbSet<Person> persons { get; set; }
            public DbSet<Adress> adresses { get; set; }
            public DbSet<ZipCode> zipCodes { get; set; }
            public DbSet<City> Cities { get; set; }

        }
    }
}
