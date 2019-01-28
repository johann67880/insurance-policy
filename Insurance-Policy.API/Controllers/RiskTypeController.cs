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
    [RoutePrefix("api/risk")]
    public class RiskTypeController : ApiController
    {
        private readonly IRiskTypeService<RiskType> service;

        public RiskTypeController() { }

        public RiskTypeController(IRiskTypeService<RiskType> service)
        {
            this.service = service;
        }

        [Route("getall")]
        [HttpGet]
        public IHttpActionResult GetRiskTypes()
        {
            try
            {
                var result = this.service.GetAll();
                return this.Ok(result);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }

        [Route("update")]
        [HttpPut]
        public IHttpActionResult UpdateRiskType(RiskType riskType)
        {
            try
            {
                if (!(riskType is RiskType))
                {
                    return this.Ok(false);
                }

                this.service.Update(riskType);
                return this.Ok(true);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }

        [Route("delete")]
        [HttpDelete]
        public IHttpActionResult DeleteRiskType(int id)
        {
            try
            {
                if (id == 0)
                {
                    return this.Ok(false);
                }

                RiskType riskType = new RiskType()
                {
                    Id = id
                };

                this.service.Delete(riskType);
                return this.Ok(true);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }

        [Route("save")]
        [HttpPost]
        public IHttpActionResult SaveRiskType([FromBody] RiskType riskType)
        {
            try
            {
                if (!(riskType is RiskType))
                {
                    return this.Ok(false);
                }

                this.service.Add(riskType);
                return this.Ok(true);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }
    }
}
