using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.CommentService.Queries
{
    public class GetCommentsByProductIdQuery:IRequest<CustomResponseModel>
    {
        public int ProductId { get; set; }

        public GetCommentsByProductIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
