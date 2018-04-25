
using System.Collections.Generic;
using Newtonsoft.Json;


namespace DocumentDBPerson
{
    public class Person
    {
	    public Person(){}
	    public Person(string firstName, string lastName, string type)
	    {
		    AAdresses = new List<Adress>();
		    FirstName = firstName;
		    LastName = lastName;
		    Type = type;

	    }

	    [JsonProperty(PropertyName = "id")]
		public  string PersonId { get; set; }
		public string FirstName {get; set;}
        public string MiddleName {get; set;}
        public string LastName {get; set;}
        public string Type {get; set;}
        public List<Phone> PhoneNumbers {get; set;}
        public virtual Adress PAdress { get; set; }
        public virtual List<Adress> AAdresses { get; set; }

	    public override string ToString()
	    {
		    return JsonConvert.SerializeObject(this);
	    }

	}
}
