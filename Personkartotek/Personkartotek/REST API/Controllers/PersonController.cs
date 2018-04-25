using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Handin22;
using REST_API.Models;

namespace REST_API.Controllers
{
    public class PersonController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork(new PersonContext());


        public IEnumerable<Handin22.Person> GetAll()
        {
            return _unitOfWork.Persons.GetAll();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var product = _unitOfWork.Persons.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Models.Person personDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Handin22.Person person = _unitOfWork.Persons.Get(id);

            if (person == null)
            {
                return NotFound();
            }

            person.FirstName = personDto.FirstName;
            person.MiddleName = personDto.MiddleName;
            person.LastName = personDto.LastName;
            person.PersonId = personDto.PersonId;
            person.Type = personDto.Type;

            _unitOfWork.Complete();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public IHttpActionResult Post(int id, Models.Person personDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (_unitOfWork.Persons.Get(id) != null)
            {
                return StatusCode(HttpStatusCode.NotAcceptable);
            }


            Handin22.Person person = new Handin22.Person(personDto.FirstName, personDto.LastName, personDto.Type)
            {
                MiddleName = personDto.MiddleName,
                LastName = personDto.LastName,
                PersonId = personDto.PersonId,
                Type = personDto.Type

            };

            person.AAdresses.Add(_unitOfWork.Adress.Get(Int32.Parse(personDto.AdressId)));

            _unitOfWork.Persons.Add(person);
            _unitOfWork.Complete();

            return StatusCode(HttpStatusCode.Accepted);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var product = _unitOfWork.Persons.Get(id);
            if (product != null)
            {
                _unitOfWork.Persons.Remove(product);
                return StatusCode(HttpStatusCode.NoContent);
            }
            return NotFound();
        }
    }
}
