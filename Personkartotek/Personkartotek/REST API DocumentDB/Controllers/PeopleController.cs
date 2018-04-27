
using System.Net;
using System.Web.Http;
using DocumentDBPerson.repository;
using Person = DocumentDBPerson.Person;

namespace REST_API_DocumentDB.Controllers
{
    public class PeopleController : ApiController
    {
	    
	    private PersonRepositry _personRepository = new PersonRepositry();
	    

		[HttpGet]
	    public IHttpActionResult Get(int id)
	    {
		    var product = _personRepository.Get(id);

		    if (product == null)
		    {
			    return NotFound();
		    }

		    return Ok(product);
		}

		[HttpPost]
		public IHttpActionResult Post(int id, REST_API.Models.Person personDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}


			if (_personRepository.Get(id) != null)
			{
				return StatusCode(HttpStatusCode.NotAcceptable);
			}


			Person person = new Person(personDto.FirstName, personDto.LastName, personDto.Type)
			{
				MiddleName = personDto.MiddleName,
				LastName = personDto.LastName,
				PersonId = personDto.PersonId,
				Type = personDto.Type

			};

			_personRepository.Add(person);
			return StatusCode(HttpStatusCode.Accepted);
		}

	    [HttpDelete]
	    public IHttpActionResult Delete(int id)
	    {
		    var product = _personRepository.Get(id);
		    if (product != null)
		    {
			    _personRepository.Remove(product);
			    return StatusCode(HttpStatusCode.NoContent);
		    }
		    return NotFound();
	    }

	}
}
