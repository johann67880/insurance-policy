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

        public bool Add(InsuranceByCustomer entity)
        {
            try
            {
                this.repository.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Delete(InsuranceByCustomer entity)
        {
            this.repository.Delete(entity);
        }

        public InsuranceByCustomer Get(InsuranceByCustomer entity)
        {
            return this.repository.Get(x => x.CustomerId == entity.CustomerId);
        }

        public List<InsuranceByCustomer> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        public List<InsuranceByCustomer> GetAssignationsByCustomer(int customerId)
        {
            return this.repository.GetAll(x => x.CustomerId.Equals(customerId)).ToList();
        }

        public void SaveAssignations(List<InsuranceByCustomer> assignations)
        {
            this.repository.SaveAssignations(assignations);
        }

        public bool Update(InsuranceByCustomer entity)
        {
            try
            {
                this.repository.Update(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
