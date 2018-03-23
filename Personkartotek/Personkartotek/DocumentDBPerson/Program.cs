using System;
using System.Threading.Tasks;

using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace DocumentDBPerson
{
	class Program
	{
		

		static void Main(string[] args)
		{
			try
			{
				Program p = new Program();
				p.GetStartedDemo().Wait();
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
		private async Task GetStartedDemo()
		{
			this.client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);

			

			City oldmantown = new City() { Name = "Old Man Town", ZipCode = 9090 };
			City Youngmantown = new City() { Name = "yuong Man Town", ZipCode = 1090 };

			Person per = new Person("per", "Persen", "old man")
			{
				PersonId = "3", PAdress = 
					new Adress() { City = oldmantown, Number = "5", Street = "theStreet" }

			};
			Person chris = new Person("Chris", "toffer", "young man"){ PersonId = "1", PAdress = new Adress() { City = Youngmantown, Number = "105", Street = "anotherStreet" } };
			
			

		}
		private void WriteToConsoleAndPromptToContinue(string format, params object[] args)
		{
			Console.WriteLine(format, args);
			Console.WriteLine("Press any key to continue ...");
			Console.ReadKey();
		}

		private async Task CreatePersonDocumentIfNotExists(string databaseName, string collectionName, Person person)
		{
			try
			{
				await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, person.PersonId));
				this.WriteToConsoleAndPromptToContinue("Found {0}", person.PersonId);
			}
			catch (DocumentClientException de)
			{
				if (de.StatusCode == HttpStatusCode.NotFound)
				{
					await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), person);
					this.WriteToConsoleAndPromptToContinue("Created Person {0}", person.PersonId);
				}
				else
				{
					throw;
				}
			}
		}
	}
}
