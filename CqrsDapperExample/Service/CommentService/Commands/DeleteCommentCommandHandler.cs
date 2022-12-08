using CqrsDapperExample.Models;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CommentService.Commands
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, CustomResponseModel>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<CustomResponseModel> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            CustomResponseModel responseModel = new CustomResponseModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"DELETE FROM [CqrsDapperExample].[dbo].[Comment] WHERE Id = @Id";
                int result = await connection.ExecuteAsync(query, new { Id = request.Id });
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
