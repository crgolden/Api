namespace Cef_API.v1.Data.Relationships
{
    using System;
    using Models;
    using Microsoft.AspNetCore.Identity;

    public class RoleClaim : IdentityRoleClaim<Guid>
    {
        public virtual Role Role { get; set; }
    }
}
