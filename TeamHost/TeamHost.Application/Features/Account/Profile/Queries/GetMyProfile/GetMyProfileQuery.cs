using MediatR;
using TeamHost.Shared.Requests.Account.GetMyProfile;

namespace TeamHost.Application.Features.Account.Profile.Queries.GetMyProfile;

public class GetMyProfileQuery(string userId) : IRequest<GetMyProfileResponse>
{
    public string UserId { get; set; } = userId;
}