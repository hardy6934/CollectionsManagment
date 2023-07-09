using AutoMapper;
using AutoMapper.Internal.Mappers;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
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

        public async Task<IActionResult> CollectionViewAsync()
        { 
            var accountId = await accountService.GetIdAccountByEmailAsync(User.Identity.Name);
            var user = await userService.GetUsersByAccountId(accountId);
            var models = await collectionService.GetAllCollectionsForUserAsync(user.Id);
            return View(models.Select(x=>mapper.Map<CollectionModel>(x)).ToList());
        }

        [HttpGet]
        public async Task<IActionResult> AddCollectionAsync()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddCollectionAsync(CollectionModel model)
        {
            var accountId = await accountService.GetIdAccountByEmailAsync(User.Identity.Name);
            var user = await userService.GetUsersByAccountId(accountId);
            model.UserId = user.Id;
            await collectionService.CreateCollectionAsync(mapper.Map<CollectionDTO>(model));
            return RedirectToAction("CollectionView");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCollectionAsync(int Id)
        {
            var collection = await collectionService.GetCollectionByIdAsync(Id);
            return View(mapper.Map<CollectionModel>(collection));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCollectionAsync(CollectionModel model)
        {
             
            await collectionService.DeleteCollectionAsync(mapper.Map<CollectionDTO>(model));
            return RedirectToAction("CollectionView");
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCollections()
        {
            var collections = await collectionService.GetAllCollectionsAsync();
            return View(collections.Select(x=>mapper.Map<CollectionModel>(x)).ToList());
        }


    }
}
