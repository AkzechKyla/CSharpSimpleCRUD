using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;

namespace CSharpSimpleCRUD.Models
{
    public class ParticipantModel
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

        public void SaveToDatabase()
        {
            string connectionString = "Data Source=LAPTOP-GM3E4EUK;Initial Catalog=TestDatabase;Integrated Security=True;Trust Server Certificate=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Participants (FirstName, LastName, Address, PhoneNumber, Email, BirthDate, Gender, TShirtSize) " +
                                   "VALUES (@FirstName, @LastName, @Address, @PhoneNumber, @Email, @BirthDate, @Gender, @TShirtSize)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@BirthDate", BirthDate);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@TShirtSize", TShirtSize);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
