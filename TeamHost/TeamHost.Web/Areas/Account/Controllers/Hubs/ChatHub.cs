using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using TeamHost.Application.Features.Account.Chat.PostSendMessage;
using TeamHost.Domain.Entities.Chats;
using TeamHost.Shared.Requests.Account.Chat.PostSendMessage;
using TeamHost.Web.Areas.Account.Models;

namespace TeamHost.Web.Areas.Account.Controllers.Hubs;

public class ChatHub(IMediator mediator) : Hub
{
    private static readonly List<string> UsersOnline = [];
    
    /// <inheritdoc />
    public override async Task OnConnectedAsync()
    {
        var userId = Context.GetHttpContext()?.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        UsersOnline.Add(userId!);
        
        await Clients.All.SendAsync("OnConnection", new
        {
            _usersOnline = UsersOnline
        });
    }
    
    public async Task SendMessage(SendMessageModel request)
    {
        await Clients
            .Users(response.SendTo)
            .SendAsync("ReceiveMessage", new
            {
                request.MessageContent,
                request.SenderId,
                request.SenderName,
                request.ChatId
            });
    }

    /// <inheritdoc />
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = Context.GetHttpContext()?.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        UsersOnline.Remove(userId!);
        await Clients.All
            .SendAsync(
                "OnDisconnected", new
                {
                    userId
                });
    }
}