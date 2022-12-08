using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.CategoryService.Commands
{
    public class DeleteCategoryCommand:IRequest<CustomResponseModel>
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
