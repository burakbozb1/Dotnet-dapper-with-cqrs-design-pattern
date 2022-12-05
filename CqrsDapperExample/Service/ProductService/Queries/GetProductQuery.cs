using CqrsDapperExample.Entities;
using MediatR;

namespace CqrsDapperExample.Service.ProductService.Queries
{
    public class GetProductQuery:IRequest<Product>
    {
        public int Id { get; set; }

        public GetProductQuery(int id)
        {
            Id = id;
        }
    }
}
