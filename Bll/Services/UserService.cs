using Bll.Dtos;
using Dal.Entity;
using Repositoriy.ItemRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Services;

public class UserService : IUserService
{
    private readonly IUserRepository UserRepository;


    public UserService(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    public async Task DeleteUserByIdAsync(long userId, string userRole)
    {
        if (userRole == "SuperAdmin")
        {
            await UserRepository.DeleteUserByIdAsync(userId);
        }
        else if (userRole == "Admin")
        {
            var user = await UserRepository.SelectUserByIdAsync(userId);
            if (user.Role == UserRole.User)
            {
                await UserRepository.DeleteUserByIdAsync(userId);
            }
            else
            {
                throw new Exception("Admin can not delete Admin or SuperAdmin");
            }
        }
    }

    public Task<object?> GetAllRolesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<object?> GetAllUsersByRoleAsync(string role)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateUserRoleAsync(long userId, UserRoleDto userRoleDto)
    {
        await UserRepository.UpdateUserRoleAsync(userId, (Dal.Entity.UserRole)userRoleDto);
    }
}
