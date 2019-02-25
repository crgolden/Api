﻿namespace Clarity.Api.Categories
{
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CategoryDeleteRequestHandler : DeleteRequestHandler<CategoryDeleteRequest, Category>
    {
        public CategoryDeleteRequestHandler(DbContext context) : base(context)
        {
        }
    }
}
