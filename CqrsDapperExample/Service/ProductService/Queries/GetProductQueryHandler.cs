using CqrsDapperExample.Entities;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.ProductService.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            Product product = null;
            string query = $"SELECT * FROM [CqrsDapperExample].[dbo].[Product] WHERE Id = @Id";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                product = con.QueryAsync<Product>(query, new { Id = request.Id }).Result.SingleOrDefault();
                con.Close();
            };
            return product;
        }
    }
}
