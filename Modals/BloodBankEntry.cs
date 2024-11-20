using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace APIAssignment.Modals
{
    public class BloodBankEntry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Donor name is required.")]
        public string DonorName { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(19, 70, ErrorMessage = "Age must be greater than 18 for donating.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Blood type is required.")]
        [RegularExpression(@"^(A|B|AB|O)[+-]$", ErrorMessage = "Invalid blood type. Valid types are A+, B+, AB+, AB-, O+, and O-.")]
        public string BloodType { get; set; }

        [Required(ErrorMessage = "Contact information is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string ContactInfo { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Collection date is required.")]
        public DateTime CollectionDate { get; set; }

        [Required(ErrorMessage = "Expiration date is required.")]
        public DateTime ExpirationDate { get; set; }

        public string Status { get; set; }
        public bool ValidateExpirationDate()
        {
            return ExpirationDate > CollectionDate;
        }
    }
}
