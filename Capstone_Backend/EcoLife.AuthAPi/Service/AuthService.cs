using EcoLife.AuthAPi.Data;
using EcoLife.AuthAPi.Models;
using EcoLife.AuthAPi.Models.Dto;
using EcoLife.AuthAPi.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MicroServicesExample.Services.AuthApi.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AuthService(UserDbContext db, IJwtTokenGenerator jwtTokenGenerator, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _roleManager = roleManager;
        }

        public Task<List<UserDto>> GetUsers()
        {

            return _db.Users
       .Select(user => new UserDto
       {
           Id = user.Id,
           Name = user.Name,
           Email = user.Email,
           PhoneNumber = user.PhoneNumber
       })
       .ToListAsync();
        }
        public Task<List<ApplicationRole>> GetRoles()
        {
            return _db.Roles.ToListAsync();
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            if (user == null || isValid == false)
            {
                return new LoginResponseDto()
                {
                    User = null,
                    Token = ""
                };
            }
            var role = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, role);
            UserDto userDto = new()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
            };
            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = token,
                role = role[0]
            };
            return loginResponseDto;
        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                Name = registrationRequestDto.Name,
                PhoneNumber = registrationRequestDto.PhoneNumber
            };
            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                if (result.Succeeded)
                {
                    if (user.NormalizedEmail.EndsWith("@ADMINECO.COM"))
                    {
                        var roleName = "Admin";
                        if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                        {
                            _roleManager.CreateAsync(new ApplicationRole { Name = roleName }).GetAwaiter().GetResult();
                        }
                        await _userManager.AddToRoleAsync(user, roleName);

                    }
                    //else if (user.NormalizedEmail.EndsWith("@GUEST.COM"))
                    //{
                    //    var roleName = "Guest";
                    //    if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                    //    {
                    //        _roleManager.CreateAsync(new ApplicationRole { Name = roleName }).GetAwaiter().GetResult();
                    //    }
                    //    await _userManager.AddToRoleAsync(user, roleName);
                    //}
                    else
                    {
                        var roleName = "User";
                        if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                        {
                            _roleManager.CreateAsync(new ApplicationRole { Name = roleName }).GetAwaiter().GetResult();
                        }
                        await _userManager.AddToRoleAsync(user, roleName);
                        
                    }
                    return "";

                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {
            }
            return "Error Encountered";
        }

        public async Task<UserDto> UpdateProfile(int userid, UpdateRequestDto updateRequestDto)
        {

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userid);
            if (user != null)
            {
                user.UserName = updateRequestDto.Email;
                user.Email = updateRequestDto.Email;
                user.NormalizedEmail = updateRequestDto.Email.ToUpper();
                user.Name = updateRequestDto.Name;
                user.PhoneNumber = updateRequestDto.PhoneNumber;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    UserDto userResponse = new UserDto()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Name = user.Name,
                        PhoneNumber = user.PhoneNumber
                    };
                    return userResponse;
                }
            }
            return null;
        }
    }
}
