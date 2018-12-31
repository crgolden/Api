namespace Cef.API.Options
{
    public class PaymentOptions
    {
        public Stripe Stripe { get; set; }
    }

    public class Stripe
    {
        public string SecretKey { get; set; }
    }
}