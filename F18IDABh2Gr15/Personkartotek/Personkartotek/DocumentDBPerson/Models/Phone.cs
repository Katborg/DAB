using Newtonsoft.Json;

namespace DocumentDBPerson
{
    public class Phone
    {
		public long PhoneID { get; set; }
		public string Number {get; set;}
        public string provider {get; set;}
	    public override string ToString()
	    {
		    return JsonConvert.SerializeObject(this);
	    }
	}
}
