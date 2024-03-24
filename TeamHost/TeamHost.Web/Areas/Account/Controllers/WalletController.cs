using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Account.Controllers;

[Area("Account")]
public class WalletController : Controller
{
    [HttpGet]
    public IActionResult MyWallet() => View();
}