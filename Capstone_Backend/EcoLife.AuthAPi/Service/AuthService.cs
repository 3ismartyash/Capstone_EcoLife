﻿using EcoLife.AuthAPi.Data;
using EcoLife.AuthAPi.Models;
using EcoLife.AuthAPi.Models.Dto;
using EcoLife.AuthAPi.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace MicroServicesExample.Services.AuthApi.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AuthService(UserDbContext db, IJwtTokenGenerator jwtTokenGenerator,UserManager<ApplicationUser> userManager,RoleManager<ApplicationRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _roleManager = roleManager;
        }

        //public async Task<bool> AssignRole(string email, string roleName)
        //{
        //    var user = _db.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        //    if(user != null)
        //    {
        //        if(!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
        //        {
        //            _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
        //        }
        //        await _userManager.AddToRoleAsync(user, roleName);
        //        return true;
        //    }
        //    return false;
        //}

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
                    if (!user.NormalizedEmail.EndsWith("@ADMINECO.COM"))
                    {
                        var roleName = "User";
                        if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                        {
                            _roleManager.CreateAsync(new ApplicationRole { Name = roleName }).GetAwaiter().GetResult();
                        }
                        await _userManager.AddToRoleAsync(user, roleName);
                        return roleName;
                    }
                    else
                    {
                        var roleName = "Admin";
                        if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                        {
                            _roleManager.CreateAsync(new ApplicationRole { Name = roleName }).GetAwaiter().GetResult();
                        }
                        await _userManager.AddToRoleAsync(user, roleName);
                        return roleName;
                    }
                    
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
    }
}