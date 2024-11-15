using EcoLife.AuthAPi.Models.Dto;

namespace EcoLife.AuthAPi.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        
    }
}
