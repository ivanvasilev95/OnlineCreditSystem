using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineCreditSystem.Data
{
    public class Role : IdentityRole
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
