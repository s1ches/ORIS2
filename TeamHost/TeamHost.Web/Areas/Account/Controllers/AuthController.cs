using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Account.Controllers;

[Area("Account")]
public class AuthController : Controller
{
    [HttpGet]
    public IActionResult Login() => View();

    [HttpGet] 
    public IActionResult Register() => View();
}