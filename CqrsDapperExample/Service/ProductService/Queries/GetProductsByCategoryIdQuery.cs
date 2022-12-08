using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.ProductService.Queries
{
    public class GetProductsByCategoryIdQuery:IRequest<CustomResponseModel>
    {
        public int CategoryId { get; set; }

        public GetProductsByCategoryIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
