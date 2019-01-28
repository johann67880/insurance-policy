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
        public long Id { get; set; }

        public int CustomerId { get; set; }

        public int InsuranceId { get; set; }

        public DateTime AssignationDate { get; set; } = DateTime.Now;
    }
}
