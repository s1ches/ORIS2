using System.Security.Claims;
using TeamHost.Application.Interfaces;

namespace TeamHost.Infrastructure.Services;

public class UserClaimsManager : IUserClaimsManager
{
    public string? GetUserId(ClaimsPrincipal user)
        => user.Claims.FirstOrDefault(x => ClaimTypes.NameIdentifier == x.Type)?.Value;
}