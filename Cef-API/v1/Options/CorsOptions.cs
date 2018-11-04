namespace Cef_API.v1.Options
{
    public class CorsOptions
    {
        public Origins[] Origins { get; set; }
    }

    public class Origins
    {
        public string Url { get; set; }
    }
}
