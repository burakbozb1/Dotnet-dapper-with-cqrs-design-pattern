using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.CategoryService.Queries
{
    public class GetAllCategoriesQuery:IRequest<CustomResponseModel>
    {

    }
}
