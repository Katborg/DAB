using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using NuGet.Common;


namespace DocumentDBPerson.repository
{
	public class Repository<IEntity> : IRepository<IEntity> where IEntity : class
	{
		
		protected DocumentClient _client;

		protected readonly string _databaseId;
		protected readonly string _collectionId;

		protected readonly AsyncLazy<Database> _database;
		protected AsyncLazy<DocumentCollection> _collection;

		public Repository(DocumentClient dbClient, string databaseName, string collectionid)
		{
			
			_client = dbClient;
			_databaseId = databaseName;
			_collectionId = collectionid;

			_database = new AsyncLazy<Database>(async () => await this._client.CreateDatabaseIfNotExistsAsync(new Database { Id = "PersonDB_oa" }));

			DocumentCollection collection = new DocumentCollection { Id = _collectionId };

			//setting index Policy to manuel so we can use PersonId as identifier
			collection.IndexingPolicy = new IndexingPolicy(new RangeIndex(DataType.String) { Precision = -1 });
			collection.IndexingPolicy.IndexingMode = IndexingMode.Consistent;
			//create Collection
			_collection = new AsyncLazy<DocumentCollection>(async () => await this._client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("PersonDB_oa"), collection));

		}
		
		public async IEntity Get(string id)
		{
			var retVal = new AsyncLazy<Database>(async () => await GetDocumentByIdAsync(id));
			return (IEntity)(dynamic)retVal;
		}

		public async IEnumerable<IEntity> GetAll()
		{
			var reply = new AsyncLazy<Database>(async () => _client.CreateDocumentQuery<IEntity>((await _collection).SelfLink).AsEnumerable());
			return reply;
		}

		public virtual void Add(IEntity entity)
		{
			var reply = new AsyncLazy<Database>(async () => await this.CreatePersonDocumentIfNotExists(_databaseId, _collectionId, entity));
		}

		public void AddRange(IEnumerable<IEntity> entity)
		{
			foreach (var VARIABLE in entity)
			{
				var reply = new AsyncLazy<Database>(async () => await this.CreatePersonDocumentIfNotExists(_databaseId, _collectionId, VARIABLE));

			}
		}


		public virtual async void Remove(IEntity entity)
		{

			var docUri = UriFactory.CreateDocumentUri(_databaseId, _collection, entity.id);
			await _database.DeleteDocumentAsync(docUri);

			//var result = await _client.DeleteDocumentCollectionAsync((await _collection).SelfLink, null);

			//bool isSuccess = result.StatusCode == HttpStatusCode.NoContent;

			//_collection = new AsyncLazy<DocumentCollection>(async () => await GetOrCreateCollectionAsync());

		}

		public async void RemoveRange(IEnumerable<IEntity> entity)
		{
			foreach (var VARIABLE in entity)
			{
				var result = UriFactory.CreateDatabaseUri(_databaseId, _collection, VARIABLE);
				//await _client.DeleteDocumentCollectionAsync((await _collection).SelfLink, (RequestOptions)VARIABLE));

			}
		}

		protected async Task CreatePersonDocumentIfNotExists(string databaseName, string collectionName, IEntity entity)
		{
			try
			{
				await this._client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, entity.ToString()));
				//this.WriteToConsoleAndPromptToContinue("Found {0}", person.PersonId);
			}
			catch (DocumentClientException de)
			{
				if (de.StatusCode == HttpStatusCode.NotFound)
				{
					await this._client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), person);
					//this.WriteToConsoleAndPromptToContinue("Created Person {0}", person.PersonId);
				}
				else
				{
					throw;
				}
			}
		}
	}
}