using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Main.Controllers;

[Area("Main")]
public class CommunityController : Controller
{
    public IActionResult Communities() => View();
}