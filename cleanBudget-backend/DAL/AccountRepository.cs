using cleanBudget_BL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace cleanBudget_backend.DAL
{
    public class AccountRepository : IAccountRepository
    {

        protected readonly IDbConnection _db;

        public AccountRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
                string storedProc = "GetAllAccounts";
                return (await _db.QueryAsync<Account>(storedProc, commandType: CommandType.StoredProcedure));
        }

        public async Task<Account> GetById(int id)
        {
            string storedProc = "GetAccountById";
            return (await _db.QueryFirstAsync<Account>(storedProc, new { id = id }, commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<Account>> GetByUserAccountId(int userAccountId)
        {
            string storedProc = "GetAccountsByUserAccountId";
            return (await _db.QueryAsync<Account>(storedProc, new { userAccountId = userAccountId }, commandType: CommandType.StoredProcedure));
        }

        public async Task<int> Save(Account T)
        {
            var parameters = new 
            {
                id = T.Id,
                name = T.Name,
                startingAmount = T.StartingAmount,
                UserAccountId = T.UserAccountId
            };
            string storedProc = "SaveAccount";
            return (await _db.ExecuteAsync(storedProc, parameters, commandType: CommandType.StoredProcedure));
        }
    }
}
