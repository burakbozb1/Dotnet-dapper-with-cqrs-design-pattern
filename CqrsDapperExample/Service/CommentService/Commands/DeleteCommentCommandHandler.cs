using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CommentService.Commands
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, bool>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"DELETE FROM [CqrsDapperExample].[dbo].[Comment] WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = request.Id });
                connection.Close();
            }
            return true;
        }
    }
}
