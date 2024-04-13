using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Features.Account.Chat.GetChatMessages;
using TeamHost.Application.Features.Account.Chat.GetChats;
using TeamHost.Shared.Requests.Account.Chat.GetChatMessages;

namespace TeamHost.Web.Areas.Account.Controllers;

[Area("Account")]
[Authorize]
public class ChatController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Chats(CancellationToken cancellationToken)
    {
        var query = new GetChatsQuery();
        var response = await mediator.Send(query, cancellationToken);
        return View(response);
    }

    [HttpGet]
    public async Task<IActionResult> ChatMessages([FromQuery] GetChatMessagesRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetChatMessagesQuery(request);
        var result = await mediator.Send(query, cancellationToken);
    }
}