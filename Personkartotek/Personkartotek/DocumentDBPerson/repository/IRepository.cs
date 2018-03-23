using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocumentDBPerson.repository
{
	public interface IRepository<IEntity> where IEntity : class
	{

		IEntity Get(string id);
		IEnumerable<IEntity> GetAll();
		void Add(IEntity entity);
		void AddRange(IEnumerable<IEntity> entity);
		void Remove(IEntity entity);
		void RemoveRange(IEnumerable<IEntity> entity);
	}
}