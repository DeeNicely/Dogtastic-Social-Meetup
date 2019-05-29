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
        public IHttpActionResult Get()
        {
            ParentService parentService = CreateParentService();
            var notes = parentService.GetParents();
            return Ok(notes);
        }
        private ParentService CreateParentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var parentService = new ParentService(userId);
            return parentService;
        }
    }
}
