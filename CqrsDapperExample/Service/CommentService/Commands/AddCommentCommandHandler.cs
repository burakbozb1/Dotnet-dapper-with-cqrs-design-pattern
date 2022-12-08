using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using CqrsDapperExample.Service.CommentService.Queries;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CommentService.Commands
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, CustomResponseModel>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        private readonly IMediator mediator;

        public AddCommentCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<CustomResponseModel> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            CustomResponseModel responseModel = new CustomResponseModel();
            Comment comment = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO [CqrsDapperExample].[dbo].[Comment] (ProductId,CommentText) OUTPUT INSERTED.Id VALUES (@ProductId,@CommentText)";
                string getQuery = $"SELECT * FROM [CqrsDapperExample].[dbo].[Comment] Where Id = @Id";
                int id = await connection.QuerySingleAsync<int>(query, new { ProductId = request.comment.ProductId, CommentText = request.comment.CommentText});
                var result = await connection.QueryAsync<Comment>(getQuery, new { Id = id });
                comment = result.SingleOrDefault();
                responseModel.Success(201, comment);
            }

            return responseModel;
        }
    }
}
