using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Home.Api.Domain;
using MediatR;

namespace Home.Api.Features.Home
{
    public class DeleteRoomReqeust : IRequest
    {
        public Guid HomeId { get; set; }
        public Guid RoomId { get; set; }
    }

    public class DeleteRoomHandler : IRequestHandler<DeleteRoomReqeust>
    {
        private HomeDbContext _dbContext;
        public DeleteRoomHandler(HomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteRoomReqeust request, CancellationToken cancellationToken)
        {
            var room = _dbContext.Rooms.FirstOrDefault(r => r.Id == request.RoomId && r.HomeId == request.HomeId);
            if (room != null)
            {
                _dbContext.Rooms.Remove(room);
                await _dbContext.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
