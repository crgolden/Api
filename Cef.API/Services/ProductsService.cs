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

#pragma warning disable 1998
        public override async Task<IEnumerable<Product>> Index()
        {
            return Context.Set<Product>()
                .Include(x => x.ProductFiles)
                .ThenInclude(x => x.Model2)
                .AsNoTracking();
        }
#pragma warning restore 1998

        public override async Task<Product> Details(Guid id)
        {
            return await Context.Set<Product>()
                .Include(x => x.ProductFiles)
                .ThenInclude(x => x.Model2)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public override async Task<Product> Create(Product model)
        {
            return await base.Create(model);
        }

        public override async Task<List<Product>> CreateRange(List<Product> models)
        {
            return await base.CreateRange(models);
        }

        public override async Task Edit(Product model)
        {
            await base.Edit(model);
        }

        public override async Task EditRange(List<Product> models)
        {
            await base.EditRange(models);
        }

#pragma warning disable 1998
        public override async Task Delete(Guid id)
        {
        }
#pragma warning restore 1998
    }
}
