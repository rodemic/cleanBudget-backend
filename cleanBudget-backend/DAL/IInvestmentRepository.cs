using cleanBudget_BL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cleanBudget_backend.DAL
{
    public interface IInvestmentRepository : IRepository<Investment>
    {
        public Task<IEnumerable<Investment>> GetByAccountId(int accountId);
    }
}
