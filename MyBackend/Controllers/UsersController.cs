using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBackend.DAL;
using MyBackend.DTO;

namespace MyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _user;
        public UsersController(IUser user)
        {
            _user = user;
        }

        //register
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Registration(AddUserDTO userDto)
        {
            try
            {
                await _user.Registration(userDto);
                return Ok($"Registrasi User {userDto.Username} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*[AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Authenticate(AddUserDTO userDto)
        {
            try
            {
                var user = await _user.Authenticate(userDto);
                if (user == null)
                    return BadRequest("Username or Password doesn't match");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/
    }
}
