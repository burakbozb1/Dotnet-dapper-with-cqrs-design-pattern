using CqrsDapperExample.Entities;
using MediatR;

namespace CqrsDapperExample.Service.CategoryService.Queries
{
    public class GetCategoryQuery:IRequest<Category>
    {
        public int Id { get; set; }

        public GetCategoryQuery(int id)
        {
            Id = id;
        }
    }
}
