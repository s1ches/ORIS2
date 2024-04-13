using MediatR;
using TeamHost.Shared.Requests.Account.Chat;
using TeamHost.Shared.Requests.Account.Chat.GetChat;

namespace TeamHost.Application.Features.Account.Chat.GetChats;

public class GetChatsQuery : IRequest<GetChatsResponse>;
