using Microsoft.AspNetCore.Mvc;
using OnlineCreditSystem.Services;

namespace OnlineCreditSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransactionService _transactionService;

        public HomeController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Home/Error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            switch(statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the page could not be found.";
                    break;
            }

            return View();
        }
    }
}
