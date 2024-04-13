using Microsoft.AspNetCore.Identity;
using TeamHost.Domain.Common;
using TeamHost.Domain.Entities.Chats;

namespace TeamHost.Domain.Entities;

public class UserInfo : BaseEntity
{
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public string? Patronymic { get; set; }
    
    public DateTime? BirthDay { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public string? About { get; set; }
    
    public Country? Country { get; set; }
    
    public string Email { get; set; }
    
    public string IdentityUserId { get; set; }
    
    public IdentityUser IdentityUser { get; set; } 
    
    public List<Chat> Chats { get; set; }
}