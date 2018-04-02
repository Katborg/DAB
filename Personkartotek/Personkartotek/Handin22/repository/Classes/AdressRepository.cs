using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Handin22
{
	public class AdressRepository :  Repository<Adress>, IAdressRepository
	{
		public AdressRepository(DbContext context) : base(context)
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
