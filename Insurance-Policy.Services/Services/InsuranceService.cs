using Insurance_Policy.Domain.Entities;
using Insurance_Policy.Domain.Interfaces;
using Insurance_Policy.Domain.Models;
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
        private readonly IRiskTypeRepository riskRepository;

        public InsuranceService(IInsuranceRepository repository, IRiskTypeRepository riskRepository)
        {
            this.repository = repository;
            this.riskRepository = riskRepository;
        }

        public void Add(Insurance entity)
        {
            //Business validations are implemented in Service Layer
            var risk = this.riskRepository.Get(x => x.Id.Equals(entity.Id));

            if(risk.Type.Contains("Alto") && entity.CoveragePercentage >= 50)
            {
                return;
            }

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

        public List<InsuranceModel> GetAllInsurances()
        {
            return this.repository.GetAllInsurances();
        }

        public void Update(Insurance entity)
        {
            this.repository.Update(entity);
        }
    }
}
