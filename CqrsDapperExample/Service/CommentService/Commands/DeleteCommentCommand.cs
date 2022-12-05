using MediatR;

namespace CqrsDapperExample.Service.CommentService.Commands
{
    public class DeleteCommentCommand:IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteCommentCommand(int id)
        {
            Id = id;
        }
    }
}
