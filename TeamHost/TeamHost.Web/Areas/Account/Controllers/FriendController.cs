using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Account.Controllers;

[Area("Account")]
public class FriendController : Controller
{
    [HttpGet]
    public IActionResult Friends() => View();
}