using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Features.Account.Profile.Queries.GetMyProfile;
using TeamHost.Application.Interfaces;

namespace TeamHost.Web.Areas.Account.Controllers;

[Area("Account")]
public class ProfileController(IMediator mediator) : Controller
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> MyProfile([FromServices] IUserClaimsManager claimsManager,
        CancellationToken cancellationToken)
    {
        var id = claimsManager.GetUserId(User);

        var query = new GetMyProfileQuery(id!);
        var response = await mediator.Send(query, cancellationToken);
        
        return View(response);
    }
}