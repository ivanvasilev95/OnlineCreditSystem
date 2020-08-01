using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineCreditSystem.Data
{
    public class User : IdentityUser
    {
        public int Credits { get; set; }
        public ICollection<Transaction> TransactionsSent { get; set; }
        public ICollection<Transaction> TransactionsReceived { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
