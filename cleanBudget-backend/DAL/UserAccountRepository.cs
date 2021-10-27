using cleanBudget_BL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace cleanBudget_backend.DAL
{
    public class UserAccountRepository : IUserAccountRepository
    {

        protected readonly IDbConnection _db;

        public UserAccountRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<UserAccount>> GetAll()
        {
                string storedProc = "GetAllUserAccounts";
                return (await _db.QueryAsync<UserAccount>(storedProc, commandType: CommandType.StoredProcedure));
        }

        public async Task<UserAccount> GetById(int id)
        {
            string storedProc = "GetUserAccountById";
            return (await _db.QueryFirstAsync<UserAccount>(storedProc, new { id = id }, commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<UserAccount>> GetByUserUserAccountId(int userUserAccountId)
        {
            string storedProc = "GetUserAccountsByUserUserAccountId";
            return (await _db.QueryAsync<UserAccount>(storedProc, new { userUserAccountId = userUserAccountId }, commandType: CommandType.StoredProcedure));
        }

        public async Task<int> Save(UserAccount T)
        {
            var parameters = new 
            {
                id = T.Id,
                name = T.Name
            };
            string storedProc = "SaveUserAccount";
            return (await _db.ExecuteAsync(storedProc, parameters, commandType: CommandType.StoredProcedure));
        }
    }
}
