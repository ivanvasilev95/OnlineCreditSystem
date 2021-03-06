﻿using Microsoft.EntityFrameworkCore;
using OnlineCreditSystem.Models;
using OnlineCreditSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineCreditSystem.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly DataContext _db;

        public TransactionService(DataContext db)
        {
            _db = db;
        }

        public Result MakeTransaction(string senderUsername, string enteredRecipientPhone, int amount, string comment)
        {
            var currentUser = _db.Users
                .FirstOrDefault(u => u.UserName == senderUsername);
            var recipient = _db.Users
                .FirstOrDefault(u => u.PhoneNumber == enteredRecipientPhone && u.UserName != ServiceConstants.AdminUsername);

            var result = ValidateInput(currentUser, recipient, enteredRecipientPhone, amount);
            if (result.Succeeded)
            {
                ExecuteTransaction(currentUser, recipient, amount, comment);
            }

            return result;
        }

        private Result ValidateInput(User currentUser, User recipient, string enteredRecipientPhone, int enteredAmount)
        {
            if (currentUser == null)
            {
                return new Result { Succeeded = false, Message = ServiceConstants.UserNotFound };
            }

            if (currentUser.Credits == 0 || currentUser.Credits < enteredAmount)
            {
                return new Result { Succeeded = false, Message = ServiceConstants.NotEnoughCredits };
            }

            if (currentUser.PhoneNumber == enteredRecipientPhone)
            {
                return new Result { Succeeded = false, Message = ServiceConstants.CantSendToYourself };
            }

            if (recipient == null)
            {
                return new Result { Succeeded = false, Message = ServiceConstants.RecipientNotFound };
            }

            return new Result { Succeeded = true, Message = ServiceConstants.SuccessMessage };
        }

        private void ExecuteTransaction(User currentUser, User recipient, int amount, string comment)
        {
            currentUser.Credits -= amount;
            recipient.Credits += amount;

            var transaction = new Transaction
            {
                Sender = currentUser,
                Recipient = recipient,
                Amount = amount,
                Comment = comment,
                TransactionDate = DateTime.Now
            };

            _db.Transactions.Add(transaction);
            _db.SaveChanges();
        }

        public IEnumerable<TransactionViewModel> GetAllTransactions()
        {
            var transactions =_db.Transactions
                                    .Include(u => u.Sender)
                                    .Include(u => u.Recipient)
                                    .AsQueryable();

            return transactions
                .Select(t => new TransactionViewModel { SenderUsername = t.Sender.UserName,
                                                            RecipientUsername = t.Recipient.UserName,
                                                            Amount = t.Amount, 
                                                            Comment = t.Comment,
                                                            TransactionDate = t.TransactionDate })
                .OrderByDescending(t => t.TransactionDate)
                .ToList();
        }

        public IEnumerable<TransactionViewModel> GetUserTransactions(string userName)
        {
            var userTransactions = _db.Transactions
                                        .Include(u => u.Sender)
                                        .Include(u => u.Recipient)
                                        .AsQueryable();

            return userTransactions
                .Where(t => t.Sender.UserName == userName || t.Recipient.UserName == userName)
                .Select(t => new TransactionViewModel
                {
                    SenderUsername = t.Sender.UserName,
                    RecipientUsername = t.Recipient.UserName,
                    Amount = t.Amount,
                    Comment = t.Comment,
                    TransactionDate = t.TransactionDate
                })
                .ToList();
        }
    }
}
