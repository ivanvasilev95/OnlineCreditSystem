using System;

namespace OnlineCreditSystem.Models
{
    public class TransactionViewModel
    {
        public string SenderUsername { get; set; }
        public string RecipientUsername { get; set; }
        public int Amount { get; set; }
        public string Comment { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
