using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Handin22
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
	    
		public  int PersonId { get; set; }
		public string FirstName {get; set;}
        public string MiddleName {get; set;}
        public string LastName {get; set;}
        public string Type {get; set;}
        public List<Phone> PhoneNumbers {get; set;}
        public virtual Adress PAdress { get; set; }
        public virtual List<Adress> AAdresses { get; set; }
		
    }
}
