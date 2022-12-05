using MediatR;

namespace CqrsDapperExample.Service.ProductService.Commands
{
    public class DeleteProductCommand:IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
