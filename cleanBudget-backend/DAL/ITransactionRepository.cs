using cleanBudget_BL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cleanBudget_backend.DAL
{
    public interface ITransactionRepository :IRepository<Transaction>
    {
        public  Task<IEnumerable<Transaction>> GetByAccountId(int accountId);
    }
}
