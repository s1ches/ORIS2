using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Games.Controllers;

[Area("Games")]
public class GameController : Controller
{
    public IActionResult Game() => View();
}