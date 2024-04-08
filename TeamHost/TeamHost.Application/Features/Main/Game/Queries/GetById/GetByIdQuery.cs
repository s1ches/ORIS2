using MediatR;
using TeamHost.Shared.Requests.Main.GetById;

namespace TeamHost.Application.Features.Main.Game.Queries.GetById;

public class GetByIdQuery(int gameId) : IRequest<GetByIdResponse>
{
    public int GameId { get; set; } = gameId;
}