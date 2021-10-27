using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cleanBudget_backend.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private ILogger _logger;

        protected BaseController(ILogger logger)
        {
            _logger = logger;
        }

    }
}
