using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.CategoryService.Queries
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, CustomResponseModel>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;
        public async Task<CustomResponseModel> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            CustomResponseModel responseModel = new CustomResponseModel();
            List<Category> categories = new List<Category>();
            string query = $"SELECT * FROM [CqrsDapperExample].[dbo].[Category]";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var result = await con.QueryAsync<Category>(query);
                categories = result.ToList();
                responseModel.Success(200, categories);
            };
            return responseModel;
        }
    }
}
