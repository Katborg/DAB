using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin22
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
