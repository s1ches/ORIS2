using MediatR;
using TeamHost.Shared.Requests.Account.Chat.PostSendMessage;

namespace TeamHost.Application.Features.Account.Chat.PostSendMessage;

public class PostSendMessageCommand
    : PostSendMessageRequest, IRequest<PostSendMessageResponse>
{
    public PostSendMessageCommand(int chatId, PostSendMessageRequest request) : base(request)
    {
        ChatId = chatId;
    }
    
    public int ChatId { get; set; }
}