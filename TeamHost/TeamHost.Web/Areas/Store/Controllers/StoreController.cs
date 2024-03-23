using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Store.Controllers;

[Area("Store")]
public class StoreController : Controller
{
    public IActionResult Store() => View();
}