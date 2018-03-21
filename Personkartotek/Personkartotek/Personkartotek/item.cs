using System.Runtime.InteropServices;
using System.Data.Entity;

namespace Personkartotek
{
    public class Item
    {
        private IAdress _adress;
        private  Person _person;

        public ref IAdress Adress => ref _adress;

        public ref Person Person => ref _person;

        public string Type { get; }

        public Item(ref IAdress adress, ref Person person, string type)
        {
            _adress = adress;
            _person = person;
            Type = type;
        }

        public Item(string error)
        {
            PostNumber post = new PostNumber(0000, "ErrorTwon");
            _adress = new Adress("error",ref post);
            _person = new Person("error", "Error","","", _adress);
        }

    }
   
}