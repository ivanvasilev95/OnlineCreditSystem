using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCreditSystem.Services;

namespace OnlineCreditSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IUserService _userService;

        public DashboardController(ITransactionService transactionService, IUserService userService)
        {
            _transactionService = transactionService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Transactions()
        {
            var transactions = _transactionService.GetAllTransactions();
            return View(transactions);
        }

        [HttpGet]
        public IActionResult Users()
        {
            var users = _userService.GetUsers();
            return View(users);
        }
    }
}