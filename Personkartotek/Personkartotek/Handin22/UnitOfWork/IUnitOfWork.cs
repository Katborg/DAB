using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin22
{
	public interface IUnitOfWork : IDisposable
	{
		IAdressRepository Adress { get; }
		ICityRepository Cities { get; }
		IPersonRepositroy Persons { get; }
		IPhoneRepository Phones { get; }

		int Complete();
	}
}
