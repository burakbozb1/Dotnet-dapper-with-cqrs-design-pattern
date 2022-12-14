using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.CategoryService.Commands
{
    public class AddCategoryCommand:IRequest<CustomResponseModel>
    {
        public Category category { get; set; }

        public AddCategoryCommand(Category category)
        {
            this.category = category;
        }
    }
}
