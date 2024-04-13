using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Interfaces;
using TeamHost.Shared.Requests.Account.Chat;
using TeamHost.Shared.Requests.Account.Chat.GetChat;

namespace TeamHost.Application.Features.Account.Chat.GetChats;

public class GetChatsQueryHandler(IAppDbContext dbContext, IUserClaimsManager claimsManager)
    : IRequestHandler<GetChatsQuery, GetChatsResponse>
{
    public async Task<GetChatsResponse> Handle(GetChatsQuery request, CancellationToken cancellationToken)
    {
        var chats = await dbContext.Chats
            .Where(chat => chat.UsersInfos.Any(userInfo => userInfo.IdentityUserId == claimsManager.UserId))
            .GroupJoin(dbContext.Messages,
                chat => chat.Id,
                message => message.ChatId,
                (chat, messages) 
                    => new 
                    { 
                        Chat = chat,
                        Messages = messages.OrderByDescending(m => m.CreatedDate).FirstOrDefault() 
                    })
            .OrderByDescending(result => result.Messages!.CreatedDate)
            .Select(result => new GetChatsResponseItem
            {
                ChatId = result.Chat.Id,
                ChatTitle = result.Chat.ChatTitle,
                LastReceivedMessageContent = result.Messages != null ? result.Messages.MessageContent : null,
                LastReceivedMessageTime = result.Messages != null ? (DateTime?)result.Messages.CreatedDate : null
            })
            .ToListAsync(cancellationToken);
        
        return new GetChatsResponse { Chats = chats };
    }
}