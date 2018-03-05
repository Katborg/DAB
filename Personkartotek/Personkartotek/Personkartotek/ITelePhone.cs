using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personkartotek
{
    public interface ITelefone
    {
        String Type { get; set; }
        String PhoneCompany { get; set; }
        string ToString();
    }
}
