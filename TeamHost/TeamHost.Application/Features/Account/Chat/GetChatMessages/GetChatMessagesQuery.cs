using MediatR;
using TeamHost.Shared.Requests.Account.Chat.GetChatMessages;

namespace TeamHost.Application.Features.Account.Chat.GetChatMessages;

public class GetChatMessagesQuery(GetChatMessagesRequest request)
    : GetChatMessagesRequest(request), IRequest<GetChatMessagesResponse>;