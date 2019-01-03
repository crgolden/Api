namespace Cef.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core.Services;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Relationships;

    public class ProductFilesService : BaseRelationshipService<ProductFile, Product, File>
    {
        public ProductFilesService(DbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<ProductFile>> Index()
        {
            return await base.Index();
        }

        public override async Task<ProductFile> Details(Guid id1, Guid id2)
        {
            return await base.Details(id1, id2);
        }

        public override async Task<ProductFile> Create(ProductFile relationship)
        {
            return await base.Create(relationship);
        }

        public override async Task<List<ProductFile>> CreateRange(List<ProductFile> relationships)
        {
            return await base.CreateRange(relationships);
        }

        public override async Task Edit(ProductFile relationship)
        {
            await base.Edit(relationship);
        }

        public override async Task EditRange(List<ProductFile> relationships)
        {
            await base.EditRange(relationships);
        }

        public override async Task Delete(Guid id1, Guid id2)
        {
            await base.Delete(id1, id2);
        }
    }
}
