using System.ComponentModel.DataAnnotations;

namespace TeamHost.Shared.Requests.Account.PatchEditUserInfo;

public class PatchEditUserInfoRequest
{
    public PatchEditUserInfoRequest()
    {
    }

    public PatchEditUserInfoRequest(PatchEditUserInfoRequest request)
    {
        Email = request.Email;
        UserInfoId = request.UserInfoId;
        NickName = request.NickName;
        FirstName = request.FirstName;
        LastName = request.LastName;
        Patronymic = request.Patronymic;
        BirthDay = request.BirthDay;
        About = request.About;
        Country = request.Country;
    }

    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    
    public int UserInfoId { get; set; }

    [DataType(DataType.Text)]
    public string? NickName { get; set; }

    [DataType(DataType.Text)]
    public string? FirstName { get; set; }

    [DataType(DataType.Text)]
    public string? LastName { get; set; }

    [DataType(DataType.Text)]
    public string? Patronymic { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? BirthDay { get; set; }

    [DataType(DataType.Text)]
    public string? About { get; set; }

    [DataType(DataType.Text)]
    public string? Country { get; set; }
}