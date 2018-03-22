using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin22
{
	class CityRepository : Repository<City>, ICityRepository
	{
		public CityRepository(DbContext context) : base(context)
		{
		}

		public IEnumerable<Adress> GetAllAdressesInCity(City city)
		{
			throw new NotImplementedException();
		}
		public PersonContext PersonContext
		{
			//is done so that we in all other funtions can use PersonContext.
			get { return DbContext as PersonContext; }
		}
		public override void Add(City entity)
		{
			if (!PersonContext.Cities.Any(
				p => p.Name == entity.Name
				     && p.ZipCode == entity.ZipCode)) { 
				PersonContext.Cities.Add(entity);
			}
		}
	}
}
