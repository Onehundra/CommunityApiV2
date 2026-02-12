using CommunityApiV2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CommunityApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Hämta kategorier", Description ="Returnerar en lista med alla kategorier")]
        [SwaggerResponse(200,"Lista med kategorier returnerades")]
        public async Task<IActionResult> GetAll()
        {
            var categories = _categoryService.GetAllAsync();
            return Ok(categories);
        }


    }
}
