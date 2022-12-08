using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.ProductService.Queries
{
    public class GetProductsByCategoryIdQueryHandler : IRequestHandler<GetProductsByCategoryIdQuery, CustomResponseModel>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<CustomResponseModel> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            CustomResponseModel responseModel = new CustomResponseModel();
            List<Product> products = new List<Product>();
            string query = $"SELECT * FROM [CqrsDapperExample].[dbo].[Product] Where CategoryId = @CategoryId";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var result = await con.QueryAsync<Product>(query, new { CategoryId = request.CategoryId });
                products = result.ToList();
                responseModel.Success(200, products);
            };
            return responseModel;
        }
    }
}
