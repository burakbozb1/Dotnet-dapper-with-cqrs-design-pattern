using CqrsDapperExample.Entities;
using MediatR;

namespace CqrsDapperExample.Service.CommentService.Queries
{
    public class GetCommentQuery:IRequest<Comment>
    {
        public int Id { get; set; }

        public GetCommentQuery(int id)
        {
            Id = id;
        }
    }
}
