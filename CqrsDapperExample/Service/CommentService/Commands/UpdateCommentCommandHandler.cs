using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CommentService.Commands
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, bool>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<bool> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE [CqrsDapperExample].[dbo].[Comment] SET ProductId = @ProductId, CommentText=@CommentText WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = request.comment.Id, ProductId = request.comment.ProductId, CommentText = request.comment.CommentText });
                connection.Close();
            }
            return true;
        }
    }
}
