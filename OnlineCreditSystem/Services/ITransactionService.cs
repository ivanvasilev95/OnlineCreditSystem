using OnlineCreditSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace OnlineCreditSystem.Services
{
    public interface ITransactionService
    {
        bool CanMakeTransaction(string senderUsername, string enteredRecipientPhone, int amount, string comment, out string resultMessage);
        IEnumerable<TransactionViewModel> GetAllTransactions();
        IEnumerable<TransactionViewModel> GetUserTransactions(string userName);
    }
}
