using Bll.Dtos;
using Bll.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Exam6.Endpoiind
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this WebApplication app)
        {
            var userGroup = app.MapGroup("/api/user")
                .RequireAuthorization()      
                .WithTags("User Management"); 

            userGroup.MapDelete("/delete", [Authorize(Roles = "Admin,SuperAdmin")]
            async (long userId, HttpContext httpContext, IUserService userService) =>
            {
                var role = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
                await userService.DeleteUserByIdAsync(userId, role);
                return Results.Ok();
            })
                .WithName("DeleteUser")
                .Produces(200)
                .Produces(404);


            userGroup.MapPatch("/updateRole", [Authorize(Roles = "SuperAdmin")]
            async (long userId, UserRoleDto userRoleDto, IUserService userService) =>
            {
                await userService.UpdateUserRoleAsync(userId, userRoleDto);
                return Results.Ok();
            })
                .WithName("UpdateUserRole");


        }
    }

}
