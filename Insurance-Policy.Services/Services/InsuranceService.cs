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

        public bool Add(Insurance entity)
        {
            if (validateInsurance(entity))
            {
                this.repository.Add(entity);
                return true;
            }

            return false;
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

        public bool Update(Insurance entity)
        {
            if (validateInsurance(entity))
            {
                this.repository.Update(entity);
                return true;
            }

            return false;
        }

        private bool validateInsurance(Insurance entity)
        {
            //Business validations are implemented in Service Layer
            var risk = this.riskRepository.Get(entity.RiskId);

            if (risk.Type.ToLower().Contains("alto") && entity.CoveragePercentage >= 50)
            {
                return false;
            }

            return true;
        }
    }
}
