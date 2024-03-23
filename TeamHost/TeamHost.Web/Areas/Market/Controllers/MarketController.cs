using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Market.Controllers;

[Area("Market")]
public class MarketController : Controller
{
    public IActionResult Market() => View();
}