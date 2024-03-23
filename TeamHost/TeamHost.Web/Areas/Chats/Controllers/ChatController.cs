using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Chats.Controllers;

[Area("Chats")]
public class ChatController : Controller
{
    public IActionResult Chats() => View();
}