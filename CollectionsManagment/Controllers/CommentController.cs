using AutoMapper;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CollectionsManagment.Controllers
{

    [Authorize(Roles = "Admin,User")]
    public class CommentController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAccountService accountService;
        private readonly ICommentsService commentsService;
        private readonly IUserService userService;

        public CommentController(IMapper mapper, IAccountService accountService, ICommentsService commentsService, IUserService userService) { 
            this.mapper = mapper;
            this.accountService = accountService;
            this.commentsService = commentsService;
            this.userService = userService;
        }


        public async Task<IActionResult> CreateCommentAsync(CommentModel model)
        { 

            try
            {
                var email = HttpContext.User.Identity.Name;
                var accId = await accountService.GetIdAccountByEmailAsync(email);
                var user = await userService.GetUsersByAccountId(accId);

                model.UserId = user.Id;
                model.dateTime = DateTime.Now;
                await commentsService.CreateCommentAsync(mapper.Map<CommentDTO>(model));

                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return BadRequest();
            }
        }
    }
}
