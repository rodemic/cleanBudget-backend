using cleanBudget_BL.BusinessObjects;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace cleanBudget_backend.DAL
{
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly IDbConnection _db;

        public CategoryRepository(IDbConnection db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            string storedProc = "GetAllCategories";
            return (await _db.QueryAsync<Category>(storedProc, commandType: CommandType.StoredProcedure));
        }

        public async Task<Category> GetById(int id)
        {
            string storedProc = "GetCategoriesById";
            return (await _db.QueryFirstAsync<Category>(storedProc, new { id = id }, commandType: CommandType.StoredProcedure));
        }


        public async Task<int> Save(Category T)
        {
            var parameters = new
            {
                id = T.Id,
                name = T.Name,
                description = T.Description,
                hexCode = T.HexCode
            };
            string storedProc = "SaveCategory";
            return (await _db.ExecuteAsync(storedProc, parameters, commandType: CommandType.StoredProcedure));
        }
    }
}
