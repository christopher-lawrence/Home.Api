using System;
using System.Threading;
using System.Threading.Tasks;
using Home.Api.Domain;
using Home.Api.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Home.Api.Features.Home
{
    public class GetHomeRequest : IRequest<Models.Home>
    {
        public Guid Id { get; set; }
    }

    public class GetHomeHandler : IRequestHandler<GetHomeRequest, Models.Home>
    {
        private HomeDbContext _dbContext;

        public GetHomeHandler(HomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Models.Home> Handle(GetHomeRequest request, CancellationToken cancellationToken)
        {
            return _dbContext.Homes.FirstOrDefaultAsync(h => h.Id == request.Id);
        }
    }
}
