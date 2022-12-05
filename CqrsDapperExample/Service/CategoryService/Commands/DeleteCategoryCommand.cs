using MediatR;

namespace CqrsDapperExample.Service.CategoryService.Commands
{
    public class DeleteCategoryCommand:IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
