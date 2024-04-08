using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Interfaces;
using TeamHost.Domain.Entities;
using TeamHost.Web.Areas.Account.Models.AuthModels;

namespace TeamHost.Web.Areas.Account.Controllers;

[Area("Account")]
public class AuthController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        var model = new LoginViewModel();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromForm] LoginViewModel model,
        [FromServices] UserManager<IdentityUser> userManager,
        [FromServices] SignInManager<IdentityUser> signInManager)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await userManager.FindByEmailAsync(model.Email);

        if (user is null)
        {
            ModelState.AddModelError(string.Empty, "User with same email not found");
            return View(model);
        }

        var loginResult =
            await signInManager.PasswordSignInAsync(user, model.Password, false, false);

        if (loginResult.Succeeded) 
            return Redirect("/");
        
        ModelState.AddModelError(string.Empty, "Wrong password");
        return View(model);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Logout([FromServices] SignInManager<IdentityUser> signInManager)
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Login", "Auth");
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        var model = new RegisterViewModel();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromForm] RegisterViewModel model,
        [FromServices] UserManager<IdentityUser> userManager,
        [FromServices] SignInManager<IdentityUser> signInManager,
        [FromServices] IAppDbContext dbContext,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = new IdentityUser
        {
            UserName = model.UserName,
            Email = model.Email,
            SecurityStamp = new Guid().ToString()
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault()?.Description ?? "");
            return View(model);
        }

        var createdUser = await userManager.FindByEmailAsync(model.Email);

        var userInfo = new UserInfo
        {
            CreatedDate = DateTime.UtcNow,
            Email = model.Email,
            IdentityUser = createdUser!,
            IdentityUserId = createdUser!.Id
        };

        await dbContext.UserInfos.AddAsync(userInfo, cancellationToken);
        
        await signInManager.SignInAsync(user, false);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Redirect("/");
    }
}