namespace crgolden.Api.ProductCategories
{
    using Abstractions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class ProductCategoryListRequest : ListRequest<ProductCategory, ProductCategoryModel>
    {
        public ProductCategoryListRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
