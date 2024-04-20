using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Interfaces;
using TeamHost.Domain.Entities.Chats;
using TeamHost.Shared.Requests.Account.Chat.PostSendMessage;

namespace TeamHost.Application.Features.Account.Chat.PostSendMessage;

public class PostSendMessageCommandHandler(IAppDbContext dbContext) : IRequestHandler<PostSendMessageCommand, PostSendMessageResponse>
{
    public async Task<PostSendMessageResponse> Handle(PostSendMessageCommand request, CancellationToken cancellationToken)
    {
        var senderUserInfo = await dbContext.UserInfos
            .Include(x => x.IdentityUserId)
            .FirstOrDefaultAsync(x => x.IdentityUserId == request.SenderId,
                cancellationToken: cancellationToken);
        
        var newMessage = new Message
        {
            SenderUserInfoId = senderUserInfo!.IdentityUserId,
            MessageContent = request.MessageContent,
            CreatedDate = DateTime.UtcNow,
            ChatId = request.ChatId
        };

        await dbContext.Messages.AddAsync(newMessage, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        var response =  await dbContext.Chats
            .Include(x => x.UsersInfos)
            .ThenInclude(x => x.IdentityUser)
            .SelectMany(x => x.UsersInfos.Select(y => y.IdentityUserId))
            .ToListAsync(cancellationToken);

        return new PostSendMessageResponse { SendTo = response };
    }
}