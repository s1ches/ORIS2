using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TeamHost.Application.Interfaces;

namespace TeamHost.Infrastructure.Services;

public class UserClaimsManager(IHttpContextAccessor contextAccessor) : IUserClaimsManager
{
    public string? UserId => contextAccessor.HttpContext?.User
        .Claims.FirstOrDefault(x => ClaimTypes.NameIdentifier == x.Type)?.Value;
}