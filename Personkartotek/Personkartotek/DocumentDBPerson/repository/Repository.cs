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

        }

        public async Task<T> Get(string id)
        {
            //var retVal = new AsyncLazy<Database>(async () => await GetDocumentByIdAsync(id));
            var retVal = await GetDocumentByIdAsync(id);
            return (T)(dynamic)retVal;
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            //var reply = new AsyncLazy<Database>(async () => _client.CreateDocumentQuery<IEntity>((await _collection).SelfLink).AsEnumerable());
            var reply = _client.CreateDocumentQuery<T>((await _collection).SelfLink).AsEnumerable();
            return reply;
        }

        public virtual void Add(T entity)
        {
            var reply = new AsyncLazy<Database>(async () => await this.CreatePersonDocumentIfNotExists(_databaseId, _collectionId, entity));
        }

        public void AddRange(IEnumerable<T> entity)
        {
            foreach (var VARIABLE in entity)
            {
                var reply = new AsyncLazy<Database>(async () => await this.CreatePersonDocumentIfNotExists(_databaseId, _collectionId, VARIABLE));

            }
        }


        public virtual async void Remove(T entity)
        {

            var docUri = UriFactory.CreateDocumentUri(_databaseId, _collection, entity.id);
            await _database.DeleteDocumentAsync(docUri);

            //var result = await _client.DeleteDocumentCollectionAsync((await _collection).SelfLink, null);

            //bool isSuccess = result.StatusCode == HttpStatusCode.NoContent;

            //_collection = new AsyncLazy<DocumentCollection>(async () => await GetOrCreateCollectionAsync());

        }

        public async void RemoveRange(IEnumerable<T> entity)
        {
            foreach (var VARIABLE in entity)
            {
                var result = UriFactory.CreateDatabaseUri(_databaseId, _collection, VARIABLE);
                //await _client.DeleteDocumentCollectionAsync((await _collection).SelfLink, (RequestOptions)VARIABLE));

            }
        }

        protected async Task CreatePersonDocumentIfNotExists(string databaseName, string collectionName, T entity)
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

        private async Task<Document> GetDocumentByIdAsync(object id)
        {
            return _client.CreateDocumentQuery<Document>((await _collection).SelfLink).Where(d => d.Id == id.ToString()).AsEnumerable().FirstOrDefault();
        }
        private async Task CreateDocumentIfNotExists(string databaseName, string collectionName, Person person)
        {
            try
            {
                await this._client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, person.PersonId), new RequestOptions { PartitionKey = new PartitionKey(family.LastName) });
                this.WriteToConsoleAndPromptToContinue("Found {0}", person.PersonId);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this._client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), person);
                    this.WriteToConsoleAndPromptToContinue("Created Family {0}", person.PersonId);
                }
                else
                {
                    throw;
                }
            }
        }


        //After Tutorial in L6
        private async Task Create(string databaseName, string collectionName, Person person)
        {
            try
            {
                await this._client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, person.PersonId), new RequestOptions { PartitionKey = new PartitionKey(family.LastName) });
                this.WriteToConsoleAndPromptToContinue("Found {0}", person.PersonId);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this._client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), person);
                    this.WriteToConsoleAndPromptToContinue("Created Person {0}", person.PersonId);
                }
                else
                {
                    throw;
                }
            }
        }
        private void Read(string databaseName, string collectionName)
        {
            // Set some common query options
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            // Run a simple query via LINQ. DocumentDB indexes all properties, so queries can be completed efficiently and with low latency.
            // Here we find the Andersen family via its LastName
            IQueryable<Person> PersonQuery = this._client.CreateDocumentQuery<Person>(
                UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), queryOptions)
                .Where(f => f.LastName == "Andersen");

            // The query is executed synchronously here, but can also be executed asynchronously via the IDocumentQuery<T> interface
            Console.WriteLine("Running LINQ query...");
            foreach (Person p in PersonQuery)
            {
                Console.WriteLine("\tRead {0}", p);
            }

            // Now execute the same query via direct SQL
            IQueryable<Person> personQueryInSql = this._client.CreateDocumentQuery<Person>(
                UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                "SELECT * FROM Person WHERE Person.LastName = 'Andersen'",
                queryOptions);

            Console.WriteLine("Running direct SQL query...");
            foreach (Person p in personQueryInSql)
            {
                Console.WriteLine("\tRead {0}", p);
            }

            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }
        private async Task Update(string databaseName, string collectionName, Person person)
        {
            await this._client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, person.PersonId), person);
            this.WriteToConsoleAndPromptToContinue("Updated Person [{0},{1}]", person.LastName, person.PersonId);
        }
        async Task Delete(string databaseName, string collectionName, string partitionKey, string documentKey)
        {
            await this._client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, documentKey), new RequestOptions { PartitionKey = new PartitionKey(partitionKey) });
            Console.WriteLine("Deleted Person [{0},{1}]", partitionKey, documentKey);
        }
        private void WriteToConsoleAndPromptToContinue(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }
    }
}