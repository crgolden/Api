namespace Clarity.Api.Categories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class CategoryDeleteRequestHandler : DeleteRequestHandler<CategoryDeleteRequest, Category>
    {
        public CategoryDeleteRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(CategoryDeleteRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
