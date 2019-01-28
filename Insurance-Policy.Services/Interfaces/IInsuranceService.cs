using Insurance_Policy.Domain.Models;
using Insurance_Policy.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Policy.Services.Interfaces
{
    public interface IInsuranceService<T> : IBaseService<T>
    {
        List<InsuranceModel> GetAllInsurances();
    }
}
