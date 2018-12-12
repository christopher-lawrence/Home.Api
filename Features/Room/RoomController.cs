using System;
using System.Threading.Tasks;
using Home.Api.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Home.Api.Features.Room
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        private IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<ActionResult<Models.Room>> UpdateRoomAsync([FromBody]Models.Room room)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new UpdateRoomRequest { Room = room });
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Models.Room>> DeleteRoomAsync(Guid id)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new DeleteRoomRequest { Id = id });
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            return BadRequest(ModelState);
        }
    }
}
