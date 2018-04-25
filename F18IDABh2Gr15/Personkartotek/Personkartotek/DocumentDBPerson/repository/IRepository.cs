using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocumentDBPerson.repository
{
	public interface IRepository<T> where T : class
	{

        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void AddRange(IEnumerable<T> entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}