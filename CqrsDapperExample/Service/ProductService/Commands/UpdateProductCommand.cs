using CqrsDapperExample.Entities;
using MediatR;

namespace CqrsDapperExample.Service.ProductService.Commands
{
    public class UpdateProductCommand:IRequest<bool>
    {
        public Product product { get; set; }

        public UpdateProductCommand(Product product)
        {
            this.product = product;
        }
    }
}
