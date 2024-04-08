using System.Security.Claims;

namespace TeamHost.Application.Interfaces;

public interface IUserClaimsManager
{
    string? GetUserId(ClaimsPrincipal user);
}