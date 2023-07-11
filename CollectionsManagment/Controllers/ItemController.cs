using AutoMapper;
using CollectionsManagment.Abstractions.GenRepositoryAbstractions;
using CollectionsManagment.Buisness.Services;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsManagment.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class ItemController : Controller
    {
        private readonly IMapper mapper;
        private readonly IItemService itemService; 
        private readonly ICollectionService collectionService; 
         
        public ItemController(IItemService itemService, IMapper mapper, ICollectionService collectionService )
        {
            this.itemService = itemService;
            this.mapper = mapper;
            this.collectionService = collectionService;

        }
         
        public async Task<IActionResult> ItemsViewAsync(int Id)
        {
            var items = await itemService.GetItemsByCollectionIdAsync(Id);
            return View(items.Select(x=> mapper.Map<ItemModel>(x)).ToList());
        }

        [HttpGet]
        public async Task<IActionResult> AddItemAsync(int id)
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
        
        [HttpPost]
        public async Task<IActionResult> AddItemAsync(ItemModel model)
        {
            await itemService.CreateItemAsync(mapper.Map<ItemDTO>(model));
            return RedirectToAction("CollectionView","Collection");
        }


        [HttpGet]
        public async Task<IActionResult> RemoveItemAsync(int id)
        {
            var itemModel = await itemService.GetItemById(id);
            return View(mapper.Map<ItemModel>(itemModel));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItemAsync(ItemModel model)
        {
            await itemService.DeleteItemAsync(mapper.Map<ItemDTO>(model));
            return RedirectToAction("CollectionView", "Collection");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ItemsViewForAnonymousAsync(int id)
        {
            var items = await itemService.GetItemsByCollectionIdAsync(id);
            return View(items.Select(x => mapper.Map<ItemModel>(x)).ToList());
        }


        [HttpGet]
        public async Task<IActionResult> GetItemById(int id)
        {
            //var itemModel = await itemService.GetItemById(id);
            var itemModel = await itemService.GetItemByIdWithCommentsAndUsers(id);
            return View("ConcretItemView", mapper.Map<ItemModel>(itemModel));
        }

         


    }
}
