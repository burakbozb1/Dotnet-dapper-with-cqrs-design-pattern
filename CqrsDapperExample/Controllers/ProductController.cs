using CqrsDapperExample.Entities;
using CqrsDapperExample.Service.ProductService.Commands;
using CqrsDapperExample.Service.ProductService.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDapperExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediatr;

        public ProductController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Ok(await mediatr.Send(new GetProductQuery(id)));
        }

        [HttpGet("withdetails/{id}")]
        public async Task<IActionResult> GetProductWithDetails(int id)
        {
            return Ok(await mediatr.Send(new GetProductWithCategoryAndCommentsQuery(id)));
        }

        [HttpGet("bycategory/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryId(int categoryId)
        {
            return Ok(await mediatr.Send(new GetProductsByCategoryIdQuery(categoryId)));
        }

        [HttpGet("withdetailsbycategory/{categoryId}")]
        public async Task<IActionResult> GetProductsWithDetailByCategoryId(int categoryId)
        {
            return Ok(await mediatr.Send(new GetProductsWithDetailsByCategoryIdQuery(categoryId)));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            return Ok(await mediatr.Send(new AddProcutCommand(product)));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            await mediatr.Send(new UpdateProductCommand(product));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await mediatr.Send(new DeleteProductCommand(id));
            return Ok();
        }


    }
}
