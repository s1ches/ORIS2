using MediatR;
using TeamHost.Shared.Requests.Main.GetById;

namespace TeamHost.Application.Features.Main.Game.Queries.GetById;

public class GetByIdQuery : GetByIdRequest, IRequest<GetByIdResponse>
{
    public GetByIdQuery(GetByIdRequest request) : base(request)
    {
    }

    public GetByIdQuery()
    {
    }
}