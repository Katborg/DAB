
using System.Collections.Generic;
using Newtonsoft.Json;


namespace DocumentDBPerson
{
	public class Adress
    {
       
		public  long AdressId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public City City { get; set; }
        public virtual List<Person> Persons { get; set; }
	    public override string ToString()
	    {
		    return JsonConvert.SerializeObject(this);
	    }

	}
}
