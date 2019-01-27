using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Policy.Domain.Entities
{
    public class InsuranceByCustomer
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int InsuranceId { get; set; }

        [Required]
        public DateTime AssignationDate { get; set; } = DateTime.Now;
    }
}
