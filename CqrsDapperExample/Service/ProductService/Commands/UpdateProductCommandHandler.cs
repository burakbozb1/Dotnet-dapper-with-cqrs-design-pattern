using CqrsDapperExample.Models;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.ProductService.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, CustomResponseModel>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<CustomResponseModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            CustomResponseModel responseModel = new CustomResponseModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE [CqrsDapperExample].[dbo].[Product] SET Name = @Name, CategoryId=@CategoryId WHERE Id = @Id";
                int result = await connection.ExecuteAsync(query, new { Id = request.product.Id, Name = request.product.Name, CategoryId= request.product.CategoryId });
                if (result>0)
                {
                    responseModel.Success(204, null);
                }
                else
                {
                    responseModel.Fail(404, "Not Found");
                }
            }
            return responseModel;
        }
    }
}
