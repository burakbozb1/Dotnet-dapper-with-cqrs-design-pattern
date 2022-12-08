using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using CqrsDapperExample.Service.CategoryService.Queries;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CategoryService.Commands
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, CustomResponseModel>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        private readonly IMediator mediator;

        public AddCategoryCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<CustomResponseModel> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = null;
            CustomResponseModel responseModel = new CustomResponseModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO [CqrsDapperExample].[dbo].[Category] (Name) OUTPUT INSERTED.Id VALUES (@Name)";
                string getQuery = @"SELECT * FROM [CqrsDapperExample].[dbo].[Category] WHERE Id = @Id";
                int id = await connection.QuerySingleAsync<int>(query, new { Name = request.category.Name });
                var result = await connection.QueryAsync<Category>(getQuery, new { Id = id });
                category = result.SingleOrDefault();
                responseModel.Success(201, category);
            }

            return responseModel;
        }
    }
}
