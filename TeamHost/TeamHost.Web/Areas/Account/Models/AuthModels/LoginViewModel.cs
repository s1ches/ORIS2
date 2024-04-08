using System.ComponentModel.DataAnnotations;

namespace TeamHost.Web.Areas.Account.Models.AuthModels;

public class LoginViewModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}