using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Handin22
{
    public class Phone
    {
        
		public long PhoneID { get; set; }
		public string Number {get; set;}
        public string provider {get; set;}
}
}
