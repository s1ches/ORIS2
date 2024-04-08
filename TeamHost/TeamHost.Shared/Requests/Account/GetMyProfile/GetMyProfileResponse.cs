namespace TeamHost.Shared.Requests.Account.GetMyProfile;

public class GetMyProfileResponse
{
    public int UserInfoId { get; set; }
    
    public string? NickName { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public string? Patronymic { get; set; }
    
    public DateTime? BirthDay { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public string? About { get; set; }

    public string? Country { get; set; }
}