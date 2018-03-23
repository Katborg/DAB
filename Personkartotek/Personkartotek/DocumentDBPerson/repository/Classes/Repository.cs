using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDBPerson
{
	public class Repository<IEntity> : IRepository<IEntity> where IEntity : class
	{
		protected readonly DbContext DbContext;

		public Repository(DbContext context)
		{
			DbContext = context;
		}
		public virtual void Add(IEntity entity)
		{
			DbContext.Set<IEntity>().Add(entity);
		}

		public void AddRange(IEnumerable<IEntity> entity)
		{
			DbContext.Set<IEntity>().AddRange(entity);
		}

		public IEntity Get(string id)
		{
			return DbContext.Set<IEntity>().Find(id);
		}

		public IEnumerable<IEntity> GetAll()
		{
			return DbContext.Set<IEntity>().ToList();
		}

		public void Remove(IEntity entity)
		{
			DbContext.Set<IEntity>().Remove(entity);
		}

		public void RemoveRange(IEnumerable<IEntity> entity)
		{
			DbContext.Set<IEntity>().RemoveRange(entity);
		}
	}
}
