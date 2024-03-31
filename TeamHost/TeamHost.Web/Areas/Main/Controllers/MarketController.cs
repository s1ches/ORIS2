using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Features.Main.Game.Queries.GetAll;
using TeamHost.Shared.Requests.Main.GetAll;

namespace TeamHost.Web.Areas.Main.Controllers;

[Area("Main")]
public class MarketController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Market(CancellationToken cancellationToken)
    {
        var query = new GetAllQuery();
        var response = await mediator.Send(query, cancellationToken);
        return View(response);
    }
}