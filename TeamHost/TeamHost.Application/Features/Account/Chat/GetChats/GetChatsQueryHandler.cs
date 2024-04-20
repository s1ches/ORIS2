using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Interfaces;
using TeamHost.Shared.Requests.Account.Chat.GetChat;

namespace TeamHost.Application.Features.Account.Chat.GetChats;

public class GetChatsQueryHandler(IAppDbContext dbContext, IUserClaimsManager claimsManager)
    : IRequestHandler<GetChatsQuery, GetChatsResponse>
{
    public async Task<GetChatsResponse> Handle(GetChatsQuery request, CancellationToken cancellationToken)
    {
        var userId = claimsManager.UserId;
           
        var chats = await dbContext.Chats
            .Include(chat => chat.UsersInfos)
            .ThenInclude(userInfo => userInfo.IdentityUser)
            .Where(chat => chat.UsersInfos.Any(userInfo => userInfo.IdentityUserId == claimsManager.UserId))
            .GroupJoin(dbContext.Messages,
                chat => chat.Id,
                message => message.ChatId,
                (chat, messages) 
                    => new 
                    { 
                        Chat = chat,
                        Message = messages.OrderByDescending(m => m.CreatedDate).FirstOrDefault() 
                    })
            .OrderByDescending(result => result.Message!.CreatedDate)
            .Select(result => new GetChatsResponseItem
            {
                ChatId = result.Chat.Id,
                ChatTitle = result.Chat.ChatTitle
                            ?? result.Chat.UsersInfos
                                .First(x => x.IdentityUserId != userId).IdentityUser.UserName,
                LastReceivedMessageContent = result.Message != null ? result.Message.MessageContent : null,
                LastReceivedMessageTime = result.Message != null ? result.Message.CreatedDate : null,
                ChatImageUrl = result.Chat.ChatImage == null ? "" : result.Chat.ChatImage.Path,
                HasReadLastReceivedMessage = result.Message == null || result.Message.HasRead
            })
            .ToListAsync(cancellationToken);
        
        return new GetChatsResponse { Chats = chats };
    }
}