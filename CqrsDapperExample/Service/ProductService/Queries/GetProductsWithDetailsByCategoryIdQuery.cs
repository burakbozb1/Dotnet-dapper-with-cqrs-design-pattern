﻿using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.ProductService.Queries
{
    public class GetProductsWithDetailsByCategoryIdQuery:IRequest<List<ProductDto>>
    {
        public int CategoryId { get; set; }

        public GetProductsWithDetailsByCategoryIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
