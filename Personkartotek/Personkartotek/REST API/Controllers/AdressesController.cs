using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Handin22;
using REST_API.Models;

namespace REST_API.Controllers
{
    public class AdressesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork(new PersonContext());

        public IEnumerable<Handin22.Person> GetAll()
        {
            return _unitOfWork.Persons.GetAll();
        }
        // GET: api/Adresses
        public IQueryable<AdressDTO> GetAdresses()
        {
            var product = from a in _unitOfWork.Adress.GetAll().AsQueryable()
                          select new AdressDTO()
                          {
                              AdressId = a.AdressId,
                              Street = a.Street,
                              Number = a.Number
                          };

            return product;
        }

        // GET: api/Adresses/5
        [ResponseType(typeof(AdressDTO))]
        public IHttpActionResult GetAdress(int id)
        {
            Handin22.Adress adress = _unitOfWork.Adress.Get(id);
            if (adress == null)
            {
                return NotFound();
            }

            var adressDTO = new AdressDTO()
            {
                AdressId = adress.AdressId,
                Number = adress.Number,
                Street = adress.Street
            };

            return Ok(adress);
        }

        // PUT: api/Adresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdress(int id, AdressDTO adress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adress.AdressId)
            {
                return BadRequest();
            }

            Handin22.Adress a = _unitOfWork.Adress.Get(id);
          
                if (a == null)
                {
                    return NotFound();
                }
            a.Street = adress.Street;
            a.Number = adress.Number;
            a.AdressId = adress.AdressId;

            _unitOfWork.Complete();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Adresses
        [ResponseType(typeof(Handin22.Adress))]
        public IHttpActionResult PostAdress(Handin22.Adress adress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Handin22.Adress adressdto = new Handin22.Adress()
            {
                Street = adress.Street,
                Number = adress.Number,
                AdressId = adress.AdressId

            };

            _unitOfWork.Adress.Add(adressdto);
            _unitOfWork.Complete();

            adress.AdressId = adressdto.AdressId;

            return CreatedAtRoute("DefaultApi", new { id = adress.AdressId }, adress);
        }

        // DELETE: api/Adresses/5
        [ResponseType(typeof(AdressDTO))]
        public IHttpActionResult DeleteAdress(int id)
        {
            Handin22.Adress adress = _unitOfWork.Adress.Get(id);
            if (adress == null)
            {
                return NotFound();
            }

            _unitOfWork.Adress.Remove(adress);
            _unitOfWork.Complete();

            var adDTO = new AdressDTO()
            {
                AdressId = adress.AdressId,
                Number = adress.Number,
                Street = adress.Street
            };

            return Ok(adress);
        }

    }
}