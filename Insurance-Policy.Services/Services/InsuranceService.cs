using Insurance_Policy.Domain.Entities;
using Insurance_Policy.Domain.Interfaces;
using Insurance_Policy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Policy.Services.Services
{
    public class InsuranceService : IInsuranceService<Insurance>
    {
        private readonly IInsuranceRepository repository;

        public InsuranceService(IInsuranceRepository repository)
        {
            this.repository = repository;
        }

        public void Add(Insurance entity)
        {
            this.repository.Add(entity);
        }

        public void Delete(Insurance entity)
        {
            this.repository.Delete(entity);
        }

        public Insurance Get(Insurance entity)
        {
            return this.repository.Get(x => x.Name == entity.Name);
        }

        public List<Insurance> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        public void Update(Insurance entity)
        {
            this.repository.Update(entity);
        }
    }
}
