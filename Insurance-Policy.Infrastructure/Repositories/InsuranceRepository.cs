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
    public class InsuranceRepository : EntityBaseRepository<Insurance>, IInsuranceRepository
    {
        public InsuranceRepository(InsuranceContext context) : base(context)
        {
        }

        public List<InsuranceModel> GetAllInsurances()
        {
            var result = from i in this.Context.Insurances
                         join c in this.Context.CoverageTypes on i.CoverageId equals c.Id
                         join r in this.Context.RiskTypes on i.RiskId equals r.Id
                         select new InsuranceModel
                         {
                             Id = i.Id,
                             CoveragePeriod = i.CoveragePeriod,
                             CoverageType = c.Type,
                             CoverageId = i.CoverageId,
                             CoveragePercentage = i.CoveragePercentage,
                             Description = i.Description,
                             Name = i.Name,
                             Pricing = i.Pricing,
                             RiskType = r.Type,
                             RiskId = i.RiskId,
                             StartDate = i.StartDate
                         };

            return result.ToList();
        }
    }
}
