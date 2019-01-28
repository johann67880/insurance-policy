using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Policy.Domain.Entities
{
    public class RiskType
    {
        public int Id { get; set; }

        public string Type { get; set; }
    }
}
