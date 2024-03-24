using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Main.Controllers;

[Area("Main")]
public class GameController : Controller
{
    public IActionResult GameProfile() => View();
}