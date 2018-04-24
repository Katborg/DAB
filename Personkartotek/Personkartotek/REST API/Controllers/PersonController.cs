using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Handin22;

namespace REST_API.Controllers
{
    public class PersonController : ApiController
    {
	    private readonly IUnitOfWork _unitOfWork = new UnitOfWork(new PersonContext());


		public IEnumerable<Person> GetAllPersons()
	    {
			    return _unitOfWork.Persons.GetAll();
	    }

	    public IHttpActionResult GetPerson(int id)
	    {
			var product = _unitOfWork.Persons.Get(id);

			if (product == null)
			{
				return NotFound();
			}

			return Ok(product);
	    }
	}
}
