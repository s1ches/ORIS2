using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Account.Controllers;

[Area("Account")]
public class FavoriteController : Controller
{
    [HttpGet]
    public IActionResult Favorites() => View();
}