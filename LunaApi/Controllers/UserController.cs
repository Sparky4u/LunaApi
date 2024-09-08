using LunaApi.Common.Models;
using LunaApi.DAL.Data.DTO;
using LunaApi.DAL.Data.Interfaces;
using LunaApi.DAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace LunaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _userRepository;
        private readonly IAuthService _authService;

        public UserController(IUsersRepository userRepository,IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDto userDto)
        {
            try
            {
                var user = await _userRepository.Register(userDto.UserName, userDto.Email, userDto.Password);
                return Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto request)
        {
            try
            {
                var user = await _userRepository.Login(request.UserNameOrEmail, request.Password);

                if (user == null)
                {
                    return Unauthorized("Invalid username or password.");
                }

                var token = _authService.GenerateJwtToken(user);

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
