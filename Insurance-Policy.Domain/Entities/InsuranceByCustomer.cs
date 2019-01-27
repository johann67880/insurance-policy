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
        public int Id { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public Customer CustomerId { get; set; }

        [Required]
        [ForeignKey("Insurance")]
        public Insurance InsuranceId { get; set; }

        [Required]
        public DateTime AssignationDate { get; set; } = DateTime.Now;
    }
}
