using OnlineCreditSystem.Areas.Admin.Models.DashboardViewModels;
using OnlineCreditSystem.Data;
using System.Collections.Generic;
using System.Linq;

namespace OnlineCreditSystem.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _db;
        public UserService(DataContext db)
        {
            _db = db;
        }

        public IEnumerable<UserViewModel> GetUsers()
        { 
            var users = _db.Users.Where(u => u.UserName != "admin")
                .Select(u => new UserViewModel
                {
                    UserName = u.UserName,
                    Phone = u.PhoneNumber,
                    Credits = u.Credits
                })
                .ToList();

            return users;
        }
    }
}
