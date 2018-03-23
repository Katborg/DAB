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
	class PersonRepositry : Repository<Person>, IPersonRepository
	{
		public PersonRepositry(DocumentClient dbClient, string databaseName) : base(dbClient, databaseName)
		{
		}

		public override void Add(Person entity)
		{
			var reply = new AsyncLazy<Database>(async () => await this.CreatePersonDocumentIfNotExists(_databaseId, _collection, entity));
		}

		public override async void Remove(Person entity)
		{

			var result = await _client.DeleteDocumentCollectionAsync((await _collection).SelfLink, null);

			bool isSuccess = result.StatusCode == HttpStatusCode.NoContent;

			//_collection = new AsyncLazy<DocumentCollection>(async () => await GetOrCreateCollectionAsync());

		}
	}
}
