using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin21
{
    class Person
    {
        public Person(string fornavn, string mellemnavn, string eftermnavn, string type, IAdress contacktAdress)
        {
            Fornavn = fornavn;
            Mellemnavn = mellemnavn;
            Eftermnavn = eftermnavn;
            Type = type;
            ContacktAdress = contacktAdress;
        }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Fornavn { get; set; }
        public string Mellemnavn { get; set; }
        public string Eftermnavn { get; set; }

        public IAdress ContacktAdress { get; set; }
        public List<IAdress> AlternativeAdresses { get; set; }


    }



    }
}
