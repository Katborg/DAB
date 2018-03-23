using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handin22.repos;

namespace DocumentDBPerson
{
	public class AdressRepository :  Repository<Adress>, IAdressRepository
	{
		public AdressRepository(PersonContext context) : base(context)
		{
		}

		public IEnumerable<Adress> GetAllAdresses()
		{
			return PersonContext.Adresses.ToList();
		}

		public PersonContext PersonContext
		{
			//is done so that we in all other funtions can use PersonContext.
			get { return DbContext as PersonContext; }
		}
	}
}
