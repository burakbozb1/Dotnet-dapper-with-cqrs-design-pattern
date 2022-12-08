using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.ProductService.Commands
{
    public class DeleteProductCommand:IRequest<CustomResponseModel>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
