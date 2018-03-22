using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handin22.repos;

namespace Handin22
{
	public interface ICityRepository : IRepository<City>
	{
		IEnumerable<Adress> GetAllAdressesInCity(City city);
	}
}
