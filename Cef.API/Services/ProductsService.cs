namespace Cef.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core.Services;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ProductsService : BaseModelService<Product>
    {
        public ProductsService(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Product> Index()
        {
            return base.Index();
        }

        public override async Task<Product> Details(Guid id)
        {
            return await base.Details(id);
        }

        public override async Task<Product> Create(Product model)
        {
            return await base.Create(model);
        }

        public override async Task Edit(Product model)
        {
            await base.Edit(model);
        }

        public override async Task Delete(Guid id)
        {
            await base.Delete(id);
        }
    }
}
