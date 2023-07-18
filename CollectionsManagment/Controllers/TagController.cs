using AutoMapper;
using CollectionsManagment.Buisness.Services;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.GenericRepository.GenRepository;
using CollectionsManagment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsManagment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TagController : Controller
    {
        private readonly IMapper mapper; 
        private readonly ITagService tagService; 

        public TagController(IMapper mapper, ITagService tagService )
        {
            this.mapper = mapper; 
            this.tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> TagsViewAsync()
        {
            var tags = await tagService.GetAllTagsAsync();
            return View(tags.Select(x=>mapper.Map<TagModel>(x)).ToList());
        }

        [HttpGet]
        public IActionResult CreateTag()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTagAsync(TagModel tag)
        {
            await tagService.CreateTagAsync(mapper.Map<TagDTO>(tag));
            return RedirectToAction("TagsView");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTagAsync(int id)
        {
            var tag = await tagService.GetTagByIdAsync(id);
            return View(mapper.Map<TagModel>(tag));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTagAsync(TagModel tag)
        {
            await tagService.UpdateTagAsync(mapper.Map<TagDTO>(tag));
            return RedirectToAction("TagsView");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveTagAsync(int id)
        {
            var tag = await tagService.GetTagByIdAsync(id);
            return View(mapper.Map<TagModel>(tag));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveTagAsync(TagModel tag)
        {
            await tagService.RemoveTagAsync(mapper.Map<TagDTO>(tag));
            return RedirectToAction("TagsView");
        }

    }
}
