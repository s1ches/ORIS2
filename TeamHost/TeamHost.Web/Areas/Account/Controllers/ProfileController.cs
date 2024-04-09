using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Features.Account.Profile.Commands.PatchEditUserInfo;
using TeamHost.Application.Features.Account.Profile.Queries.GetMyProfile;
using TeamHost.Application.Interfaces;
using TeamHost.Shared.Requests.Account.PatchEditUserInfo;

namespace TeamHost.Web.Areas.Account.Controllers;

[Area("Account")]
[Authorize]
public class ProfileController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> MyProfile([FromServices] IUserClaimsManager claimsManager,
        CancellationToken cancellationToken)
    {
        var id = claimsManager.GetUserId(User);

        var query = new GetMyProfileQuery(id!);
        var response = await mediator.Send(query, cancellationToken);
        
        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> EditProfile([FromForm] PatchEditUserInfoRequest request,
        CancellationToken cancellationToken)
    {
        var query = new PatchEditUserInfoCommand(request);
        await mediator.Send(query, cancellationToken);
        return RedirectToAction("MyProfile");
    }
}