namespace Clarity.Api.ProductFiles
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileCreateRangeRequestHandler : CreateRangeRequestHandler<ProductFileCreateRangeRequest, ProductFile, ProductFileModel>
    {
        public ProductFileCreateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<(ProductFileModel[], object[][])> Handle(ProductFileCreateRangeRequest request, CancellationToken token)
        {
            var productFiles = Mapper.Map<ProductFile[]>(request.Models);
            foreach (var productFile in productFiles)
            {
                Context.Add(productFile);
                await Context.Entry(productFile).Reference(x => x.File).LoadAsync(token);
            }

            await Context.SaveChangesAsync(token).ConfigureAwait(false);
            return (Mapper.Map<ProductFileModel[]>(productFiles), productFiles.Select(x => new object[]{ x.ProductId, x.FileId }).ToArray());
        }
    }
}
