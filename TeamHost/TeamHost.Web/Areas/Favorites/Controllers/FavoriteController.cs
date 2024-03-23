using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Favorites.Controllers;

[Area("Favorites")]
public class FavoriteController : Controller
{
    public IActionResult Favorites() => View();
}