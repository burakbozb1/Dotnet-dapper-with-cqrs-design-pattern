using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.CommentService.Queries
{
    public class GetCommentQuery:IRequest<CustomResponseModel>
    {
        public int Id { get; set; }

        public GetCommentQuery(int id)
        {
            Id = id;
        }
    }
}
