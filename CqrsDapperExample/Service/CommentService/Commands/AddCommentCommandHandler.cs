using CqrsDapperExample.Entities;
using CqrsDapperExample.Service.CommentService.Queries;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CommentService.Commands
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, Comment>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        private readonly IMediator mediator;

        public AddCommentCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<Comment> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            Comment comment = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO [CqrsDapperExample].[dbo].[Comment] (ProductId,CommentText) OUTPUT INSERTED.Id VALUES (@ProductId,@CommentText)";
                int id = await connection.QuerySingleAsync<int>(query, new { ProductId = request.comment.ProductId, CommentText = request.comment.CommentText});
                comment = await mediator.Send(new GetCommentQuery(id));
                connection.Close();
            }

            return comment;
        }
    }
}
