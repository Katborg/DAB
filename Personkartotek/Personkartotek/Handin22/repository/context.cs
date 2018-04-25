using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Handin22
{

	public class PersonContext : DbContext
	{
		
		public DbSet<Person> Persons { get; set; }
		public DbSet<Adress> Adresses { get; set; }
		public DbSet<City> Cities { get; set; }

		public PersonContext()
		:base("name=HandIn22")
		{
				
		}

        public System.Data.Entity.DbSet<Handin22.Phone> Phones { get; set; }
    }
	
}
