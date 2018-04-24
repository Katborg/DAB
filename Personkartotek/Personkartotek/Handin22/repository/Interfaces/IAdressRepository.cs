using System;
using System.Collections.Generic;


namespace Handin22
{
	public interface IAdressRepository : IRepository<Adress>
	{
		IEnumerable<Adress> GetAllAdresses();
		

	}
}
