using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities.Chats;

public class Chat : BaseAuditableEntity
{
    public string? ChatTitle { get; set; }
    
    public StaticFile? ChatImage { get; set; }
    
    public List<UserInfo> UsersInfos { get; set; }
    
    public List<Message> Messages { get; set; }
}