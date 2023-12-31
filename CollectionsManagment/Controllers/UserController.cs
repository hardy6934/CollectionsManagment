﻿using AutoMapper;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using CollectionsManagment.Models; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;

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

        public UserController(IMapper mapper, IUserService userService, IWebHostEnvironment webHostingEnvironment, IRoleService roleService, IAccountService accountService )
        {
            this.mapper = mapper; 
            this.userService = userService;
            this.accountService = accountService;
            this.webHostingEnvironment = webHostingEnvironment;
            this.roleService = roleService; 
        }
        public async Task<IActionResult> UserViewAsync(int id)
        {
            try
            {
                var user = mapper.Map<UserModel>(await userService.GetUserByIdWithIncludsAsync(id));
                return View(user);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }
             
        }

        [HttpGet]
        public async Task<IActionResult> EditUserAsync(int id)
        {
            try
            {
                var user = mapper.Map<UserModel>(await userService.GetUserByIdWithIncludsAsync(id));
                return View(user);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditUserAsync(UserModel model)
        {
            try
            {
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(webHostingEnvironment.WebRootPath, "images");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string FilePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(FilePath, FileMode.Create));
                    model.FilePath = uniqueFileName;
                }

                await userService.UpdateUserAsync(mapper.Map<UserDTO>(model));
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

            
        }

        //[HttpPost]
        //public async Task<IActionResult> EditUserAsync(UserModel model)
        //{
        //    if (model.Photo != null && model.Photo.Length > 0)
        //    {
        //        // Создание контейнера Blob
        //        var container = blobClient.GetContainerReference("user-photos");
        //        await container.CreateIfNotExistsAsync();
        //        await container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

        //        // Генерация уникального имени файла
        //        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Photo.FileName);

        //        // Получение ссылки на Blob
        //        var blob = container.GetBlockBlobReference(fileName);

        //        // Загрузка фотографии в Blob Storage
        //        using (var stream = model.Photo.OpenReadStream())
        //        {
        //            await blob.UploadFromStreamAsync(stream);
        //        }

        //        // Возвращение ссылки на загруженную фотографию
        //        var photoUrl = blob.Uri.ToString();
        //        var userDTO = mapper.Map<UserDTO>(model);
        //        userDTO.FilePath= photoUrl;
        //        await userService.UpdateUserAsync(userDTO);
        //        return RedirectToAction("Index", "Home");
        //    }

        //    return BadRequest();
        //} 


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AllUsersViewAsync()
        {
            try
            {
                var users = await userService.GetAllUsers();
                return View(users.Select(x => mapper.Map<UserModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUserAsAdminAsync(int id)
        {
            try
            {
                var user = mapper.Map<UsersModelForUpdatingByAdmin>(await userService.GetUserByIdAsync(id));
                var roles = await roleService.GetAllRolesAsync();
                user.Roles = roles.Select(x => new SelectListItem(x.RoleName, x.Id.ToString())).ToList();

                return View(user);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUserAsAdminAsync(UsersModelForUpdatingByAdmin model)
        {
            try
            {

                var dto = mapper.Map<UserDTO>(model);
                await userService.UpdateUserAsync(dto);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            try
            {
                var userDTO = await userService.GetUserByIdAsync(id);
                return View(mapper.Map<UserModel>(userDTO));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserAsync(UserModel model)
        {
            try
            {
                var userDTO = await userService.GetUserByIdAsync(model.Id);
                var accountDTO = await accountService.GetAccountByIdAsync(userDTO.AccountId);
                await accountService.RemoveAccountAsync(accountDTO);
                return RedirectToAction("AllUsersView");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }

        }

    }
}
