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
    public class CoverageTypeService : ICoverageTypeService<CoverageType>
    {
        private readonly ICoverageTypeRepository repository;

        public CoverageTypeService(ICoverageTypeRepository repository)
        {
            this.repository = repository;
        }

        public void Add(CoverageType entity)
        {
            this.repository.Add(entity);
        }

        public void Delete(CoverageType entity)
        {
            this.repository.Delete(entity);
        }

        public CoverageType Get(CoverageType entity)
        {
            return this.repository.Get(x => x.Type == entity.Type);
        }

        public List<CoverageType> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        public void Update(CoverageType entity)
        {
            this.repository.Update(entity);
        }
    }
}
