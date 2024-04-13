using MediatR;
using TeamHost.Shared.Requests.Account.GetMyProfile;

namespace TeamHost.Application.Features.Account.Profile.Queries.GetMyProfile;

public class GetMyProfileQuery() : IRequest<GetMyProfileResponse>;