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
    }
}
