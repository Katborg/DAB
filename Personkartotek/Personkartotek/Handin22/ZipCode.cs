using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Handin22
{
    class ZipCode
    {
        [Key, ForeignKey("City")]
        public string Zip {get; set;}
        
        public City City {get; set;}
}
}
