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
    public class InvestmentController : BaseController
    {
        private readonly IInvestmentRepository _repository;
        public InvestmentController(IInvestmentRepository repository, ILogger logger) : base(logger) 
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Investment>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{ID}")]
        public async Task<Investment> GetById(int ID)
        {
            return await _repository.GetById(ID);
        }
        [HttpGet("accountId={accountId}")]
        public async Task<IEnumerable<Investment>> GetByAccountId(int accountId)
        {
            return await _repository.GetByAccountId(accountId);
        }

        [HttpPost]
        public async Task<int> Save(Investment Investment)
        {
            return await _repository.Save(Investment);
        }
    }
}
