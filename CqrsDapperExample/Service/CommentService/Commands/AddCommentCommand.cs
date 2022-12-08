using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.CommentService.Commands
{
    public class AddCommentCommand:IRequest<CustomResponseModel>
    {
        public Comment comment { get; set; }

        public AddCommentCommand(Comment comment)
        {
            this.comment = comment;
        }
    }
}
