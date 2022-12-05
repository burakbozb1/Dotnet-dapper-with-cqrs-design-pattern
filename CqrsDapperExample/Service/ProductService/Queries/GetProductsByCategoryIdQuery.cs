using CqrsDapperExample.Entities;
using MediatR;

namespace CqrsDapperExample.Service.ProductService.Queries
{
    public class GetProductsByCategoryIdQuery:IRequest<List<Product>>
    {
        public int CategoryId { get; set; }

        public GetProductsByCategoryIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
