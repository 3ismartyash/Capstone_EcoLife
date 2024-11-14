using EcoLife.AuthAPi.Models.Dto;
using EcoLife.AuthAPi.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoLife.AuthAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _response;
        public AuthApiController(IAuthService authService)
        {
            _authService = authService;
            _response = new();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var Message = await _authService.Register(model);
            if (!(Message=="User" || Message=="Admin"))
            {
                _response.IsSuccess = false;
                _response.Message = Message;
                return BadRequest(_response);
            }
            _response.Result = Message;
            return Ok(_response);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }

        //[HttpPost("AssignRole")]
        //public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        //{
        //    var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
        //    if (!assignRoleSuccessful)
        //    {
        //        _response.IsSuccess = false;
        //        _response.Message = "Error encountered";
        //        return BadRequest(_response);
        //    }
        //    return Ok(_response);
        //}
    }
}
