using MediatR;
using TeamHost.Shared.Requests.Main.GetById;

namespace TeamHost.Application.Features.Main.Game.Queries.GetById;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdResponse>
{
    public Task<GetByIdResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}