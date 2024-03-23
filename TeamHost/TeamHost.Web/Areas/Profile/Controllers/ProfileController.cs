using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Profile.Controllers;

[Area("Profile")]
public class ProfileController : Controller
{
    public IActionResult MyProfile() => View();
}