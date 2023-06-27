using AutoMapper;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using CollectionsManagment.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollectionsManagment.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class UserController : Controller
    {
        private readonly IMapper mapper; 
        private readonly IUserService userService;
        private readonly IAccountService accountService;
        private readonly IRoleService roleService;
        private readonly IWebHostEnvironment webHostingEnvironment;

        public UserController(IMapper mapper, IUserService userService, IWebHostEnvironment webHostingEnvironment, IRoleService roleService, IAccountService accountService)
        {
            this.mapper = mapper; 
            this.userService = userService;
            this.accountService = accountService;
            this.webHostingEnvironment = webHostingEnvironment;
            this.roleService = roleService;
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


        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AllUsersViewAsync()
        {
            var users = await userService.GetAllUsers();
            return View(users.Select(x=>mapper.Map<UserModel>(x)).ToList());
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUserAsAdminAsync(int id)
        {
            var user = mapper.Map<UsersModelForUpdatingByAdmin>(await userService.GetUserByIdAsync(id));
            var roles = await roleService.GetAllRolesAsync(); 
            user.Roles = roles.Select(x => new SelectListItem(x.RoleName, x.Id.ToString())).ToList();

            return View(user);
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUserAsAdminAsync(UsersModelForUpdatingByAdmin model)
        {
             
            var dto = mapper.Map<UserDTO>(model);
            await userService.UpdateUserAsync(dto);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserAsync(int id)
            {
            var userDTO = await userService.GetUserByIdAsync(id);   
            return View(mapper.Map<UserModel>(userDTO));
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserAsync(UserModel model)
        {
            var userDTO = await userService.GetUserByIdAsync(model.Id);
            var accountDTO = await accountService.GetAccountByIdAsync(userDTO.AccountId);
            await accountService.RemoveAccountAsync(accountDTO);
            return RedirectToAction("AllUsersView");
        }

    }
}
