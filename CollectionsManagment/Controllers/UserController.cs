using AutoMapper;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.Models;
using Microsoft.AspNetCore.Mvc;
  
namespace CollectionsManagment.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper mapper; 
        private readonly IUserService userService;
        private readonly IWebHostEnvironment webHostingEnvironment;

        public UserController(IMapper mapper, IUserService userService, IWebHostEnvironment webHostingEnvironment)
        {
            this.mapper = mapper; 
            this.userService = userService;
            this.webHostingEnvironment = webHostingEnvironment;
        }
        public async Task<IActionResult> UserViewAsync(int id)
        { 
            var user = mapper.Map<UserModel>(await userService.GetUserByIdWithIncludsAsync(id)); 
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> EditUserAsync(int id)
        {
            var user = mapper.Map<UserModel>(await userService.GetUserByIdWithIncludsAsync(id));
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserAsync(UserModel model)
        {
              
            if (model.Photo != null) {
                string uploadsFolder = Path.Combine(webHostingEnvironment.WebRootPath, "images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string FilePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Photo.CopyTo(new FileStream(FilePath, FileMode.Create));
                model.FilePath = uniqueFileName;
            }
            
            await userService.UpdateUserAsync(mapper.Map<UserDTO>(model));
            return RedirectToAction( "Index", "Home");
        }

         

    }
}
