using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Common.Exceptions;
using TeamHost.Application.Interfaces;
using TeamHost.Shared.Requests.Main.GetById;

namespace TeamHost.Application.Features.Main.Game.Queries.GetById;

public class GetByIdQueryHandler(IAppDbContext dbContext) : IRequestHandler<GetByIdQuery, GetByIdResponse>
{
    public async Task<GetByIdResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var game = await dbContext.Games.AsNoTracking()
            .Include(x => x.Platforms)
            .Include(x => x.Categories)
            .Include(x => x.Images)
            .Include(x => x.CompanyDeveloper)
            .FirstOrDefaultAsync(x => x.Id == request.GameId, cancellationToken: cancellationToken);

        if (game is null)
            throw new NotFoundException($"Game with id: {request.GameId} was not found");

        return new GetByIdResponse
        {
            Id = game.Id,
            Name = game.Name,
            Price = game.Price,
            PlatformsImageUrls = game.Platforms.Select(x => x.Image.Path).ToList(),
            Categories = game.Categories.Select(x => x.Name).ToList(),
            MainImageUrl = game.MainImage!.Path,
            Rating = game.Rating,
            Description = game.Description,
            ImagesUrls = game.Images.Select(x => x.Path).ToList(),
            CompanyName = game.CompanyDeveloper.Name
        };
    }
}