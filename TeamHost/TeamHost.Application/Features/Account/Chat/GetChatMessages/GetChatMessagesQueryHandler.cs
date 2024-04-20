using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Interfaces;
using TeamHost.Shared.Requests.Account.Chat.GetChatMessages;

namespace TeamHost.Application.Features.Account.Chat.GetChatMessages;

public class GetChatMessagesQueryHandler(IAppDbContext dbContext, IUserClaimsManager claimsManager)
    : IRequestHandler<GetChatMessagesQuery, GetChatMessagesResponse>
{
    public async Task<GetChatMessagesResponse> Handle(GetChatMessagesQuery request, CancellationToken cancellationToken)
    {
        if (claimsManager.UserId == null)
            return new GetChatMessagesResponse();

        var userId = claimsManager.UserId;

        var hasUserThisChat = dbContext.Chats
            .Include(chat => chat.UsersInfos)
            .Any(chat => chat.Id == request.ChatId && chat.UsersInfos
                .Select(x => x.IdentityUserId)
                .Contains(userId));
        
        if (!hasUserThisChat)
            return new GetChatMessagesResponse();

        var messagesFromDb = await dbContext.Messages
            .Include(message => message.SenderUserInfo)
            .ThenInclude(x => x.IdentityUser)
            .Where(message => message.ChatId == request.ChatId)
            .OrderBy(message => message.CreatedDate)
            .Take(50)
            .ToListAsync(cancellationToken);

        foreach (var message in messagesFromDb)
            message.HasRead = true;
        
        var messages = messagesFromDb
            .Select(message => new GetChatMessagesResponseItem
            {
                MessageContent = message.MessageContent ?? string.Empty,
                MessageSenderName = message.SenderUserInfo.IdentityUser.UserName
                                     ?? (message.SenderUserInfo.FirstName + message.SenderUserInfo.LastName),
                MessageSenderUserId = message.SenderUserInfo.IdentityUserId,
                SendDate = message.CreatedDate
            }).ToList();

        var response = await dbContext.Chats
            .Include(x => x.UsersInfos)
            .ThenInclude(x => x.IdentityUser)
            .FirstAsync(x => x.Id == request.ChatId, cancellationToken: cancellationToken);
        
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return new GetChatMessagesResponse
        {
            Messages = messages,
            ChatId = request.ChatId,
            ChatImage = response.ChatImage?.Path,
            ChatTitle = response.ChatTitle
                                    ?? response.UsersInfos
                                        .First(x => x.IdentityUserId != userId).IdentityUser.UserName
        };
    }
}