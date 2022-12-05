﻿using CqrsDapperExample.Models;
using MediatR;

namespace CqrsDapperExample.Service.ProductService.Queries
{
    public class GetProductWithCategoryAndCommentsQuery:IRequest<List<ProductDto>>
    {
        public int Id { get; set; }

        public GetProductWithCategoryAndCommentsQuery(int id)
        {
            Id = id;
        }
    }
}
