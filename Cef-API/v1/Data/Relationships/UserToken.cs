namespace Cef_API.v1.Data.Relationships
{
    using System;
    using Models;
    using Microsoft.AspNetCore.Identity;

    public class UserToken : IdentityUserToken<Guid>
    {
        public virtual User User { get; set; }
    }
}
