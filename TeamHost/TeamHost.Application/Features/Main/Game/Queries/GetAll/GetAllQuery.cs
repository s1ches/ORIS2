using MediatR;
using TeamHost.Shared.Requests.Main.GetAll;

namespace TeamHost.Application.Features.Main.Game.Queries.GetAll;

public class GetAllQuery : IRequest<GetAllResponse>;