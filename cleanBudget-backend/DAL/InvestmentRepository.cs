using cleanBudget_BL.BusinessObjects;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace cleanBudget_backend.DAL
{
    public class InvestmentRepository : IInvestmentRepository
    {
        protected readonly IDbConnection _db;

        public InvestmentRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Investment>> GetAll()
        {
            string storedProc = "GetAllInvestments";
            return (await _db.QueryAsync<Investment>(storedProc, commandType: CommandType.StoredProcedure));
        }

        public async Task<Investment> GetById(int id)
        {
            string storedProc = "GetInvestmentsById";
            return (await _db.QueryFirstAsync<Investment>(storedProc, new { id = id }, commandType: CommandType.StoredProcedure));
        }


        public async Task<int> Save(Investment T)
        {
            var parameters = new
            {
                id = T.ID,
                name = T.Name,
                ticker = T.Ticker,
                amount = T.Amount,
                cost = T.Cost,
                purchaseDate = T.PurchaseDate,
                accountId = T.AccountID
            };
            string storedProc = "SaveInvestment";
            return (await _db.ExecuteAsync(storedProc, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<Investment>> GetByAccountId(int accountId)
        {
            string storedProc = "GetInvestmentsById";
            return (await _db.QueryAsync<Investment>(storedProc, new { accountId = accountId }, commandType: CommandType.StoredProcedure));
        }
    }
}
