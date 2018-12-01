using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Home.Api.Domain;
using Home.Api.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Home.Api.Features.Home
{
    public class GetRoomsRequest : IRequest<List<Models.Room>>
    {
        public Guid HomeId { get; set; }
    }

    public class GetRoomsHandler : IRequestHandler<GetRoomsRequest, List<Models.Room>>
    {
        private HomeDbContext _dbContext;

        public GetRoomsHandler(HomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Models.Room>> Handle(GetRoomsRequest request, CancellationToken cancellationToken)
        {
            var result = _dbContext.Rooms.Include(r => r.Floor).Include(r => r.Home).Where(r => r.HomeId == request.HomeId);
            return result.ToListAsync();
        }
    }
}
