using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Common.Exceptions;
using TeamHost.Application.Interfaces;
using TeamHost.Shared.Requests.Account.GetMyProfile;

namespace TeamHost.Application.Features.Account.Profile.Queries.GetMyProfile;

public class GetMyProfileQueryHandler(IAppDbContext dbContext) 
    : IRequestHandler<GetMyProfileQuery, GetMyProfileResponse>
{
    public async Task<GetMyProfileResponse> Handle(GetMyProfileQuery request, CancellationToken cancellationToken)
    {
        var userInfos = dbContext.UserInfos.AsNoTracking();

        var result = await userInfos
            .Include(x => x.IdentityUser)
            .Include(x => x.Country)
            .FirstOrDefaultAsync(x => x.IdentityUserId == request.UserId,
                cancellationToken: cancellationToken);

        if (result is null)
            throw new NotFoundException($"User with id: {request.UserId} was not found");

        return new GetMyProfileResponse
        {
            UserInfoId = result.Id,
            NickName = result.IdentityUser.UserName,
            FirstName = result.FirstName,
            LastName = result.LastName,
            Patronymic = result.Patronymic,
            BirthDay = result.BirthDay,
            CreatedDate = result.CreatedDate,
            About = result.About,
            Country = result.Country?.Name
        };
    }
}