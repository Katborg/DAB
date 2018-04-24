using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Handin22
{
   /* class Program
    {
		static void Main(string[] args)
		{
			using (var u = new UnitOfWork(new PersonContext()))
			{
				var PC = new Person("Chistoffer", "Broborg", "Student");
				var PS = new Person("Søren", "Katborg", "Student");
				var alborgBy = new City()
				{
					Name = "Alborg",
					ZipCode = 9000
				};

				var alborgadress = new Adress()
				{
					Street = "Ceresbyen",
					Number = "11A 2.1",
					City = alborgBy,

				};
				//Adding  primary adresses
				PC.PAdress = alborgadress;
				PS.PAdress = alborgadress;

				u.Persons.Add(PC);
				u.Persons.Add(PS);

				//Adding Adresses to db
				u.Adress.Add(alborgadress);
				//Adding cities to db
				u.Cities.Add(alborgBy);

				u.Complete();

				List<Person> personslist = (List<Person>) u.Persons.GetAll();

				foreach (var item in personslist)
				{
					Console.WriteLine($"{item.FirstName} {item.LastName}");
				}

				Console.ReadKey();
			}
		}



	  /*  static void Main(string[] args)
        {
            using (var db = new PersonContext())
            {
	            

				//Persons
/*				var P1 = new Person()
				 {
					 FirstName = "Chis",
					 MiddleName = "",
					 LastName = "Broberg",
					 Type = "Student"

				 };

				 var P2 = new Person()
				 {
					 FirstName = "Soeren",
					 MiddleName = "",
					 LastName = "Katborg",
					 Type = "Student"

				 };

				 var P3 = new Person()
				 {
					 FirstName = "Lars",
					 MiddleName = "Leksikon",
					 LastName = "Holm",
					 Type = "Student"
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
				 db.Persons.Add(P1);
				 db.Persons.Add(P2);
				 db.Persons.Add(P3);

				 //Adding Adresses to db
				 db.Adresses.Add(adress);
				 db.Adresses.Add(adress1);

				 //Adding Zipcodes to db
				 db.ZipCodes.Add(AarhusCZip);
				 db.ZipCodes.Add(AabenraaZip);

				 //Adding cities to db
				 db.Cities.Add(Aabenraa);
				 db.Cities.Add(Aarhus);
				
				 //Display persons
				 var Pquery = from b in db.Persons orderby b.FirstName select b;
				 Console.WriteLine("All persons in DB: ");
				 foreach (var item in Pquery)
				 {
					 Console.WriteLine(item.FirstName + item.LastName);
				 }

				 //Display Adresses
				 var Aquery = from b in db.Adresses orderby b.Street select b;
				 Console.WriteLine("All adresses in DB: ");
				 foreach (var item in Aquery)
				 {
					 Console.WriteLine(item.Street + item.Number);
				 }

	  //Display zipcodes
		var Zquery = from b in db.ZipCodes orderby b.City.Name select b  ;
				 Console.WriteLine("All persons in DB: ");
				 foreach (var item in Zquery)
				 {
					 Console.WriteLine(item.Zip + item.City);
				 }

				 //Display Cities
				 var Cquery = from b in db.Cities orderby b.Name select b;
				 Console.WriteLine("All Cities in DB: ");
				 foreach (var item in Cquery)
				 {
					 Console.WriteLine(item.Name + item.ZipCode);
				 }
				Console.ReadKey();
            }
        }
	*/
    //}
}
