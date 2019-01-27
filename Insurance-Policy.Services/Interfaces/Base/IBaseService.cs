using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Policy.Services.Interfaces.Base
{
    public interface IBaseService<T>
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        List<T> GetAll();

        T Get(T entity);
    }
}
