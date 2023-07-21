using AutoMapper;
using CollectionsManagment.Abstractions.GenRepositoryAbstractions;
using CollectionsManagment.Buisness.Services;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CollectionsManagment.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class ItemController : Controller
    {
        private readonly IMapper mapper;
        private readonly IItemService itemService; 
        private readonly ICollectionService collectionService; 
        private readonly IAccountService accountService; 
        private readonly IUserService userService; 
         
        public ItemController(IItemService itemService, IMapper mapper, ICollectionService collectionService, IAccountService accountService, IUserService userService)
        {
            this.itemService = itemService;
            this.mapper = mapper;
            this.collectionService = collectionService;
            this.accountService = accountService;
            this.userService = userService;

        }
         
        public async Task<IActionResult> ItemsViewAsync(int Id)
        {
            try
            {
                var items = await itemService.GetItemsByCollectionIdAsync(Id);
                return View(items.Select(x => mapper.Map<ItemModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }
             
        }

        [HttpGet]
        public async Task<IActionResult> AddItemAsync(int id)
        {
            try
            {
                if (!await itemService.IsCollectionEmpty(id))
                {
                    ViewBag.CollectionId = id;
                    return View();
                }
                else
                {
                    ViewBag.CollectionId = id;
                    var firstItem = await itemService.GetFirstItemFromCollectionByCollectionId(id);
                    return View("AddItemToNotEmptyColl", mapper.Map<ItemModel>(firstItem));
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

            
        }
        
        [HttpPost]
        public async Task<IActionResult> AddItemAsync(ItemModel model)
        {
            try
            {
                await itemService.CreateItemAsync(mapper.Map<ItemDTO>(model));
                return RedirectToAction("CollectionView", "Collection");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }


        [HttpGet]
        public async Task<IActionResult> RemoveItemAsync(int id)
        {
            try
            {
                var itemModel = await itemService.GetItemById(id);
                return View(mapper.Map<ItemModel>(itemModel));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<IActionResult> RemoveItemAsync(ItemModel model)
        {
            try
            {
                await itemService.DeleteItemAsync(mapper.Map<ItemDTO>(model));
                return RedirectToAction("CollectionView", "Collection");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ItemsViewForAnonymousAsync(int id)
        {
            try
            {
                var items = await itemService.GetItemsByCollectionIdAsync(id);
                return View(items.Select(x => mapper.Map<ItemModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetItemById(int id)
        {
            try
            {
                //var itemModel = await itemService.GetItemById(id);
                var itemModel = await itemService.GetItemByIdWithCommentsAndUsers(id);
                return View("ConcretItemView", mapper.Map<ItemModel>(itemModel));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetUserNameByItemId(int id)
        {
            try
            {
                var UserName = await itemService.GetAccountIdByItemIdAsync(id);
                ViewBag.UserName = UserName;
                return View();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentUserNameAsync()
        {
            try
            {
                var accName = User.Identity.Name;
                var accId = await accountService.GetIdAccountByEmailAsync(accName);
                var CurrentUser = await userService.GetUsersByAccountId(accId);
                ViewBag.UserName = CurrentUser.FullName;
                return View();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }


    }
}
