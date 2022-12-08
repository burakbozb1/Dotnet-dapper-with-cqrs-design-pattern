using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.ProductService.Commands
{
    public class UpdateProductCommand:IRequest<CustomResponseModel>
    {
        public Product product { get; set; }

        public UpdateProductCommand(Product product)
        {
            this.product = product;
        }
    }
}
