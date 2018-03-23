using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;


namespace DocumentDBPerson.repository
{
	public class Repository<IEntity> : IRepository<IEntity> where IEntity : class
	{
		private const string EndpointUri = "https://person-database.documents.azure.com:443/";
		private const string PrimaryKey = "MKIfr8B0zXcrM4GkcospYFF9loGIYHwEZCIKjjhdX3rXerV5xZlVw9QkfiNj6LHGTmZNwCApwHvnVhw9wMgbHA==";
		private DocumentClient _client;

		private readonly string _databaseId;

		private readonly AsyncLazy<Database> _database;
		private AsyncLazy<DocumentCollection> _collection;

		public Repository(DocumentClient dbClient, string databaseName)
		{
			_client = dbClient;
			_databaseId = databaseName;


			_database = new AsyncLazy<Database>(async () => await this._client.CreateDatabaseIfNotExistsAsync(new Database { Id = "PersonDB_oa" }));

			DocumentCollection collection = new DocumentCollection { Id = "PersonCollection_oa" };

			//setting index Policy to manuel so we can use PersonId as identifier
			collection.IndexingPolicy = new IndexingPolicy(new RangeIndex(DataType.String) { Precision = -1 });
			collection.IndexingPolicy.IndexingMode = IndexingMode.Consistent;
			//create Collection
			_collection = new AsyncLazy<DocumentCollection>(async () => await this._client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("PersonDB_oa"), collection));

		}
		
		public async IEntity Get(string id)
		{
			var retVal = await GetDocumentByIdAsync(id);
			return (IEntity)(dynamic)retVal;
		}

		public async IEnumerable<IEntity> GetAll()
		{
			var reply = new AsyncLazy<Database>(async () => _client.CreateDocumentQuery<IEntity>((await _collection).SelfLink).AsEnumerable());
			return reply;
		}

		public void Add(IEntity entity)
		{
			string reply = new AsyncLazy<Database>(async () => await this.CreatePersonDocumentIfNotExists(_databaseId, _collection, entity));
		}

		public void AddRange(IEnumerable<IEntity> entity)
		{
			foreach (var VARIABLE in entity)
			{
				string reply = new AsyncLazy<Database>(async () => await this.CreatePersonDocumentIfNotExists(_databaseId, _collection, VARIABLE));

			}
		}

		public async void Remove(IEntity entity, RequestOptions requestOptions = null)
		{

			var result = await _client.DeleteDocumentCollectionAsync((await _collection).SelfLink, requestOptions);

			bool isSuccess = result.StatusCode == HttpStatusCode.NoContent;

			_collection = new AsyncLazy<DocumentCollection>(async () => await GetOrCreateCollectionAsync());

		}

		public async void RemoveRange(IEnumerable<IEntity> entity)
		{
			foreach (var VARIABLE in entity)
			{
				var result = await _client.DeleteDocumentCollectionAsync((await _collection).SelfLink, VARIABLE));

			}
		}
	}
}