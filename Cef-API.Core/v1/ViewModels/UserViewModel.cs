namespace Cef_API.Core.v1.ViewModels
{
    using System;

    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}