using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Home.Api.Domain;
using MediatR;

namespace Home.Api.Features.Room
{
    public class DeleteRoomRequest : IRequest<Models.Room>
    {
        public Guid Id { get; set; }
    }

    public class DeleteRoomHandler : IRequestHandler<DeleteRoomRequest, Models.Room>
    {
        private HomeDbContext _dbContext;

        public DeleteRoomHandler(HomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Models.Room> Handle(DeleteRoomRequest request, CancellationToken cancellationToken)
        {
            var room = _dbContext.Rooms.FirstOrDefault(r => r.Id == request.Id);
            if (room == null)
            {
                return null;
            }
            var homes = _dbContext.Homes.Where(h => h.Rooms.Any(r => r.Id == request.Id));
            foreach (var home in homes)
            {
                home.Rooms.Remove(room);
            }
            var result = _dbContext.Rooms.Remove(room);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
