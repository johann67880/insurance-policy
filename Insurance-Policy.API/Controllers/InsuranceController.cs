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
    [RoutePrefix("api/insurance")]
    public class InsuranceController : ApiController
    {
        private readonly IInsuranceService<Insurance> service;

        public InsuranceController()
        {

        }

        public InsuranceController(IInsuranceService<Insurance> service)
        {
            this.service = service;
        }

        [Route("getall")]
        [HttpGet]
        public IHttpActionResult GetAllInsurances()
        {
            try
            {
                var result = this.service.GetAllInsurances();
                return this.Ok(result);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }

        [Route("update")]
        [HttpPut]
        public IHttpActionResult UpdateInsurance(Insurance insurance)
        {
            try
            {
                if(!(insurance is Insurance))
                {
                    return this.Ok(false);
                }

                var result = this.service.Update(insurance);
                return this.Ok(result);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        public IHttpActionResult DeleteInsurance(int id)
        {
            try
            {
                if (id == 0)
                {
                    return this.Ok(false);
                }

                Insurance insurance = new Insurance()
                {
                    Id = id
                };

                this.service.Delete(insurance);
                return this.Ok(true);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }

        [Route("save")]
        [HttpPost]
        public IHttpActionResult SaveInsurance([FromBody] Insurance insurance)
        {
            try
            {
                if (!(insurance is Insurance))
                {
                    return this.Ok(false);
                }

                var result = this.service.Add(insurance);
                return this.Ok(result);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }
    }
}
