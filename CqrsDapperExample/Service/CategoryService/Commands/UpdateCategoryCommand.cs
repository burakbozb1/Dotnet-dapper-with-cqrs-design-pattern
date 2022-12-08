using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.CategoryService.Commands
{
    public class UpdateCategoryCommand:IRequest<CustomResponseModel>
    {
        public Category category { get; set; }

        public UpdateCategoryCommand(Category category)
        {
            this.category = category;
        }
    }
}
