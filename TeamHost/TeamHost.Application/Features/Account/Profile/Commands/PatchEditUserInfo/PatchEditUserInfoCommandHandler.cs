using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Common.Exceptions;
using TeamHost.Application.ConstantValues;
using TeamHost.Application.Interfaces;

namespace TeamHost.Application.Features.Account.Profile.Commands.PatchEditUserInfo;

public class PatchEditUserInfoCommandHandler(IAppDbContext dbContext)
    : IRequestHandler<PatchEditUserInfoCommand>
{
    public async Task Handle(PatchEditUserInfoCommand request, CancellationToken cancellationToken)
    {
        var userInfo = await dbContext
            .UserInfos
            .Include(x => x.Country)
            .Include(x => x.IdentityUser)
            .FirstOrDefaultAsync(x => x.Id == request.UserInfoId,
                cancellationToken: cancellationToken);

        if (userInfo is null)
            throw new NotFoundException($"User info with id: {request.UserInfoId} was not found");

        if (request.Country != null && request.Country != userInfo.Country?.Name)
        {
            var country = await dbContext.Countries.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name.ToLower() == request.Country.ToLower(),
                    cancellationToken: cancellationToken);

            userInfo.Country = country;
        }

        userInfo.IdentityUser.UserName = request.NickName != userInfo.IdentityUser.UserName 
            ? request.NickName
            : userInfo.IdentityUser.UserName;
        
        userInfo.About = request.About != userInfo.About 
            ? request.About 
            : userInfo.About;
        
        userInfo.Email = (request.Email != userInfo.Email  
            ? request.Email 
            : userInfo.Email)!;

        userInfo.IdentityUser.Email = (request.Email != userInfo.Email
            ? request.Email
            : userInfo.Email)!;
        
        userInfo.FirstName = request.FirstName ?? userInfo.FirstName;
        userInfo.LastName = request.LastName ?? userInfo.LastName;
        userInfo.Patronymic = request.Patronymic ?? userInfo.Patronymic;

        if (request.BirthDay != null)
            userInfo.BirthDay = request.BirthDay.Value.AddHours(3).ToUniversalTime();

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}