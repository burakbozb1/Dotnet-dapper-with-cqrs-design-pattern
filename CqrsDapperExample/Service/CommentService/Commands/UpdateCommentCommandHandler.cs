using CqrsDapperExample.Models;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CommentService.Commands
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, CustomResponseModel>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<CustomResponseModel> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            CustomResponseModel responseModel = new CustomResponseModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE [CqrsDapperExample].[dbo].[Comment] SET ProductId = @ProductId, CommentText=@CommentText WHERE Id = @Id";
                int result = await connection.ExecuteAsync(query, new { Id = request.comment.Id, ProductId = request.comment.ProductId, CommentText = request.comment.CommentText });
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
