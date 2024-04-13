using MediatR;
using TeamHost.Shared.Requests.Account.Chat.GetChatMessages;

namespace TeamHost.Application.Features.Account.Chat.GetChatMessages;

public class GetChatMessagesQueryHandler : IRequestHandler<GetChatMessagesQuery, GetChatMessagesResponse>
{
    public Task<GetChatMessagesResponse> Handle(GetChatMessagesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}