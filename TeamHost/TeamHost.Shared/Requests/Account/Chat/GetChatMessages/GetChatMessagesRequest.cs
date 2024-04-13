namespace TeamHost.Shared.Requests.Account.Chat.GetChatMessages;

public class GetChatMessagesRequest
{
    public GetChatMessagesRequest(GetChatMessagesRequest request) => ChatId = request.ChatId;

    public GetChatMessagesRequest(){ }
    
    public int ChatId { get; set; }
}