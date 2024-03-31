using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Features.Main.Game.Queries.GetById;
using TeamHost.Shared.Requests.Main.GetById;

namespace TeamHost.Web.Areas.Main.Controllers;

[Area("Main")]
public class GameController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GameProfile(GetByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetByIdQuery(request);
        var response = await mediator.Send(query, cancellationToken);
        return View(response);
    }
}