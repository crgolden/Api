namespace Cef.API.Options
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class PaymentOptions
    {
        public Stripe Stripe { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class Stripe
    {
        public string SecretKey { get; set; }
    }
}