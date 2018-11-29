using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Home.Api.Models;
using MediatR;

namespace Home.Api.Features.Home
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [Route("add")]
        public async Task<Models.Home> AddHomeAsync([FromBody]Models.Home home)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("bad state");
            }
            var result = await _mediator.Send(new AddHomeRequest { Home = home });
            return result.Home;
        }

        [HttpGet]
        [Route("get/{id}")]
        public Task<Models.Home> GetHomeAsync(Guid id)
        {
            return _mediator.Send(new GetHomeRequest { Id = id });
        }

        [HttpPut]
        [Route("update/{id}")]
        public Task<Models.Home> UpdateHomeAsync(Guid id, [FromBody]Models.Home home)
        {
            if (id != home.Id)
            {
                return null;
            }
            return _mediator.Send(new UpdateHomeRequest { Home = home });
        }
    }
}
