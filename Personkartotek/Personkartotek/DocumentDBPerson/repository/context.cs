using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DocumentDBPerson
{
	private const string EndpointUri = "https://person-database.documents.azure.com:443/";
	private const string PrimaryKey = "MKIfr8B0zXcrM4GkcospYFF9loGIYHwEZCIKjjhdX3rXerV5xZlVw9QkfiNj6LHGTmZNwCApwHvnVhw9wMgbHA==";
	private DocumentClient client;


	public class PersonContext : DbContext
	{
		public DbSet<Person> Persons { get; set; }
		public DbSet<Adress> Adresses { get; set; }
		public DbSet<City> Cities { get; set; }

		public PersonContext()
		:base("name=AsureCosmosDB")
		{
				
		}
	}
	
}
