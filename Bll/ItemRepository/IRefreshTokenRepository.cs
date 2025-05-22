using Dal.Entity;

namespace Repositoriy.ItemRepository;

public interface IRefreshTokenRepository
{
    Task AddRefreshTokenAsync(RefreshToken refreshToken);
    Task<RefreshToken> SelectRefreshTokenAsync(string refreshToken, long userId);
    Task RemoveRefreshTokenAsync(string token);
}