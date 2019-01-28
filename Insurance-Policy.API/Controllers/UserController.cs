using Insurance_Policy.Domain.Entities;
using Insurance_Policy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Insurance_Policy.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService<User> service;

        public UserController() { }

        public UserController(IUserService<User> service)
        {
            this.service = service;
        }

        [Route("getuser")]
        [HttpPost]
        public IHttpActionResult GetUsers([FromBody] User user)
        {
            try
            {
                var result = this.service.Get(user);
                return this.Ok(result);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }
    }
}
