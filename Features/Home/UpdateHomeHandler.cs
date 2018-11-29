using System.Threading;
using System.Threading.Tasks;
using Home.Api.Domain;
using Home.Api.Models;
using MediatR;

namespace Home.Api.Features.Home
{
    public class UpdateHomeRequest : IRequest<Models.Home>
    {
        public Models.Home Home { get; set; }
    }

    public class UpdateHomeHandler : IRequestHandler<UpdateHomeRequest, Models.Home>
    {
        private HomeDbContext _dbContext;

        public UpdateHomeHandler(HomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Models.Home> Handle(UpdateHomeRequest request, CancellationToken cancellationToken)
        {
            var updatedHome = _dbContext.Homes.Update(request.Home);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return request.Home;
        }
    }
}
