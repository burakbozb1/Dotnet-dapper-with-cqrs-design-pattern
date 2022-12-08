using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.ProductService.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, CustomResponseModel>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<CustomResponseModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            CustomResponseModel responseModel = new CustomResponseModel();
            Product product = null;
            string query = $"SELECT * FROM [CqrsDapperExample].[dbo].[Product] WHERE Id = @Id";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var result = await con.QueryAsync<Product>(query, new { Id = request.Id });
                product = result.SingleOrDefault();
                if (product!=null)
                {
                    responseModel.Success(200, product);
                }
                else
                {
                    responseModel.Fail(404, "Not Found");
                }
            };
            return responseModel;
        }
    }
}
