using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Friends.Controllers;

[Area("Friends")]
public class FriendController : Controller
{
    public IActionResult Friends() => View();
}