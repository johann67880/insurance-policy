using Insurance_Policy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<InsuranceContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<CoverageType> CoverageType { get; set; }
        public DbSet<RiskType> RiskType { get; set; }
        public DbSet<Insurance> Insurance { get; set; }
        public DbSet<InsuranceByCustomer> InsuranceByCustomer { get; set; }

        public DbSet<User> User { get; set; }
    }
}
