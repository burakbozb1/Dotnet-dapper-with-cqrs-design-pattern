using CqrsDapperExample.Entities;
using MediatR;

namespace CqrsDapperExample.Service.CategoryService.Commands
{
    public class UpdateCategoryCommand:IRequest<bool>
    {
        public Category category { get; set; }

        public UpdateCategoryCommand(Category category)
        {
            this.category = category;
        }
    }
}
