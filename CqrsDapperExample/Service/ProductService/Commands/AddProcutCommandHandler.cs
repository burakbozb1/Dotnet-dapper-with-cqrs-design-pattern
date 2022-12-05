using CqrsDapperExample.Entities;
using CqrsDapperExample.Service.ProductService.Queries;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.ProductService.Commands
{
    public class AddProcutCommandHandler : IRequestHandler<AddProcutCommand, Product>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        private readonly IMediator mediator;

        public AddProcutCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<Product> Handle(AddProcutCommand request, CancellationToken cancellationToken)
        {
            Product product = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO [CqrsDapperExample].[dbo].[Product] (Name,CategoryId) OUTPUT INSERTED.Id VALUES (@Name,@CategoryId)";
                int id = await connection.QuerySingleAsync<int>(query, new { Name = request.product.Name, CategoryId= request.product.CategoryId });
                product = await mediator.Send(new GetProductQuery(id));
                connection.Close();
            }

            return product;
        }
    }
}
