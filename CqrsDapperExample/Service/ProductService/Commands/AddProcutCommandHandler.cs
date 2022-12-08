using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using CqrsDapperExample.Service.ProductService.Queries;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.ProductService.Commands
{
    public class AddProcutCommandHandler : IRequestHandler<AddProcutCommand, CustomResponseModel>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        private readonly IMediator mediator;

        public AddProcutCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<CustomResponseModel> Handle(AddProcutCommand request, CancellationToken cancellationToken)
        {
            CustomResponseModel responseModel = new CustomResponseModel();
            Product product = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO [CqrsDapperExample].[dbo].[Product] (Name,CategoryId) OUTPUT INSERTED.Id VALUES (@Name,@CategoryId)";
                string getQuery = $"SELECT * FROM [CqrsDapperExample].[dbo].[Product] WHERE Id = @Id";
                int id = await connection.QuerySingleAsync<int>(query, new { Name = request.product.Name, CategoryId = request.product.CategoryId });
                var result = await connection.QueryAsync<Product>(getQuery, new { Id = id });
                product = result.SingleOrDefault();
                responseModel.Success(201, product);
            }

            return responseModel;
        }
    }
}
