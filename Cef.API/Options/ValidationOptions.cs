namespace Cef.API.Options
{
    public class ValidationOptions
    {
        public SmartyStreets SmartyStreets { get; set; }
    }

    public class SmartyStreets
    {
        public string AuthId { get; set; }

        public string AuthToken { get; set; }
    }
}