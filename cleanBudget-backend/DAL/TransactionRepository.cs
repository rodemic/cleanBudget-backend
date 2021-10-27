using cleanBudget_BL.BusinessObjects;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace cleanBudget_backend.DAL
{
    public class TransactionRepository : ITransactionRepository
    {
        protected readonly IDbConnection _db;

        public TransactionRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            string storedProc = "GetAllTransactions";
            return (await _db.QueryAsync<Transaction>(storedProc, commandType: CommandType.StoredProcedure));
        }

        public async Task<Transaction> GetById(int id)
        {
            string storedProc = "GetTransactionsById";
            return (await _db.QueryFirstAsync<Transaction>(storedProc, new { id = id }, commandType: CommandType.StoredProcedure));
        }


        public async Task<int> Save(Transaction T)
        {
            var parameters = new
            {
                id = T.Id,
                amount = T.Amount,
                categoryId = T.CategoryId,
                purchaseDate = T.PurchaseDate,
                accountId = T.AccountID
            };
            string storedProc = "SaveTransaction";
            return (await _db.ExecuteAsync(storedProc, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<Transaction>> GetByAccountId(int accountId)
        {
            string storedProc = "GetTransactionsById";
            return (await _db.QueryAsync<Transaction>(storedProc, new { accountId = accountId }, commandType: CommandType.StoredProcedure));
        }
    }
}
