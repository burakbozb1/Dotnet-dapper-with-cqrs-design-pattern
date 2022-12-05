using CqrsDapperExample.Entities;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.ProductService.Queries
{
    public class GetProductsByCategoryIdQueryHandler : IRequestHandler<GetProductsByCategoryIdQuery, List<Product>>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<List<Product>> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = new List<Product>();
            string query = $"SELECT * FROM [CqrsDapperExample].[dbo].[Product] Where CategoryId = @CategoryId";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                products = con.QueryAsync<Product>(query, new { CategoryId = request.CategoryId}).Result.ToList();
                con.Close();
            };
            return products;
        }
    }
}
