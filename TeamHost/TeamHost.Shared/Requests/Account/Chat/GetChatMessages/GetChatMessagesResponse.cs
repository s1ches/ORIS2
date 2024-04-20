namespace TeamHost.Shared.Requests.Account.Chat.GetChatMessages;

public class GetChatMessagesResponse
{
    public int ChatId { get; set; }
    
    public string? ChatTitle { get; set; }
    
    public string? ChatImage { get; set; }
    
    public List<GetChatMessagesResponseItem>? Messages { get; set; }
}