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
    public class ParentController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            ParentService parentService = CreateParentService();
            var notes = parentService.GetParents();
            return Ok(notes);
        }
        public IHttpActionResult Get(int id)
        {
            ParentService parentService = CreateParentService();
            var parent = parentService.GetParentById(id);
            return Ok(parent);
        }

        public IHttpActionResult Post(ParentCreate parent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateParentService();

            if (!service.CreateParent(parent))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(ParentEdit parent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateParentService();

            if (!service.UpdateParent(parent))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateParentService();

            if (!service.DeleteParent(id))
                return InternalServerError();
            return Ok();
        }

        private ParentService CreateParentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var parentService = new ParentService(userId);
            return parentService;
        }
    }
}
