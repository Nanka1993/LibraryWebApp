using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly ITimeAcquirer _timeAcquirer;

        public TimeController(ITimeAcquirer timeAcquirer)
        {
            _timeAcquirer = timeAcquirer;
        }

        [HttpGet]
        public Task<DateTime> GetCurrentTimeAsync()
        {
            return _timeAcquirer.GetCurrentAsync(HttpContext.RequestAborted);
        }
    }
}
