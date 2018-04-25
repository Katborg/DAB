using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin22
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

		public virtual void AddRange(IEnumerable<IEntity> entity)
		{
			DbContext.Set<IEntity>().AddRange(entity);
		}

		public virtual IEntity Get(string id)
		{
			return DbContext.Set<IEntity>().Find(id);
		}

		public virtual IEnumerable<IEntity> GetAll()
		{
			return DbContext.Set<IEntity>().ToList();
		}

		public virtual void Remove(IEntity entity)
		{
			DbContext.Set<IEntity>().Remove(entity);
		}

		public virtual void RemoveRange(IEnumerable<IEntity> entity)
		{
			DbContext.Set<IEntity>().RemoveRange(entity);
		}
	}
}
