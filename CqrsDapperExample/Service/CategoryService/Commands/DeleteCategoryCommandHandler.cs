using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CategoryService.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"DELETE FROM [CqrsDapperExample].[dbo].[Category] WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = request.Id });
                connection.Close();
            }
            return true;
        }
    }
}
