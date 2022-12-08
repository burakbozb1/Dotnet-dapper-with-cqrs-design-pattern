using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.CommentService.Commands
{
    public class UpdateCommentCommand:IRequest<CustomResponseModel>
    {
        public Comment comment { get; set; }

        public UpdateCommentCommand(Comment comment)
        {
            this.comment = comment;
        }
    }
}
