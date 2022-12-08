using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.ProductService.Queries
{
    public class GetProductQuery:IRequest<CustomResponseModel>
    {
        public int Id { get; set; }

        public GetProductQuery(int id)
        {
            Id = id;
        }
    }
}
