﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Policy.Domain.Entities
{
    public class Insurance
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CoverageId { get; set; }

        public DateTime StartDate { get; set; }

        public int CoveragePeriod { get; set; }

        public decimal CoveragePercentage { get; set; }

        public decimal Pricing { get; set; }

        public int RiskId { get; set; }
    }
}
