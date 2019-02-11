namespace Cef.API.Options
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class ValidationOptions
    {
        public SmartyStreets SmartyStreets { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SmartyStreets
    {
        public string AuthId { get; set; }

        public string AuthToken { get; set; }
    }
}