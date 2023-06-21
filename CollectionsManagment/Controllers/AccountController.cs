using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;
using CollectionsManagment.Models;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.Core.Abstractrions;
using Microsoft.AspNetCore.Authorization;

namespace CollectionsManagment.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAccountService accountService;
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public AccountController(IMapper mapper, IAccountService accountService, IUserService userService, IRoleService roleService) { 
            this.mapper = mapper;
            this.accountService = accountService;
            this.userService = userService;
            this.roleService = roleService;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            //try
            //{
                return View();
            //}
            //catch (Exception ex)
            //{
            //    Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
            //    return BadRequest();
            //}
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationAsync(RegistrationModel model)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    var email = model.Email;

                    if (accountService.IsEmailExist(email) == false)
                    {
                        var entity = await accountService.CreateAccountAsync(mapper.Map<AccountDTO>(model));

                        if (entity > 0)
                        {
                            var accountId = await accountService.GetIdAccountByEmailAsync(email);
                            var IdRole = await roleService.FindRoleIdByRoleName("User");
                            var defaultuser =   userService.CreateDefaultUser(accountId, IdRole);
                            var Userentity = await userService.CreateUserAsync(defaultuser);

                            if (Userentity > 0)
                            {
                                await Authenticate(email);
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
                return View(model);
            //}
            //catch (Exception ex)
            //{
            //    Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
            //    return NotFound();
            //}
        }

        [HttpGet]
        public IActionResult Authentication()
        {
            //try
            //{
                return View();
            //}
            //catch (Exception ex)
            //{
            //    Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
            //    return BadRequest();
            //}
        }

        [HttpPost]
        public async Task<IActionResult> AuthenticationAsync(AuthenticationModel model)
        {
            //try
            //{
                var isPasswordCorrect = await accountService.CheckUserPassword(mapper.Map<AccountDTO>(model));
                if (isPasswordCorrect)
                {
                    await Authenticate(model.Email);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(model);
                }
            //}
            //catch (Exception ex)
            //{
            //    Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
            //    return BadRequest();
            //}

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
        //    try
        //    {
                await HttpContext.SignOutAsync();

                return RedirectToAction("Index", "Home");
            //}
            //catch (Exception ex)
            //{
            //    Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
            //    return BadRequest();
            //}

        } 

        private async Task Authenticate(string email)
        {
            //try
            //{
                var accountId = await accountService.GetIdAccountByEmailAsync(email);

                var UserValuesWithIncludes = await userService.GetUsersByAccountId(accountId);

                var claims = new List<Claim>()
                {
                new Claim(ClaimsIdentity.DefaultNameClaimType, UserValuesWithIncludes.AccountEmail),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, UserValuesWithIncludes.RoleName) };

                if (claims != null)
                {
                    var identity = new ClaimsIdentity(claims,
                        "ApplicationCookie",
                        ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity));
                }
            //}
            //catch (Exception ex)
            //{
            //    Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
            //}

        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult IsLoggedIn()
        {
            //try
            //{
                if (!string.IsNullOrEmpty(HttpContext.User.Identity.Name))
                {
                    return Ok(true);
                }
                else return Ok(false);
            //}
            //catch (Exception ex)
            //{
            //    Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
            //    return NotFound();
            //} 
        }

        [HttpGet]
        public async Task<IActionResult> UserLoginPreview()
        {
            //try
            //{
                if (User.Identities.Any(identity => identity.IsAuthenticated))
                {

                    var accountEmail = User.Identity?.Name;

                    if (string.IsNullOrEmpty(accountEmail))
                    {
                        return NotFound();
                    }

                    var accountId = await accountService.GetIdAccountByEmailAsync(accountEmail);

                    var user = mapper.Map<UserShortDataModel>(await userService.GetUsersByAccountId(accountId));

                    return View(user);
                }
                return View();
            //}
            //catch (Exception ex)
            //{
            //    Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
            //    return NotFound();
            //}

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserDataAsync()
        {
            //try
            //{
                var accountEmail = User.Identity?.Name;
                if (string.IsNullOrEmpty(accountEmail))
                {
                    return BadRequest();
                }
                var accountId = await accountService.GetIdAccountByEmailAsync(accountEmail);
                var user = mapper.Map<UserShortDataModel>(await userService.GetUsersByAccountId(accountId));
                return Ok(user);
            //}
            //catch (Exception ex)
            //{
            //    Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
            //    return NotFound();
            //}

        }

    }
}
