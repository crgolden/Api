namespace Cef_API.ViewModels.v1.AccountViewModels
{
    using System;

    public class AccountViewModel : BaseViewModel
    {
        public override string Name => $"{FirstName} {LastName}";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime Expiration { get; set; }
    }
}