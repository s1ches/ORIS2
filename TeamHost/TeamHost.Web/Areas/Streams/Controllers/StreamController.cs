using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Streams.Controllers;

[Area("Streams")]
public class StreamController : Controller
{
    public IActionResult Streams() => View();
}