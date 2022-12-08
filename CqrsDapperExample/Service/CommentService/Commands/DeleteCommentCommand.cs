using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.CommentService.Commands
{
    public class DeleteCommentCommand:IRequest<CustomResponseModel>
    {
        public int Id { get; set; }

        public DeleteCommentCommand(int id)
        {
            Id = id;
        }
    }
}
