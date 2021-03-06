﻿using Insurance_Policy.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Policy.Services.Interfaces
{
    public interface IInsuranceByCustomerService<T> : IBaseService<T>
    {
        void SaveAssignations(List<T> assignations);

        List<T> GetAssignationsByCustomer(int customerId);
    }
}
