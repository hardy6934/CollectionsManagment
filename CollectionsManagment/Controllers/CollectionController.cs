using AutoMapper;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsManagment.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class CollectionController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICollectionService collectionService; 
        private readonly IUserService userService;
        private readonly IAccountService accountService;

        public CollectionController(IMapper mapper, ICollectionService collectionService, IUserService userService, IAccountService accountService) { 
            this.mapper = mapper;
            this.collectionService = collectionService; 
            this.userService = userService;
            this.accountService = accountService;
        }

        public async Task<ActionResult> CollectionViewAsync()
        { 
            var accountId = await accountService.GetIdAccountByEmailAsync(User.Identity.Name);
            var user = await userService.GetUsersByAccountId(accountId);
            var models = await collectionService.GetAllCollectionsForUserAsync(user.Id);
            return View(models.Select(x=>mapper.Map<CollectionModel>(x)).ToList());
        }
 
    }
}
