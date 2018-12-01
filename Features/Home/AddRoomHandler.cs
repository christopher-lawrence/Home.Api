using System.Threading;
using System.Threading.Tasks;
using Home.Api.Domain;
using Home.Api.Models;
using MediatR;

namespace Home.Api.Features.Home
{
    public class AddRoomRequest : IRequest<Room>
    {
        public Room Room { get; set; }
    }

    public class AddRoomHandler : IRequestHandler<AddRoomRequest, Room>
    {
        private HomeDbContext _dbContext;

        public AddRoomHandler(HomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Room> Handle(AddRoomRequest request, CancellationToken cancellationToken)
        {
            var room = request.Room;
            room.Floor = new Floor
            {
                RoomId = room.Id,
                Room = room
            };

            var result = await _dbContext.Rooms.AddAsync(room, cancellationToken);
            await _dbContext.Floors.AddAsync(room.Floor, cancellationToken);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
