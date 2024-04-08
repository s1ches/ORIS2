using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Interfaces;
using TeamHost.Shared.Requests.Main.GetAll;

namespace TeamHost.Application.Features.Main.Game.Queries.GetAll;

public class GetAllQueryHandler(IAppDbContext dbContext) : IRequestHandler<GetAllQuery, GetAllResponse>
{
    public async Task<GetAllResponse> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var games = dbContext.Games.AsNoTracking();
        
        var resultList = await dbContext.Games
            .Include(x => x.Platforms)
            .Include(x => x.Categories)
            .Select(x => new GetAllResponseItem
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                PlatformsImageUrls = x.Platforms.Select(x => x.Image.Path).ToList(),
                Categories = x.Categories.Select(x => x.Name).ToList(),
                MainImageUrl = x.MainImage!.Path,
                Rating = x.Rating
            }).ToListAsync(cancellationToken);

        return new GetAllResponse { Games = resultList };

    }
}