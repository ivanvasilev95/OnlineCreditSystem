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
        Result MakeTransaction(string senderUsername, string enteredRecipientPhone, int amount, string comment);
        IEnumerable<TransactionViewModel> GetAllTransactions();
        IEnumerable<TransactionViewModel> GetUserTransactions(string userName);
    }
}
