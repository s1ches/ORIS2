using System.ComponentModel.DataAnnotations;

namespace TeamHost.Web.Areas.Account.Models.AuthModels;

public class RegisterViewModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    public string UserName { get; set; }
}