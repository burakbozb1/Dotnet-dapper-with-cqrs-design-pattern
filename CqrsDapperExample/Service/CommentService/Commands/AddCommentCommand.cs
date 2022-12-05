using CqrsDapperExample.Entities;
using MediatR;

namespace CqrsDapperExample.Service.CommentService.Commands
{
    public class AddCommentCommand:IRequest<Comment>
    {
        public Comment comment { get; set; }

        public AddCommentCommand(Comment comment)
        {
            this.comment = comment;
        }
    }
}
