using OnlineCreditSystem.Areas.Admin.Models.DashboardViewModels;
using System.Collections.Generic;

namespace OnlineCreditSystem.Services
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetUsers();
    }
}
