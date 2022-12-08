using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CategoryService.Queries
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CustomResponseModel>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<CustomResponseModel> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            Category category = null;
            CustomResponseModel responseModel = new CustomResponseModel();
            string query = $"SELECT * FROM [CqrsDapperExample].[dbo].[Category] WHERE Id = @Id";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var result = await con.QueryAsync<Category>(query, new { Id = request.Id });
                category = result.SingleOrDefault();
                if (category!=null)
                {
                    responseModel.Success(200, category);
                }
                else
                {
                    responseModel.Fail(404, "Kategori bulunamadı");
                }
            };
            return responseModel;
        }
    }
}
