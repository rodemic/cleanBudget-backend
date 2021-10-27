using cleanBudget_backend.DAL;
using cleanBudget_BL.BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cleanBudget_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountRepository _repository;
        public AccountController(IAccountRepository repository, ILogger logger) : base(logger) 
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{ID}")]
        public async Task<Account> GetById(int ID)
        {
            return await _repository.GetById(ID);
        }
        [HttpGet("UserAccountID={userAccountID}")]
        public async Task<IEnumerable<Account>> GetByUserAccountId(int userAccountID)
        {
            return await _repository.GetByUserAccountId(userAccountID);
        }

        [HttpPost]
        public async Task<int> Save(Account account)
        {
            return await _repository.Save(account);
        }
    }
}
