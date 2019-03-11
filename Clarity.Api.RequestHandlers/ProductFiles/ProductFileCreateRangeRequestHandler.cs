namespace Clarity.Api.ProductFiles
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileCreateRangeRequestHandler : CreateRangeRequestHandler<ProductFileCreateRangeRequest, IEnumerable<ProductFileModel>, ProductFile, ProductFileModel>
    {
        public ProductFileCreateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<IEnumerable<ProductFileModel>> Handle(ProductFileCreateRangeRequest request, CancellationToken token)
        {
            var productFiles = Mapper.Map<IEnumerable<ProductFile>>(request.Models);
            foreach (var productFile in productFiles)
            {
                Context.Add(productFile);
                await Context.Entry(productFile).Reference(x => x.File).LoadAsync(token);
            }

            await Context.SaveChangesAsync(token).ConfigureAwait(false);
            return Mapper.Map<IEnumerable<ProductFileModel>>(productFiles);
        }
    }
}
