﻿namespace EcoLife.AuthAPi.Models.Dto
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
        public string role { get; set; }
    }
}