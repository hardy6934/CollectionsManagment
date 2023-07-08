using AutoMapper;
using CollectionsManagment.Abstractions.GenRepositoryAbstractions;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsManagment.Controllers
{
    public class ItemController : Controller
    {
        private readonly IMapper mapper;
        private readonly IItemService itemService; 
         
        public ItemController(IItemService itemService, IMapper mapper )
        {
            this.itemService = itemService;
            this.mapper = mapper; 

        }
         
        public async Task<IActionResult> ItemsViewAsync(int Id)
        {
            var items = await itemService.GetItemsByCollectionIdAsync(Id);
            return View(items.Select(x=> mapper.Map<ItemModel>(x)).ToList());
        }

        [HttpGet]
        public IActionResult AddItem(int id)
        {
            ViewBag.CollectionId = id;
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddItemAsync(ItemModel model)
        {
            await itemService.CreateItemAsync(mapper.Map<ItemDTO>(model));
            return RedirectToAction("CollectionView","Collection");
        }

    }
}
