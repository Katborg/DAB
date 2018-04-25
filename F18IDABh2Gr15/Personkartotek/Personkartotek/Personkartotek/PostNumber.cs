using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Personkartotek
{

    public class PostNumber
    {
        public PostNumber(int postnumber, string city)
        {
            City = city;
            Postnumber = postnumber;
        }

        public int Postnumber { get; set; }
        public String City { get; set; }
    }

    public class PostItem
    {
        private IAdress _adress;
        private PostNumber _postNumber;
       

        public ref IAdress Adress => ref _adress;

        public ref PostNumber PostNumber => ref _postNumber;
        

        public PostItem(ref Adress adress, ref PostNumber post)
        {
            _adress = adress;
            _postNumber = post;
        }
    }
}