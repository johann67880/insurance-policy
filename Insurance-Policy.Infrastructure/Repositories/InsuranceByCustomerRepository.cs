using Insurance_Policy.Domain.Entities;
using Insurance_Policy.Domain.Interfaces;
using Insurance_Policy.Domain.Models;
using Insurance_Policy.Infrastructure.Context;
using Insurance_Policy.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Policy.Infrastructure.Repositories
{
    public class InsuranceByCustomerRepository : EntityBaseRepository<InsuranceByCustomer>, IInsuranceByCustomerRepository
    {
        public InsuranceByCustomerRepository(InsuranceContext context) : base(context)
        {
        }

        public void SaveAssignations(List<InsuranceByCustomer> assignations)
        {
            long customerId = assignations[0].CustomerId;
            var rowsToDelete = this.GetAll(x => x.CustomerId == customerId).ToList();

            rowsToDelete.ForEach(x =>
            {
                //removes all previous assignations for current customer
                this.Delete(x);
            });

            //inserts new assignations associated to current customer
            assignations.ForEach(x =>
            {
                x.AssignationDate = DateTime.Now;
                this.Add(x);
            });
        }
    }
}
