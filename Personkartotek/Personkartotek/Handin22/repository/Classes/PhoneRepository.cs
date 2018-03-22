using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin22
{
	class PhoneRepository : Repository<Phone>, IPhoneRepository
	{
		public PersonContext PersonContext
		{
			//is done so that we in all other funtions can use PersonContext.
			get { return DbContext as PersonContext; }
		}

		public PhoneRepository(DbContext context) : base(context)
		{
		}
	}
}
