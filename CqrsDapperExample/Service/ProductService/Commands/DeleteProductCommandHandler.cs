using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.ProductService.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"DELETE FROM [CqrsDapperExample].[dbo].[Product] WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = request.Id });
                connection.Close();
            }
            return true;
        }
    }
}
