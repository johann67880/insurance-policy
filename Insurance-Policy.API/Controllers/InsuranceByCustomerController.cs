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
    [RoutePrefix("api/assign")]
    public class InsuranceByCustomerController : ApiController
    {
        private readonly IInsuranceByCustomerService<InsuranceByCustomer> service;

        public InsuranceByCustomerController()
        {

        }

        public InsuranceByCustomerController(IInsuranceByCustomerService<InsuranceByCustomer> service)
        {
            this.service = service;
        }

        [Route("save")]
        [HttpPost]
        public IHttpActionResult SaveAssignation([FromBody] List<InsuranceByCustomer> assignations)
        {
            try
            {
                if (!(assignations is List<InsuranceByCustomer>))
                {
                    return this.Ok(false);
                }

                this.service.SaveAssignations(assignations);
                return this.Ok(true);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }

        [Route("get/{customerId:int}")]
        [HttpGet]
        public IHttpActionResult GetAssignation(int customerId)
        {
            try
            {
                if (customerId == 0)
                {
                    return this.Ok(false);
                }

                var result = this.service.GetAssignationsByCustomer(customerId);
                return this.Ok(result);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }
    }
}
