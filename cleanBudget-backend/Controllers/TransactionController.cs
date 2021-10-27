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
    public class TransactionController : BaseController
    {
        private readonly ITransactionRepository _repository;
        public TransactionController(ITransactionRepository repository, ILogger logger) : base(logger) 
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{ID}")]
        public async Task<Transaction> GetById(int ID)
        {
            return await _repository.GetById(ID);
        }
        [HttpGet("accountId={accountId}")]
        public async Task<IEnumerable<Transaction>> GetByUserTransactionId(int accountId)
        {
            return await _repository.GetByAccountId(accountId);
        }

        [HttpPost]
        public async Task<int> Save(Transaction Transaction)
        {
            return await _repository.Save(Transaction);
        }
    }
}
