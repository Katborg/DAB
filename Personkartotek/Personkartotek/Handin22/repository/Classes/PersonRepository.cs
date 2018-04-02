using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin22
{
	class PersonRepository : Repository<Person>, IPersonRepositroy
	{
		public PersonRepository(DbContext context) : base(context) {}

		public PersonContext PersonContext => DbContext as PersonContext;

		public override void Add(Person entity)
		{
			if(!PersonContext.Persons.Any(p => p.FirstName == entity.FirstName && p.LastName == entity.LastName))
				PersonContext.Persons.Add(entity);
		}
	}

}
