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
		
	}
}