using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities.Chats;

public class Message : BaseAuditableEntity
{
    public string? MessageContent { get; set; }
    
    public string SenderUserInfoId { get; set; }
    
    public UserInfo SenderUserInfo { get; set; }
    
    public bool HasRead { get; set; }
    
    public int ChatId { get; set; }
    
    public Chat Chat { get; set; }
}