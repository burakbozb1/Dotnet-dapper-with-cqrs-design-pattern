using CqrsDapperExample.Entities;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CategoryService.Queries
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Category>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            Category category = null;
            string query = $"SELECT * FROM [CqrsDapperExample].[dbo].[Category] WHERE Id = @Id";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                category = con.QueryAsync<Category>(query, new { Id = request.Id}).Result.SingleOrDefault();
                con.Close();
            };
            return category;
        }
    }
}
