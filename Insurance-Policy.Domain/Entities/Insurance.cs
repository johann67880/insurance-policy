using System;
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
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CoverageId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public int CoveragePeriod { get; set; }

        [Required]
        public decimal Pricing { get; set; }

        [Required]
        public int RiskId { get; set; }
    }
}
