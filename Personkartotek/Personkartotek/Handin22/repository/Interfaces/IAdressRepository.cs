using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handin22.repos;

namespace Handin22
{
	interface IAdressRepository : IRepository<Adress>
	{
		IEnumerable<Adress> GetAllAdresses();
		

	}
}
