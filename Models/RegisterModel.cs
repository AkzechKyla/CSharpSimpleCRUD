using System.ComponentModel.DataAnnotations;

namespace CSharpSimpleCRUD.Models
{
    public class RegisterModel
    {
        public int ParticipantId { get; set; }

        [Required(ErrorMessage = "The First Name is required.")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "The Last Name is required.")]
        public string LastName { get; set; } = "";

        [Required(ErrorMessage = "The Address is required.")]
        public string Address { get; set; } = "";

        [Required(ErrorMessage = "The Phone Number is required.")]
        public string PhoneNumber { get; set; } = "";

        [Required(ErrorMessage = "The E-mail Address is required.")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "The Birth Date is required.")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "The Gender is required.")]
        public string Gender { get; set; } = "";

        [Required(ErrorMessage = "The T-shirt Size is required.")]
        public string TShirtSize { get; set; } = "";
    }
}
