using CqrsDapperExample.Entities;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CategoryService.Queries
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            List<Category> categories = new List<Category>();
            string query = $"SELECT * FROM [CqrsDapperExample].[dbo].[Category]";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                categories = con.QueryAsync<Category>(query).Result.ToList();
                con.Close();
            };
            return categories;
        }
    }
}
