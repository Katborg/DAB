using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocumentDBPerson.repository
{
	public interface IRepository<T> where T : class
	{

		Task<T> Get(string id);
		Task<IEnumerable<T>> GetAll();
        Task<T> AddOrUpdate(T entity);
		Task<bool> Remove(T entity);


        //fra lektion6 tutorial
        Task Create(string databaseName, string collectionName, Person person);
        void Read(string databaseName, string collectionName);
        Task Update(string databaseName, string collectionName, Person person);
        Task Delete(string databaseName, string collectionName, string partitionKey, string documentKey);




    }
}