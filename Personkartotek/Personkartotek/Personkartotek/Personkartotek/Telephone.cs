using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personkartotek
{
    class Telefone : ITelefone
    {
        public Telefone(string type, string phoneCompany)
        {
            PhoneCompany = phoneCompany;
            Type = type;
        }

        public string Type { get; set; }
        public string PhoneCompany { get; set; }
        public override String ToString()
        {
            return Type + " " + PhoneCompany;
        }
    }
}
