using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CommentService.Queries
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, CustomResponseModel>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<CustomResponseModel> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            Comment comment = null;
            CustomResponseModel responseModel = new CustomResponseModel();
            string query = $"SELECT * FROM [CqrsDapperExample].[dbo].[Comment] WHERE Id = @Id";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var result = await con.QueryAsync<Comment>(query, new { Id = request.Id });
                comment = result.SingleOrDefault();
                if (comment != null)
                {
                    responseModel.Success(200, comment);
                }
                else
                {
                    responseModel.Fail(404, "Not found");
                }
            };
            return responseModel;
        }
    }
}
