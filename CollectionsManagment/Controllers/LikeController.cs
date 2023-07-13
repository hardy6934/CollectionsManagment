using AutoMapper; 
using CollectionsManagment.Core.Abstractrions; 
using Microsoft.AspNetCore.Mvc;

namespace CollectionsManagment.Controllers
{
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
            var email = User.Identity.Name;
            var accId = await accountService.GetIdAccountByEmailAsync(email);
            var user = await userService.GetUsersByAccountId(accId);

            var res = await likesService.CreateLikeAsync(itemId, user.Id);

            if ( res == 1)
            {
                return StatusCode(201);
            }
            else return StatusCode(304);
        }
    }
}
