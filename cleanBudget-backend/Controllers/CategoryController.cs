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
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository _repository;
        public CategoryController(ICategoryRepository repository, ILogger logger) : base(logger) 
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{ID}")]
        public async Task<Category> GetById(int ID)
        {
            return await _repository.GetById(ID);
        }

        [HttpPost]
        public async Task<int> Save(Category Category)
        {
            return await _repository.Save(Category);
        }
    }
}
