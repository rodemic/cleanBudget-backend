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
    public class UserAccountController : BaseController
    {
        private readonly IUserAccountRepository _repository;
        public UserAccountController(IUserAccountRepository repository, ILogger logger) : base(logger) 
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<UserAccount>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{ID}")]
        public async Task<UserAccount> GetById(int ID)
        {
            return await _repository.GetById(ID);
        }

        [HttpPost]
        public async Task<int> Save(UserAccount UserAccount)
        {
            return await _repository.Save(UserAccount);
        }
    }
}
