using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Account.Controllers;

[Area("Account")]
public class ProfileController : Controller
{
    [HttpGet]
    public IActionResult MyProfile() => View();
}