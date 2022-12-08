using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.CategoryService.Queries
{
    public class GetCategoryQuery:IRequest<CustomResponseModel>
    {
        public int Id { get; set; }

        public GetCategoryQuery(int id)
        {
            Id = id;
        }
    }
}
