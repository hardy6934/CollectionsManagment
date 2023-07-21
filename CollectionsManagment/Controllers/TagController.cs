using AutoMapper;
using CollectionsManagment.Buisness.Services;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.GenericRepository.GenRepository;
using CollectionsManagment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
            try
            {
                var tags = await tagService.GetAllTagsAsync();
                return View(tags.Select(x => mapper.Map<TagModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }

        [HttpGet]
        public IActionResult CreateTag()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateTagAsync(TagModel tag)
        {
            try
            {
                await tagService.CreateTagAsync(mapper.Map<TagDTO>(tag));
                return RedirectToAction("TagsView");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }

        [HttpGet]
        public async Task<IActionResult> UpdateTagAsync(int id)
        {
            try
            {
                var tag = await tagService.GetTagByIdAsync(id);
                return View(mapper.Map<TagModel>(tag));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<IActionResult> UpdateTagAsync(TagModel tag)
        {
            try
            {
                await tagService.UpdateTagAsync(mapper.Map<TagDTO>(tag));
                return RedirectToAction("TagsView");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }

        [HttpGet]
        public async Task<IActionResult> RemoveTagAsync(int id)
        {
            try
            {
                var tag = await tagService.GetTagByIdAsync(id);
                return View(mapper.Map<TagModel>(tag));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<IActionResult> RemoveTagAsync(TagModel tag)
        {
            try
            {
                await tagService.RemoveTagAsync(mapper.Map<TagDTO>(tag));
                return RedirectToAction("TagsView");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }

    }
}
