using System;

namespace OnlineCreditSystem.Data
{
    public class Transaction
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; }
        public string RecipientId { get; set; }
        public User Recipient { get; set; }
        public int Amount { get; set; }
        public string Comment { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
