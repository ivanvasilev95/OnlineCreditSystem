using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineCreditSystem.Models.TransactionsViewModels
{
    public class CreateTransactionViewModel
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Recipient Phone Number")]
        [RegularExpression(@"^\(?(^0[0-9]{2})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number must be 10 digits and must start with 0")]
        public string RecipientPhoneNumber { get; set; }

        [Required]
        [Display(Name = "Credits")]
        [Range(1, int.MaxValue, ErrorMessage = "Credits must be a positive value")]
        public int Amount { get; set; }

        [MaxLength(30)]
        public string Comment { get; set; }
    }
}