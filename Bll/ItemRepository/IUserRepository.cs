using Dal.Entity;

namespace Repositoriy.ItemRepository;

public interface IUserRepository
{
    Task<long> InsertUserAsync(User user);
    Task<User> SelectUserByIdAsync(long id);
    Task<User> SelectUserByUserNameAsync(string userName);
    Task UpdateUserRoleAsync(long userId, UserRole userRole);
    Task DeleteUserByIdAsync(long userId);
}