namespace TeamHost.Shared.Requests.Account.Chat.GetChatMessages;

public class GetChatMessagesResponseItem
{
    public DateTime? SendDate { get; set; }
    
    public string MessageSenderUserId { get; set; }
    
    public string MessageSenderName { get; set; }
    
    public string MessageContent { get; set; }
}