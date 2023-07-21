using AutoMapper; 
using CollectionsManagment.Core.Abstractrions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CollectionsManagment.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class LikeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IItemService itemService;
        private readonly ILikesService likesService;
        private readonly IUserService userService;
        private readonly IAccountService accountService;

        public LikeController(IItemService itemService, IMapper mapper, ILikesService likesService, IUserService userService, IAccountService accountService)
        {
            this.itemService = itemService;
            this.mapper = mapper;
            this.likesService = likesService;
            this.userService = userService;
            this.accountService = accountService;

        }

        public async Task<IActionResult> CreateLikeAsync(int itemId)
        {
            try
            {

                var email = User.Identity.Name;
                var accId = await accountService.GetIdAccountByEmailAsync(email);
                var user = await userService.GetUsersByAccountId(accId);

                var res = await likesService.CreateLikeAsync(itemId, user.Id);

                if (res == 1)
                {
                    return StatusCode(201);
                }
                else return StatusCode(304);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }
        }
    }
}
