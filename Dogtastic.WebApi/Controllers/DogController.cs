using Dogtastic.Models;
using Dogtastic.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dogtastic.WebApi.Controllers
{
    [Authorize]
    public class DogController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            DogService dogService = CreateDogService();
            var dogs = dogService.GetDogs();
            return Ok(dogs);
        }
        public IHttpActionResult Get(int id)
        {
            DogService dogService = CreateDogService();
            var dog = dogService.GetDogById(id);
            return Ok(dog);
        }

        public IHttpActionResult Post(DogCreate dog)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDogService();

            if (!service.CreateDog(dog))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(DogEdit dog)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDogService();

            if (!service.UpdateDog(dog))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateDogService();

            if (!service.DeleteDog(id))
                return InternalServerError();
            return Ok();
        }

        private DogService CreateDogService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var dogService = new DogService(userId);
            return dogService;
        }
    }
}
