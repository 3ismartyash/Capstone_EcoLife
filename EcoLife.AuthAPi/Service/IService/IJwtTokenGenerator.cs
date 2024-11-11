using EcoLife.AuthAPi.Models;

namespace EcoLife.AuthAPi.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
