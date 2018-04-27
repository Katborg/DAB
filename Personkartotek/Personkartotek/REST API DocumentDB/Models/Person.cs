using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REST_API.Models
{
	public class Person
	{
		[Required]
		public string PersonId { get; set; }
		[Required]
		[MinLength(2)]
		public string FirstName { get; set; }
		public string MiddleName { get; set; }

		[MinLength(2)]
		[Required]
		public string LastName { get; set; }
		public string Type { get; set; }

		public string AdressId { get; set; }

	}
}