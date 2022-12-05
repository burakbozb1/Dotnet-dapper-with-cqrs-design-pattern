using CqrsDapperExample.Entities;
using MediatR;

namespace CqrsDapperExample.Service.CategoryService.Queries
{
    public class GetAllCategoriesQuery:IRequest<List<Category>>
    {

    }
}
