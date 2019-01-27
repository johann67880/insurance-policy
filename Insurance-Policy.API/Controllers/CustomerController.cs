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
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService<Customer> service;

        public CustomerController()
        {

        }

        public CustomerController(ICustomerService<Customer> service)
        {
            this.service = service;
        }

        [Route("getall")]
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            try
            {
                var result = this.service.GetAll();
                return this.Ok(result);
            }
            catch(Exception e)
            {
                return this.InternalServerError();
            }
        }

        [Route("update")]
        [HttpPut]
        public IHttpActionResult UpdateCustomer(Customer customer)
        {
            try
            {
                if (!(customer is Customer))
                {
                    return this.Ok(false);
                }

                this.service.Update(customer);
                return this.Ok(true);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }

        [Route("delete")]
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            try
            {
                if (id == 0)
                {
                    return this.Ok(false);
                }

                Customer customer = new Customer()
                {
                    Id = id
                };

                this.service.Delete(customer);
                return this.Ok(true);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }

        [Route("save")]
        [HttpPost]
        public IHttpActionResult SaveCustomer([FromBody] Customer customer)
        {
            try
            {
                if (!(customer is Customer))
                {
                    return this.Ok(false);
                }

                this.service.Add(customer);
                return this.Ok(true);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }
    }
}
