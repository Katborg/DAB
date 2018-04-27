using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DocumentDBPerson.repository;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;


namespace DocumentDBPerson
{
class Program
	{
	static void Main(string[] args)
	{
	}

	/*
	
		private const string EndpointUri = "https://person-database.documents.azure.com:443/";
		private const String PrimaryKey = "MKIfr8B0zXcrM4GkcospYFF9loGIYHwEZCIKjjhdX3rXerV5xZlVw9QkfiNj6LHGTmZNwCApwHvnVhw9wMgbHA==";


		static void Main(string[] args)
		{
			try
			{
				Program p = new Program();
				p.GetStarted().Wait();
			}
			catch (DocumentClientException de)
			{
				Exception baseException = de.GetBaseException();
				Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
			}
			catch (Exception e)
			{
				Exception baseException = e.GetBaseException();
				Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
			}
			finally
			{
				Console.WriteLine("End of demo, press any key to exit.");
				Console.ReadKey();
			}

		}
		private async Task GetStarted()
		{

			City oldmantown = new City() { Name = "Old Man Town", ZipCode = 9090 };
			City Youngmantown = new City() { Name = "yuong Man Town", ZipCode = 1090 };

			Person per = new Person("per", "Persen", "old man")
			{
				PersonId = "9", PAdress = 
					new Adress() { City = oldmantown, Number = "5", Street = "theStreet" }

			};
			Person Jasper = new Person("Jasper", "Man", "middel man")
			{
				PersonId = "7",
				PAdress =
					new Adress() { City = oldmantown, Number = "5", Street = "theStreet" }

			};
			Person chris = new Person("Chris", "toffer", "young man"){ PersonId = "1", PAdress = new Adress() { City = Youngmantown, Number = "105", Street = "anotherStreet" } };

			DocumentClient client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);

			PersonRepositry personRepository = new PersonRepositry();

			personRepository.Add(chris);
			personRepository.Add(per);
			personRepository.Add(Jasper);

			Person person1 = personRepository.Get(1);


			Console.WriteLine(person1);

		}*/
	}
}
