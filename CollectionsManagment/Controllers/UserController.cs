using AutoMapper;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsManagment.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper mapper; 
        private readonly IUserService userService; 

        public UserController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper; 
            this.userService = userService; 
        }
        public async Task<IActionResult> UserViewAsync(int id)
        {
            var user = mapper.Map<UserModel>(await userService.GetUserByIdAsync(id));
            return View(user);
        }
         
    }
}
