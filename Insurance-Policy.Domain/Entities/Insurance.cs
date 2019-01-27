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
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [ForeignKey("CoverageType")]
        public CoverageType CoverageId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public int CoveragePeriod { get; set; }

        [Required]
        public decimal Pricing { get; set; }

        [Required]
        [ForeignKey("RiskType")]
        public int RiskId { get; set; }
    }
}
