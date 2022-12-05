using CqrsDapperExample.Entities;
using MediatR;

namespace CqrsDapperExample.Service.ProductService.Commands
{
    public class AddProcutCommand:IRequest<Product>
    {
        public Product product { get; set; }

        public AddProcutCommand(Product product)
        {
            this.product = product;
        }
    }
}
