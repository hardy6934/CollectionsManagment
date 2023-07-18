using CollectionsManagment.Buisness.Services;
using CollectionsManagment.Core.Abstractrions;

namespace CollectionsManagment.Middleware
{
    public class CheckUserRoleMiddleware
    {
        private readonly RequestDelegate next; 

        public CheckUserRoleMiddleware(RequestDelegate next )
        {
            this.next = next; 
        }

        public async Task InvokeAsync(HttpContext context)  
        {

            IRoleService roleService = context.RequestServices.GetService<IRoleService>();
            var userName = context.User.Identity?.Name;

            if (userName != null)
            {
                var rolename = await roleService.GetRoleByAccountName(userName);
                if (rolename == "Blocked")
                {
                    await context.Response.WriteAsync("You have been blocked");
                    
                }
                else await next.Invoke(context); 
            }
            else await next.Invoke(context);
 
        }

    }
}
