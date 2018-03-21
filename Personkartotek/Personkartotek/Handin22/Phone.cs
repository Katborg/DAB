using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Handin22
{
    class Phone
    {
        [Key]
        public string Number {get; set;}
        public string provider {get; set;}
}
}
