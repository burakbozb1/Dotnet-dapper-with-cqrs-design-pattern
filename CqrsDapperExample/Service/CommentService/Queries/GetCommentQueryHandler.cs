using CqrsDapperExample.Entities;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CommentService.Queries
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, Comment>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<Comment> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            Comment comment = null;
            string query = $"SELECT * FROM [CqrsDapperExample].[dbo].[Comment] WHERE Id = @Id";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                comment = con.QueryAsync<Comment>(query, new { Id = request.Id }).Result.SingleOrDefault();
                con.Close();
            };
            return comment;
        }
    }
}
