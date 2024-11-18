using EcoLife.AuthAPi.Models;
using EcoLife.AuthAPi.Models.Dto;

namespace EcoLife.AuthAPi.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<UserDto> UpdateProfile(int userId,UpdateRequestDto updateRequestDto);
        Task<List<UserDto>> GetUsers();
        Task<List<ApplicationRole>> GetRoles();
        
    }
}
