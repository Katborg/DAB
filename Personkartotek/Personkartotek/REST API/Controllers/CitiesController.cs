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
    public class CitiesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork(new PersonContext());

        // GET: api/Cities
        public IQueryable<CityDTO> GetCities()
        {
            var towns = from t in _unitOfWork.Cities.GetAll().AsQueryable()
                        select new CityDTO()
                        {
                            CityId = t.CityId,
                            Name = t.Name,
                            ZipCode = t.ZipCode
                        };
            return towns;
        }

        // GET: api/Cities/5
        [ResponseType(typeof(CityDTO))]
        public IHttpActionResult GetCity(int id)
        {
            Handin22.City city = _unitOfWork.Cities.Get(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // PUT: api/Cities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCity(int id, CityDTO city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != city.CityId)
            {
                return BadRequest();
            }

            Handin22.City city1 = _unitOfWork.Cities.Get(id);

            if (city1 == null)
            {
                return NotFound();
            }

            city1.Name = city.Name;
            city1.ZipCode = city.ZipCode;

            _unitOfWork.Complete();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cities
        [ResponseType(typeof(Handin22.City))]
        public IHttpActionResult PostCity(CityDTO city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Handin22.City city1 = new Handin22.City()
            {
                Name = city.Name,
                ZipCode = city.ZipCode
            };

            _unitOfWork.Cities.Add(city1);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = city.CityId }, city);
        }

        // DELETE: api/Cities/5
        [ResponseType(typeof(CityDTO))]
        public IHttpActionResult DeleteCity(int id)
        {
            Handin22.City city = _unitOfWork.Cities.Get(id);
            if (city == null)
            {
                return NotFound();
            }

            _unitOfWork.Cities.Remove(city);
            _unitOfWork.Complete();

            var t = new CityDTO()
            {
                CityId = city.CityId,
                ZipCode = city.ZipCode,
                Name = city.Name
            };

            return Ok(city);
        }
    }
}