using AutoMapper;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsManagment.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class MainPageController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICollectionService collectionService;
        private readonly IUserService userService;
        private readonly IAccountService accountService;
        private readonly IItemService itemService;

        public MainPageController(IMapper mapper, ICollectionService collectionService, IUserService userService, IAccountService accountService, IItemService itemService)
        {
            this.mapper = mapper;
            this.collectionService = collectionService;
            this.userService = userService;
            this.accountService = accountService;
            this.itemService = itemService;
        }
        public async Task<IActionResult> MainWindeowViewAsync()
        { 
            var topFiveColls = await collectionService.GetTopFiveBigestCollectionsAsync();

            return View(topFiveColls.Select(x=>mapper.Map<CollectionModel>(x)).ToList());
        }

        //public async Task<IActionResult> GetLastCreatedItemsAsync()
        //{
        //    var accName = HttpContext.User.Identity.Name;
        //    var accid = await accountService.GetIdAccountByEmailAsync(accName);
        //    var user = await userService.GetUsersByAccountId(accid);

        //    var items = await collectionService.GetThreeLastCreatedItemsAsync(user.Id);

        //    return View();
        //}
    }
}
