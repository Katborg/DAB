

using Newtonsoft.Json;

namespace DocumentDBPerson
{
	public class City
    {
		public long CityId { get; set; }
		public string Name { get; set; }
	    public int ZipCode { get; set; }

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
