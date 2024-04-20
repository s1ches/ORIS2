namespace TeamHost.Shared.Requests.Account.Chat.PostSendMessage;

public class PostSendMessageRequest
{
    public PostSendMessageRequest()
    {
    }
    
    public PostSendMessageRequest(PostSendMessageRequest request)
    {
        Message = request.Message;
    }
    
    public string Message { get; set; } = default!;
}