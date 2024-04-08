namespace TeamHost.Shared.Requests.Account.PatchEditUserInfo;

public class PatchEditUserInfoRequest(PatchEditUserInfoRequest request)
{
    public string? Email { get; set; } = request.Email;
    
    public int UserInfoId { get; set; } = request.UserInfoId;

    public string? NickName { get; set; } = request.NickName;

    public string? FirstName { get; set; } = request.FirstName;

    public string? LastName { get; set; } = request.LastName;

    public string? Patronymic { get; set; } = request.Patronymic;

    public DateTime? BirthDay { get; set; } = request.BirthDay;

    public string? About { get; set; } = request.About;

    public string? Country { get; set; } = request.Country;
}