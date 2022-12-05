using CqrsDapperExample.Entities;
using CqrsDapperExample.Service.CategoryService.Queries;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CategoryService.Commands
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Category>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        private readonly IMediator mediator;

        public AddCategoryCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<Category> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO [CqrsDapperExample].[dbo].[Category] (Name) OUTPUT INSERTED.Id VALUES (@Name)";
                int id = await connection.QuerySingleAsync<int>(query, new { Name = request.category.Name });
                category = await mediator.Send(new GetCategoryQuery(id));
                connection.Close();
            }

            return category;
        }
    }
}
