using AutoMapper;
using AutoMapper.Internal.Mappers;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
            
            try
            {
                var accountId = await accountService.GetIdAccountByEmailAsync(User.Identity.Name);
                var user = await userService.GetUsersByAccountId(accountId);
                var models = await collectionService.GetAllCollectionsForUserAsync(user.Id);
                return View(models.Select(x => mapper.Map<CollectionModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }
            
        }

        [HttpGet]
        public IActionResult AddCollection()
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
        public async Task<IActionResult> AddCollectionAsync(CollectionModel model)
        {
            try
            {
                var accountId = await accountService.GetIdAccountByEmailAsync(User.Identity.Name);
                var user = await userService.GetUsersByAccountId(accountId);
                model.UserId = user.Id;
                await collectionService.CreateCollectionAsync(mapper.Map<CollectionDTO>(model));
                return RedirectToAction("CollectionView");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCollectionAsync(int Id)
        {
            try
            {
                var collection = await collectionService.GetCollectionByIdAsync(Id);
                return View(mapper.Map<CollectionModel>(collection));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCollectionAsync(CollectionModel model)
        {
            try
            {
                await collectionService.DeleteCollectionAsync(mapper.Map<CollectionDTO>(model));
                return RedirectToAction("CollectionView");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

            
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCollections()
        {
            try
            {
                var collections = await collectionService.GetAllCollectionsAsync();
                return View(collections.Select(x => mapper.Map<CollectionModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }
            
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> SearchInCollectionsAsync(string name)
        {
            try
            {
                var collections = await collectionService.FindCollectionsByNameOrDescAsync(name);
                return View(collections.Select(x => mapper.Map<CollectionModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }
            
        }


    }
}
