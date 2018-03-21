using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Personkartotek
{
    public class Adress : IAdress
    {
        public Adress(string vejNavn, ref PostNumber post)
        {
            VejNavnOgNummer = vejNavn;
            SetpostNumer(ref post);
            
        }

        private void SetpostNumer(ref PostNumber value)
        {
            var adressRef = this;
            JoinPostNumberList.AddEntry(new PostItem( ref adressRef ,ref value));
          
        }
        private String _vejNavnOgNummer;

        public String VejNavnOgNummer
        {
            get { return _vejNavnOgNummer; }
            set { _vejNavnOgNummer = value; }
        }

       

        public override string ToString()
        {
            
            return VejNavnOgNummer + " " + JoinPostNumberList.GetPostnumberForAdresse(this).ToString();

        }
    }
}
