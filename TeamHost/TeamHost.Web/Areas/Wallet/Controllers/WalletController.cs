using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Wallet.Controllers;

[Area("Wallet")]
public class WalletController : Controller
{
    public IActionResult Wallet() => View();
}