namespace Cef.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core.Services;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CategoriesService : BaseModelService<Category>
    {
        public CategoriesService(DbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Category>> Index()
        {
            return await base.Index();
        }

        public override async Task<Category> Details(Guid id)
        {
            return await base.Details(id);
        }

        public override async Task<Category> Create(Category model)
        {
            return await base.Create(model);
        }

        public override async Task<List<Category>> CreateRange(List<Category> models)
        {
            return await base.CreateRange(models);
        }

        public override async Task Edit(Category model)
        {
            await base.Edit(model);
        }

        public override async Task EditRange(List<Category> models)
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
