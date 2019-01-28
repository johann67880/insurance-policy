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
    [RoutePrefix("api/coverage")]
    public class CoverageTypeController : ApiController
    {
        private readonly ICoverageTypeService<CoverageType> service;

        public CoverageTypeController(ICoverageTypeService<CoverageType> service)
        {
            this.service = service;
        }

        public CoverageTypeController()
        {

        }

        [Route("getall")]
        [HttpGet]
        public IHttpActionResult GetCoverages()
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
        public IHttpActionResult UpdateCoverage(CoverageType coverage)
        {
            try
            {
                if (!(coverage is CoverageType))
                {
                    return this.Ok(false);
                }

                this.service.Update(coverage);
                return this.Ok(true);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }

        [Route("delete")]
        [HttpDelete]
        public IHttpActionResult DeleteCoverages(int id)
        {
            try
            {
                if (id == 0)
                {
                    return this.Ok(false);
                }

                CoverageType coverage = new CoverageType()
                {
                    Id = id
                };

                this.service.Delete(coverage);
                return this.Ok(true);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }

        [Route("save")]
        [HttpPost]
        public IHttpActionResult SaveCustomer([FromBody] CoverageType coverage)
        {
            try
            {
                if (!(coverage is CoverageType))
                {
                    return this.Ok(false);
                }

                this.service.Add(coverage);
                return this.Ok(true);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }
    }
}
