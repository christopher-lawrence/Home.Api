using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Home.Api.Models;
using MediatR;
using Home.Api.Domain;

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
        [Route("{id}")]
        public Task<Models.Home> GetHomeAsync(Guid id)
        {
            return _mediator.Send(new GetHomeRequest { Id = id });
        }

        [HttpPut]
        [Route("update/{id}")]
        public Task<Models.Home> UpdateHomeAsync(Guid id, [FromBody]Models.Home home)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("bad state");
            }
            if (id != home.Id)
            {
                return null;
            }
            return _mediator.Send(new UpdateHomeRequest { Home = home });
        }

        [HttpPost]
        [Route("{id}/room/add")]
        public Task<Room> AddRoomAsync(Guid id, [FromBody]Room room)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("bad state");
            }
            room.HomeId = id;
            return _mediator.Send(new AddRoomRequest { Room = room });
        }

        [HttpGet]
        [Route("{id}/rooms")]
        public Task<List<Room>> GetRoomsAsync(Guid id)
        {
            return _mediator.Send(new GetRoomsRequest { HomeId = id });
        }

    }
}
