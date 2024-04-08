using System.ComponentModel.DataAnnotations;

namespace Laba10.Models
{
    public class RegistrationForm
    {
        [Required(ErrorMessage = "The 'Name' field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The 'Email' field is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The 'Desired consultation date' field is required.")]
        [FutureDate(ErrorMessage = "Date must be in the future.")]
        public DateTime ConsultationDate { get; set; }

        [Required(ErrorMessage = "Please select a product.")]
        public string SelectedProduct { get; set; }

    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return date.Date > DateTime.Now.Date && date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
            }
            return false;
        }
    }
}