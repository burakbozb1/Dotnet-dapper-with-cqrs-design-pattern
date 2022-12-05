using CqrsDapperExample.Entities;
using MediatR;

namespace CqrsDapperExample.Service.CategoryService.Commands
{
    public class AddCategoryCommand:IRequest<Category>
    {
        public Category category { get; set; }

        public AddCategoryCommand(Category category)
        {
            this.category = category;
        }
    }
}
