using Bll.Dtos;
using System.Security.Claims;

namespace Bll.Services.Helpers;

public interface ITokenService
{
    public string GenerateToken(UserGetDto user);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}