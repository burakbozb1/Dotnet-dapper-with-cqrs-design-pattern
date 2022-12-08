using CqrsDapperExample.Models;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CategoryService.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CustomResponseModel>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<CustomResponseModel> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            CustomResponseModel responseModel = new CustomResponseModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE [CqrsDapperExample].[dbo].[Category] SET Name = @Name WHERE Id = @Id";
                int result = await connection.ExecuteAsync(query, new { Id = request.category.Id, Name = request.category.Name });
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
