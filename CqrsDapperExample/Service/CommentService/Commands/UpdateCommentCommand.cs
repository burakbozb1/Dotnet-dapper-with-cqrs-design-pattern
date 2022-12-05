using CqrsDapperExample.Entities;
using MediatR;

namespace CqrsDapperExample.Service.CommentService.Commands
{
    public class UpdateCommentCommand:IRequest<bool>
    {
        public Comment comment { get; set; }

        public UpdateCommentCommand(Comment comment)
        {
            this.comment = comment;
        }
    }
}
