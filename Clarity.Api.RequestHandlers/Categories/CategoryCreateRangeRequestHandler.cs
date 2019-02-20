namespace Clarity.Api.Categories
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CategoryCreateRangeRequestHandler
        : CreateRangeRequestHandler<CategoryCreateRangeRequest, IEnumerable<Category>, Category>
    {
        public CategoryCreateRangeRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Category>> Handle(CategoryCreateRangeRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
