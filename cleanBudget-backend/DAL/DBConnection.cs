using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace cleanBudget_backend.DAL
{
    public abstract class DBConnection
    {

        protected readonly IDbConnection _db;

        public DBConnection(IDbConnection db)
        {
            _db = db;
        }
    }
}
