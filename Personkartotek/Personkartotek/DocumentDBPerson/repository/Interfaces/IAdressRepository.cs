using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handin22.repos;

namespace DocumentDBPerson
{
	interface IAdressRepository : IRepository<Adress>
	{
		IEnumerable<Adress> GetAllAdresses();
		

	}
}
