using CqrsDapperExample.Entities;
using CqrsDapperExample.Models;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CqrsDapperExample.Service.ProductService.Queries
{
    public class GetProductWithCategoryAndCommentsQueryHandler : IRequestHandler<GetProductWithCategoryAndCommentsQuery, CustomResponseModel>
    {
        private readonly string connectionString = ConnectionStrings.defaultConnection;

        public async Task<CustomResponseModel> Handle(GetProductWithCategoryAndCommentsQuery request, CancellationToken cancellationToken)
        {
            CustomResponseModel responseModel = new CustomResponseModel();
            List<ProductDto> products = new List<ProductDto>();
            string query = @"Select 
                      p.Id as Id,
                      p.Name as Name,
                      c.Id as CategoryId,
                      c.Name as CategoryName,
                      cm.Id as Comments_CommentId,
                      cm.CommentText as Comments_CommentText
                  from [CqrsDapperExample].[dbo].[Product] p
                  Inner Join [CqrsDapperExample].[dbo].[Category] c On C.Id=p.CategoryId
                  Left Join [CqrsDapperExample].[dbo].[Comment] cm on cm.ProductId = p.Id
                  Where p.Id=@Id";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                { 
                    dynamic data = await con.QueryAsync<dynamic>(query, new {Id = request.Id});
                    Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(ProductDto), new List<string> { "Id" });
                    Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(CommentDto), new List<string> { "CommentId" });
                    products = (Slapper.AutoMapper.MapDynamic<ProductDto>(data) as IEnumerable<ProductDto>).ToList();
                    responseModel.Success(200, products);
                }
            };
            return responseModel;
        }
    }
}
