using System;
using System.Threading;
using System.Threading.Tasks;
using Home.Api.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Home.Api.Features.Home
{
    public class AddHomeRequest : IRequest<AddHomeResponse>
    {
        public Models.Home Home { get; set; }
    }

    public class AddHomeResponse
    {
        public Models.Home Home { get; set; }
    }

    public class AddHomeHandler : IRequestHandler<AddHomeRequest, AddHomeResponse>
    {
        private HomeDbContext _dbContext;
        public AddHomeHandler(HomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddHomeResponse> Handle(AddHomeRequest request, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(request.Home, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new AddHomeResponse { Home = request.Home };
        }
    }
}
