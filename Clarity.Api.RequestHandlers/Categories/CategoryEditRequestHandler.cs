namespace Clarity.Api.Categories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class CategoryEditRequestHandler : EditRequestHandler<CategoryEditRequest, Category>
    {
        public CategoryEditRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(CategoryEditRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
