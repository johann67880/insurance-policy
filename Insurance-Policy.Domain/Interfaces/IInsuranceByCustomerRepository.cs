using Insurance_Policy.Domain.Entities;
using Insurance_Policy.Domain.Interfaces.Base;
using Insurance_Policy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Policy.Domain.Interfaces
{
    public interface IInsuranceByCustomerRepository : IEntityBaseRepository<InsuranceByCustomer>
    {
        void SaveAssignations(List<InsuranceByCustomer> assignations);
    }
}
