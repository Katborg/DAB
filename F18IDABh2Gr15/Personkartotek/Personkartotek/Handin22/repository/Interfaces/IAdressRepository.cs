using System;
using System.Collections.Generic;


namespace Handin22
{
	interface IAdressRepository : IRepository<Adress>
	{
		IEnumerable<Adress> GetAllAdresses();
		

	}
}
