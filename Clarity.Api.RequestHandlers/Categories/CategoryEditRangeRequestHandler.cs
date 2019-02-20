namespace Clarity.Api.Categories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class CategoryEditRangeRequestHandler : EditRangeRequestHandler<CategoryEditRangeRequest, Category>
    {
        public CategoryEditRangeRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(CategoryEditRangeRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
