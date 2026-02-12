using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CommunityApiV2.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using CommunityApiV2.Models;
namespace CommunityApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [SwaggerOperation(
            Summary ="Hämta alla användare",
            Description ="Returnerar en lista med alla registrerade användare.")]
        [SwaggerResponse(200,"Lista med användare returnerades")]
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }


        [SwaggerOperation(
            Summary = "Registrera ny användare",
            Description = "Skapar nytt användarkonto.")]
        [SwaggerResponse(200,"Användare skapad och returnerar dess id.")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var newUserId = await _userService.RegisterAsync(user);

            if (newUserId == 0)
                return BadRequest();

            return Ok(newUserId);
        }

    }
}
