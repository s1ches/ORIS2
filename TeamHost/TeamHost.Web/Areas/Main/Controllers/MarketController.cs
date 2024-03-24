using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Main.Controllers;

[Area("Main")]
public class MarketController : Controller
{
    public IActionResult Market() => View();
}