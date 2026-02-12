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


        [HttpGet]
        [SwaggerOperation(
            Summary ="Hämta alla användare",
            Description ="Returnerar en lista med alla registrerade användare.")]
        [SwaggerResponse(200,"Lista med användare returnerades")]
        public async Task <IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }


        [HttpPost("/register")]
        [SwaggerOperation(Summary = "Registrera ny användare", Description = "Skapar nytt användarkonto.")]
        [SwaggerResponse(200,"Användare skapad och returnerar dess id")]
        [SwaggerResponse(400,"Användarnamnet är upptaget")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            var newUserId = await _userService.CreateAsync(user);

            if (newUserId == 0)
                return BadRequest("Username already taken ");

            return Ok(newUserId);
        }


        [HttpPost("/login")]
        [SwaggerOperation(Summary = "Logga in användare", Description ="Verifierar username och password och returnerar användarens id")]
        [SwaggerResponse(200,"Inlogging lyckades och användarens id returneras")]
        [SwaggerResponse(401,"Fel användarnamn eller lösenord")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var userId = await _userService.LoginAsync(user.Username, user.Password);

            if (userId == null)
                return Unauthorized("Invalid input details");

            return Ok(userId);
        }


        [HttpGet("/{id}")]
        [SwaggerOperation(Summary = "Hämta användare via id", Description = "Returnerar den användare med valt id.")]
        [SwaggerResponse(200,"Användare hittad")]
        [SwaggerResponse(404,"Användare kunde inte hittas")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        [HttpPut("/{id}")]
        [SwaggerOperation(Summary = "Uppdatera en användare", Description ="Uppdatera username/password/email för en användare.")]
        [SwaggerResponse(200,"Användare uppdaterad")]
        [SwaggerResponse(404,"Användare kunde inte hittas")]
        public async Task<IActionResult> Update(int id, [FromBody] User updatedUser)
        {
            var result = await _userService.UpdateAsync(id, updatedUser);

            if (!result)
                return NotFound("User not found");

            return Ok("User was updated");
        }

        [HttpDelete("/{id}")]
        [SwaggerOperation(Summary = "Ta bort användare", Description ="Tar bort användare via id.")]
        [SwaggerResponse(200,"Användare togs bort")]
        [SwaggerResponse(404,"Användare kunde inte hittas")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result)
                return NotFound("User not found");

            return Ok("User was deleted");
        }



        
    }
}
