using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Community.Controllers;

[Area("Community")]
public class CommunityController : Controller
{
    public IActionResult Communities() => View();
}