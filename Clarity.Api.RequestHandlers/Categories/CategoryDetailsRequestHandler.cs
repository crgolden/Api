namespace Clarity.Api.Categories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CategoryDetailsRequestHandler : DetailsRequestHandler<CategoryDetailsRequest, Category>
    {
        public CategoryDetailsRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Category> Handle(CategoryDetailsRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
