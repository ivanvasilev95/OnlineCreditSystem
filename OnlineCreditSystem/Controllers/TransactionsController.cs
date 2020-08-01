using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCreditSystem.Models.TransactionsViewModels;
using OnlineCreditSystem.Services;

namespace OnlineCreditSystem.Controllers
{
    [Authorize(Roles="Member")]
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_transactionService.CanMakeTransaction(User.Identity.Name, model.RecipientPhoneNumber, model.Amount, model.Comment, out string resultMessage))
                {
                    ViewBag.SuccessMessage = resultMessage;
                    ModelState.Clear();

                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = resultMessage;
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Mine()
        {
            var transactions = _transactionService.GetUserTransactions(User.Identity.Name);
            return View(transactions);
        }
    }
}