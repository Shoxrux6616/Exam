using Core.Errors;
using Dal;
using Dal.Entity;

namespace Bll.ItemRepository;

public class RoleRepository(MainContext _context) : IRoleRepository
{
    public async Task<List<UserRole>> GetAllRolesAsync() => await _context.UserRole.ToListAsync();

    public async Task<ICollection<User>> GetAllUsersByRoleAsync(string role)
    {
        var foundRole = await _context.UserRole.Include(u => u.Users).FirstOrDefaultAsync(_ => _.Name == role);
        if (foundRole is null)
        {
            throw new EntityNotFoundException(role);
        }
        return foundRole.Users;
    }

    public async Task<long> GetRoleIdAsync(string role)
    {
        var foundRole = await _context.UserRole.FirstOrDefaultAsync(_ => _.Name == role);
        if (foundRole is null)
        {
            throw new EntityNotFoundException(role + " - not found");
        }
        return foundRole.Id;
    }
}
