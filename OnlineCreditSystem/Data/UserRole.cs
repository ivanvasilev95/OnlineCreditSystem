using Microsoft.AspNetCore.Identity;

namespace OnlineCreditSystem.Data
{
    public class UserRole : IdentityUserRole<string>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
