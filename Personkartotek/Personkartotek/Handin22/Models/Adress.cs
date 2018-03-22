using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Handin22
{
	public class Adress
    {
        [Key]
		public  long AdressId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public City City { get; set; }
        public virtual List<Person> Persons { get; set; }

    }
}
