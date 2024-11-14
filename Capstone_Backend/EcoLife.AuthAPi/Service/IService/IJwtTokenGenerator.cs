using EcoLife.AuthAPi.Models;
using Microsoft.AspNetCore.Identity;

namespace EcoLife.AuthAPi.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser,IList<string> role);
    }
}
