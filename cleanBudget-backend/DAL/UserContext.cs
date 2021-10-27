using cleanBudget_BL.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace cleanBudget_backend.DAL
{
    public class UserContext : DbContext
    {
        public UserContext() : base()
        {
        }

        public DbSet<FinancialAccount> FinancialAccounts { get; set; }
        public DbSet<InvestmentAccount> InvestmentAccounts { get; set; }

    }
}
