namespace TeamHost.Shared.Requests.Account.Chat.GetChat;

public class GetChatsResponseItem
{
    public int ChatId { get; set; }
    
    public string? ChatTitle { get; set; }
    
    public string? ChatImageUrl { get; set; }

    public string? LastReceivedMessageContent { get; set; } = string.Empty;
    
    public DateTime? LastReceivedMessageTime { get; set; }
    
    public bool HasReadLastReceivedMessage { get; set; }
}