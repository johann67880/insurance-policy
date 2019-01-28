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

        public bool Add(RiskType entity)
        {
            try
            {
                this.repository.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
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

        public bool Update(RiskType entity)
        {
            try
            {
                this.repository.Update(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
