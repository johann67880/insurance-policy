using Insurance_Policy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Policy.Infrastructure.Context
{
    public class InsuranceContext : DbContext
    {
        string connection { get; set; }

        public InsuranceContext(string connectionString) : base(connectionString)
        {
            this.connection = connectionString;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CoverageType> CoverageTypes { get; set; }
        public DbSet<RiskType> RiskTypes { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<InsuranceByCustomer> InsuranceByCustomers { get; set; }
    }
}
