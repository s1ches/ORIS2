using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Features.Main.Game.Queries.GetAll;

namespace TeamHost.Web.Areas.Main.Controllers;

[Area("Main")]
public class MarketController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Market(CancellationToken cancellationToken)
    {
        return View();
    }
}