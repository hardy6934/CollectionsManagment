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
        private readonly IItemService itemService;

        public MainPageController(IMapper mapper, ICollectionService collectionService, IItemService itemService)
        {
            this.mapper = mapper;
            this.collectionService = collectionService; 
            this.itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> MainWindeowViewAsync()
        { 
            var topFiveColls = await collectionService.GetTopFiveBigestCollectionsAsync();

            return View(topFiveColls.Select(x=>mapper.Map<CollectionModel>(x)).ToList());
        }

        [HttpGet]
        public async Task<IActionResult> GetLastCreatedItemsAsync()
        { 
            var items = await itemService.GetThreeLastCreatedItemsAsync();

            return View(items.Select(x=>mapper.Map<ItemsModelForMainPage>(x)).ToList());
        }
 
    }
}
