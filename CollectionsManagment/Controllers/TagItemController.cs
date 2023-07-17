using AutoMapper;
using CollectionsManagment.Buisness.Services;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using CollectionsManagment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Data;

namespace CollectionsManagment.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class TagItemController : Controller
    {
        private readonly IMapper mapper; 
        private readonly ITagItemService tagItemService; 
        private readonly ITagService tagService; 

        public TagItemController(IMapper mapper, ITagItemService tagItemService, ITagService tagService)
        {
            this.mapper = mapper;
            this.tagItemService = tagItemService;
            this.tagService= tagService;
        }
        public async Task<IActionResult> TagItemViewAsync(int id)
        {
            ViewBag.ItemId = id;
            var tags = await tagItemService.GetAllTagsByItemId(id);
            return View(tags.Select(x=>mapper.Map<TagItemModel>(x)).ToList());
        }


        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult> AutocompleteSearchTagsAsync(string term)
        {
            try
            {
                var tags = await tagService.GetAllTagsAsync();

                var models = tags.Where(t => t.TagName.Contains(term))
                                .Select(t => new { value = t.TagName })
                                .Distinct();

                return Ok(models);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }


        [HttpGet]
        public IActionResult CreateTagItemAsync(int id)
        {
            ViewBag.ItemId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTagItemAsync( int id, string TagName)
        {
            var tagId =  await tagService.GetTagIdByTagNameAsync(TagName);

            var model = new TagItemModel { ItemId = id, TagId = tagId };
            await tagItemService.CreateTagItemAsync(mapper.Map<TagItemDTO>(model));
            return RedirectToAction("TagItemView",new { id = id});
        }
        
        [HttpGet]
        public async Task<IActionResult> RemoveTagItemAsync(int id)
        {
            var tagItem = await tagItemService.GetTagItemByIdAsync(id);
            return View(mapper.Map<TagItemModel>(tagItem));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveTagItemAsync(TagItemModel model)
        {
            var tagItem = await tagItemService.GetTagItemByIdAsync(model.Id);
            await tagItemService.RemoveTagItem(tagItem);
            return RedirectToAction("TagItemView", new { id = tagItem.ItemId});
        }


    }
}
