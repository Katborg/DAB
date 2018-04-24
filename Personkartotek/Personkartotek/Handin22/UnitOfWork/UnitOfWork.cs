

namespace Handin22
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly PersonContext _context;
		
		public UnitOfWork(PersonContext context)
		{
			_context = context;
			Adress = new AdressRepository(_context);
			Cities = new CityRepository(_context);
			Persons = new PersonRepository(_context);
			Phones = new PhoneRepository(_context);


		}
		public IAdressRepository Adress { get; }
		public ICityRepository Cities { get; }
		public IPersonRepositroy Persons { get; }
		public IPhoneRepository Phones { get; }
		

		public int Complete()
		{
			return _context.SaveChanges();
		}
		public void Dispose()
		{
			_context.Dispose();
		}

	
	}
}
