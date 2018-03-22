using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Handin22
{
	public class City
    {
		public long CityId { get; set; }
		public string Name { get; set; }
	    public int ZipCode { get; set; }

       // public virtual List<ZipCode>  ZipCode { get; set; }
    }
}
