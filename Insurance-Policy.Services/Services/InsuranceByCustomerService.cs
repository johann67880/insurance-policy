using Insurance_Policy.Domain.Entities;
using Insurance_Policy.Domain.Interfaces;
using Insurance_Policy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Policy.Services.Services
{
    public class InsuranceByCustomerService : IInsuranceByCustomerService<InsuranceByCustomer>
    {
        private readonly IInsuranceByCustomerRepository repository;

        public InsuranceByCustomerService(IInsuranceByCustomerRepository repository)
        {
            this.repository = repository;
        }

        public void Add(InsuranceByCustomer entity)
        {
            this.repository.Add(entity);
        }

        public void Delete(InsuranceByCustomer entity)
        {
            this.repository.Delete(entity);
        }

        public InsuranceByCustomer Get(InsuranceByCustomer entity)
        {
            return this.repository.Get(x => x.CustomerId.Name == entity.CustomerId.Name);
        }

        public List<InsuranceByCustomer> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        public void Update(InsuranceByCustomer entity)
        {
            this.repository.Update(entity);
        }
    }
}
