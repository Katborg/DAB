using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using NuGet.Common;
using Microsoft.Azure.Documents.Linq;
using Database = Microsoft.Azure.Documents.Database;


namespace DocumentDBPerson.repository
{
    public class Repository<T> : IRepository<T> where T : class
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


            _client.CreateDatabaseIfNotExistsAsync(new Database { Id = _databaseId });
            _client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(_databaseId), new DocumentCollection { Id = _collectionId });
        }

        public T Get(int id)
        {
            try
            {
                Document document =
                    _client.ReadDocumentAsync(UriFactory.CreateDocumentUri(_databaseId, _collectionId, id.ToString())).Result;
                return (T)(dynamic)document;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
	            return null;
            }

        }


        public IEnumerable<T> GetAll()
        {
            IDocumentQuery<T> query = _client
                .CreateDocumentQuery<T>(UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId))
                .AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(query.ExecuteNextAsync<T>().Result);
            }

            return results;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            IDocumentQuery<T> query = _client
                .CreateDocumentQuery<T>(UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId))
                .Where(predicate).AsDocumentQuery();
            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(query.ExecuteNextAsync<T>().Result);
            }

            return results;
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            _client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId), entity);
        }


        public void AddRange(IEnumerable<T> e)
        {
            foreach (T p in e)
            {
                Add(p);
            }
        }


        public void Remove(T entity)
        {
            Person tmp = entity as Person;
            _client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(_databaseId, _collectionId, tmp.PersonId));
        }

        public void RemoveRange(IEnumerable<T> e)
        {

            foreach (T p in e)
            {
                Remove(p);
            }
        }

        
    }
}