using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using NuGet.Common;

namespace DocumentDBPerson.repository
{
	public class PersonRepositry : Repository<Person>, IPersonRepository
	{
		private static string dbID = "PersonDB_oa"; 
		private static string collectionID = "PersonCol";
		private const string EndpointUri = "https://person-database.documents.azure.com:443/";
		private const String PrimaryKey = "MKIfr8B0zXcrM4GkcospYFF9loGIYHwEZCIKjjhdX3rXerV5xZlVw9QkfiNj6LHGTmZNwCApwHvnVhw9wMgbHA==";
		private static readonly DocumentClient _client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);

		public PersonRepositry() : base(_client, dbID, collectionID)
        {

        }
    }
}
