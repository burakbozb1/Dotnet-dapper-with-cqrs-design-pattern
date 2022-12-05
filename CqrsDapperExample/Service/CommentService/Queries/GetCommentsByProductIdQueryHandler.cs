using CqrsDapperExample.Entities;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CommentService.Queries
{
    public class GetCommentsByProductIdQueryHandler : IRequestHandler<GetCommentsByProductIdQuery, List<Comment>>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<List<Comment>> Handle(GetCommentsByProductIdQuery request, CancellationToken cancellationToken)
        {
            List<Comment> comments = new List<Comment>();
            string query = $"SELECT * FROM [CqrsDapperExample].[dbo].[Comment] Where ProductId = @ProductId";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                comments = con.QueryAsync<Comment>(query, new { ProductId = request.ProductId }).Result.ToList();
                con.Close();
            };
            return comments;
        }
    }
}
