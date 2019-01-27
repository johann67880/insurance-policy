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
    public class RiskTypeService : IRiskTypeService<RiskType>
    {
        private readonly IRiskTypeRepository repository;

        public RiskTypeService(IRiskTypeRepository repository)
        {
            this.repository = repository;
        }

        public void Add(RiskType entity)
        {
            this.repository.Add(entity);
        }

        public void Delete(RiskType entity)
        {
            this.repository.Delete(entity);
        }

        public RiskType Get(RiskType entity)
        {
            return this.repository.Get(x => x.Type == entity.Type);
        }

        public List<RiskType> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        public void Update(RiskType entity)
        {
            this.repository.Update(entity);
        }
    }
}
