using CqrsDapperExample.Entities;
using CqrsDapperExample.Service.CategoryService.Commands;
using CqrsDapperExample.Service.CategoryService.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDapperExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediatr;

        public CategoryController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await mediatr.Send(new GetAllCategoriesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            return Ok(await mediatr.Send(new GetCategoryQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            return Ok(await mediatr.Send(new AddCategoryCommand(category)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await mediatr.Send(new DeleteCategoryCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            await mediatr.Send(new UpdateCategoryCommand(category));
            return Ok();
        }


    }
}
