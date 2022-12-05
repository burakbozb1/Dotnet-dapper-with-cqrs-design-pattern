using CqrsDapperExample.Entities;
using CqrsDapperExample.Service.CommentService.Commands;
using CqrsDapperExample.Service.CommentService.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDapperExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator mediatr;

        public CommentController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            return Ok(await mediatr.Send(new GetCommentQuery(id)));
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetCommentsByProductId(int id)
        {
            return Ok(await mediatr.Send(new GetCommentsByProductIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            return Ok(await mediatr.Send(new AddCommentCommand(comment)));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(Comment comment)
        {
            await mediatr.Send(new UpdateCommentCommand(comment));
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await mediatr.Send(new DeleteCommentCommand(id));
            return Ok();
        }

    }
}
