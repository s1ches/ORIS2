using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Main.Controllers;

[Area("Main")]
public class StreamController(HttpClient client) : Controller
{
    public IActionResult Streams() => View();

    public IActionResult StreamPage() => View();
}