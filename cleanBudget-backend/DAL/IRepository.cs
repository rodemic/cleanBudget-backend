using cleanBudget_BL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace cleanBudget_backend.DAL
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAll();

        public Task<T> GetById(int id);
         
        public Task<int> Save(T T);
    }
}
