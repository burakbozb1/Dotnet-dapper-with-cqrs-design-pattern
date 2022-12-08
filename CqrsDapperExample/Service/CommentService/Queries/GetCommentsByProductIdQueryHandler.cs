using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CommentService.Queries
{
    public class GetCommentsByProductIdQueryHandler : IRequestHandler<GetCommentsByProductIdQuery, CustomResponseModel>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<CustomResponseModel> Handle(GetCommentsByProductIdQuery request, CancellationToken cancellationToken)
        {
            CustomResponseModel responseModel = new CustomResponseModel();
            List<Comment> comments = new List<Comment>();
            string query = $"SELECT * FROM [CqrsDapperExample].[dbo].[Comment] Where ProductId = @ProductId";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var result = await con.QueryAsync<Comment>(query, new { ProductId = request.ProductId });
                comments = result.ToList();
                responseModel.Success(200, comments);
            };
            return responseModel;
        }
    }
}
