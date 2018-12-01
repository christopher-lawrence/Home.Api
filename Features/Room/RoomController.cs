using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Home.Api.Features.Room
{
    public class RoomController : Controller
    {
        private IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

    }
}
