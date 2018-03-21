using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Handin22
{
    class City
    {
        [Key]
        public string Name { get; set; }
        public ZipCode zipCode { get; set; }
    }
}
