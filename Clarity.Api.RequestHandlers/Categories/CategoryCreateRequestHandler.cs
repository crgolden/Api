namespace Clarity.Api.Categories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CategoryCreateRequestHandler : CreateRequestHandler<CategoryCreateRequest, Category>
    {
        public CategoryCreateRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Category> Handle(CategoryCreateRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
