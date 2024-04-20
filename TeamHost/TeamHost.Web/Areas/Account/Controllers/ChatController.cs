using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Features.Account.Chat.GetChatMessages;
using TeamHost.Application.Features.Account.Chat.GetChats;
using TeamHost.Application.Features.Account.Chat.PostSendMessage;
using TeamHost.Shared.Requests.Account.Chat.GetChatMessages;
using TeamHost.Shared.Requests.Account.Chat.PostSendMessage;

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
        return PartialView(response);
    }
    
    [HttpGet]
    public  IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> ChatMessages([FromQuery] GetChatMessagesRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetChatMessagesQuery(request);
        var response = await mediator.Send(query, cancellationToken);
        return PartialView(response);
    }
    
    [HttpPost("SendMessage/{chatId}")]
    public async Task<IActionResult> SendMessageAsync(
        [FromRoute] int chatId,
        [FromBody] PostSendMessageRequest request,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new PostSendMessageCommand(chatId, request), cancellationToken);
        return Ok();
    }
}