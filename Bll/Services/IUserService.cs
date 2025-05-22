using Bll.Dtos;

namespace Bll.Services;

public interface IUserService
{
    Task DeleteUserByIdAsync(long userId, string UserRole);
    Task<object?> GetAllRolesAsync();
    Task<object?> GetAllUsersByRoleAsync(string role);
    Task UpdateUserRoleAsync(long userId, UserRoleDto userRoleDto);
}