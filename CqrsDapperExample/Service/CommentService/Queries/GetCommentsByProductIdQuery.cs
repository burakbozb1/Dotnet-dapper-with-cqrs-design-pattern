using CqrsDapperExample.Entities;
using MediatR;

namespace CqrsDapperExample.Service.CommentService.Queries
{
    public class GetCommentsByProductIdQuery:IRequest<List<Comment>>
    {
        public int ProductId { get; set; }

        public GetCommentsByProductIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
