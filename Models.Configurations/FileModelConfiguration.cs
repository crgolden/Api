namespace crgolden.Api
{
    using Abstractions;
    using Microsoft.AspNet.OData.Builder;

    public class FileModelConfiguration : ModelConfiguration<FileModel>
    {
        protected override EntityTypeConfiguration<FileModel> ConfigureCurrent(ODataModelBuilder builder)
        {
            var file = builder.EntitySet<FileModel>("Files").EntityType;
            file.HasKey(p => p.Id);
            return file;
        }
    }
}
