using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.ProductService.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE [CqrsDapperExample].[dbo].[Product] SET Name = @Name, CategoryId=@CategoryId WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = request.product.Id, Name = request.product.Name, CategoryId= request.product.CategoryId });
                connection.Close();
            }
            return true;
        }
    }
}
