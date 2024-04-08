using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Features.Main.Game.Queries.GetAll;

namespace TeamHost.Web.Areas.Main.Controllers;

[Area("Main")]
public class StoreController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GameStore(CancellationToken cancellationToken)
    {
        var query = new GetAllQuery();
        var response = await mediator.Send(query, cancellationToken);
        return View(response);
    }
}