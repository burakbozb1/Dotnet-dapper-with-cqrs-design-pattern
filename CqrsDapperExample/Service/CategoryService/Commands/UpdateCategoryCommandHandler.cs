using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CategoryService.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE [CqrsDapperExample].[dbo].[Category] SET Name = @Name WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = request.category.Id, Name = request.category.Name });
                connection.Close();
            }
            return true;
        }
    }
}
