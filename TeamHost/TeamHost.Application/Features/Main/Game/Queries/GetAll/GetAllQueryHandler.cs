using MediatR;
using TeamHost.Shared.Requests.Main.GetAll;

namespace TeamHost.Application.Features.Main.Game.Queries.GetAll;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, GetAllResponse>
{
    public Task<GetAllResponse> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}