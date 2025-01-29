using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpSimpleCRUD.Entities
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [Required(ErrorMessage = "The First Name is required.")]
        [MaxLength(100)]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "The Last Name is required.")]
        [MaxLength(100)]
        public string LastName { get; set; } = "";

        [Required(ErrorMessage = "The E-mail Address is required.")]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "The Phone Number is required.")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = "";

        [Required(ErrorMessage = "The Event Title is required.")]
        [MaxLength(200)]
        public string EventTitle { get; set; } = "";

        [Required(ErrorMessage = "The Event Date is required.")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "The Organizer Name is required.")]
        [MaxLength(255)]
        public string Organizer { get; set; } = "";

        [Required(ErrorMessage = "The Event Location is required.")]
        [MaxLength(255)]
        public string Location { get; set; } = "";

        [Required(ErrorMessage = "The Event Description is required.")]
        [MaxLength(1000)]
        public string Description { get; set; } = "";

        [MaxLength(1000)]
        public string? RegistrationDetails { get; set; } = "";

        [MaxLength(255)]
        public string? CustomerSupportContactDetails { get; set; } = "";
    }
}
