using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Main.Controllers;

[Area("Main")]
public class StreamController : Controller
{
    public IActionResult Streams() => View();
}