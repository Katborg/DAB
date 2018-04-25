using System;
using System.Collections.Generic;


namespace Handin22
{
	public interface ICityRepository : IRepository<City>
	{
		IEnumerable<Adress> GetAllAdressesInCity(City city);
	}
}
