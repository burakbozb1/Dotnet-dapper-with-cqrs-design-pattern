using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.ProductService.Commands
{
    public class AddProcutCommand:IRequest<CustomResponseModel>
    {
        public Product product { get; set; }

        public AddProcutCommand(Product product)
        {
            this.product = product;
        }
    }
}
