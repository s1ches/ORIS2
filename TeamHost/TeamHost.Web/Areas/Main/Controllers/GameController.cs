using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Features.Main.Game.Queries.GetById;

namespace TeamHost.Web.Areas.Main.Controllers;

[Area("Main")]
public class GameController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GameProfile([FromRoute] int gameId, CancellationToken cancellationToken)
    {
        var query = new GetByIdQuery(gameId);
        var response = await mediator.Send(query, cancellationToken);
        return View(response);
    }
}