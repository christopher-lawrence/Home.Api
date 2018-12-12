using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Home.Api.Domain;
using Home.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Home.Api.Features.Room
{
    public class UpdateRoomRequest : IRequest<Models.Room>
    {
        public Models.Room Room { get; set; }
    }

    public class UpdateRoomHandler : IRequestHandler<UpdateRoomRequest, Models.Room>
    {
        private HomeDbContext _dbContext;

        public UpdateRoomHandler(HomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Models.Room> Handle(UpdateRoomRequest request, CancellationToken cancellationToken)
        {
            if (!_dbContext.Rooms.Any(r => r.Id == request.Room.Id))
            {
                return null;
            }
            var room = _dbContext.Rooms.Update(request.Room);
            await _dbContext.SaveChangesAsync();
            return room.Entity;
        }
    }
}
