namespace Cef.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core.Services;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class FilesService : BaseModelService<File>
    {
        public FilesService(DbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<File>> Index()
        {
            return await base.Index();
        }

        public override async Task<File> Details(Guid id)
        {
            return await base.Details(id);
        }

        public override async Task<File> Create(File model)
        {
            return await base.Create(model);
        }

        public override async Task<List<File>> CreateRange(List<File> models)
        {
            return await base.CreateRange(models);
        }

        public override async Task Edit(File model)
        {
            await base.Edit(model);
        }

        public override async Task EditRange(List<File> models)
        {
            await base.EditRange(models);
        }

        public override async Task Delete(Guid id)
        {
            await base.Delete(id);
        }
    }
}
