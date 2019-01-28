using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Policy.Domain.Models
{
    public class InsuranceModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CoverageId { get; set; }

        public int CoveragePeriod { get; set; }

        public decimal CoveragePercentage { get; set; }

        public string CoverageType { get; set; }

        public DateTime StartDate { get; set; }

        public decimal Pricing { get; set; }

        public string RiskType { get; set; }

        public int RiskId { get; set; }
    }
}
