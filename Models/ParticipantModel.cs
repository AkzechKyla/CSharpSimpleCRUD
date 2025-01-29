using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;

namespace CSharpSimpleCRUD.Models
{
    public class ParticipantModel
    {
        public string? ParticipantId { get; set; }

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

        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; } = DateTime.Now;

        public void SaveToDatabase()
        {
            string connectionString = "Data Source=LAPTOP-GM3E4EUK;Initial Catalog=TestDatabase;Integrated Security=True;Trust Server Certificate=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Participants (FirstName, LastName, Address, PhoneNumber, Email, BirthDate, Gender, TShirtSize, RegisterDate) " +
                                   "VALUES (@FirstName, @LastName, @Address, @PhoneNumber, @Email, @BirthDate, @Gender, @TShirtSize, @RegisterDate)";

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
                        command.Parameters.AddWithValue("@RegisterDate", RegisterDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public List<ParticipantModel> FetchFromDatabase()
        {
            List<ParticipantModel> listParticipants = new List<ParticipantModel>();

            string connectionString = "Data Source=LAPTOP-GM3E4EUK;Initial Catalog=TestDatabase;Integrated Security=True;Trust Server Certificate=True";
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Participants";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ParticipantModel participant = new ParticipantModel();
                                participant.ParticipantId = "" + reader.GetInt32(0);
                                participant.FirstName = reader.GetString(1);
                                participant.LastName = reader.GetString(2);
                                participant.Address = reader.GetString(3);
                                participant.PhoneNumber = reader.GetString(4);
                                participant.Email = reader.GetString(5);
                                participant.BirthDate = reader.GetDateTime(6);
                                participant.Gender = reader.GetString(7);
                                participant.TShirtSize = reader.GetString(8);
                                participant.RegisterDate = reader.GetDateTime(9);

                                listParticipants.Add(participant);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return listParticipants;
        }

        public ParticipantModel FetchFromDatabase(int id)
        {
            string connectionString = "Data Source=LAPTOP-GM3E4EUK;Initial Catalog=TestDatabase;Integrated Security=True;Trust Server Certificate=True";
            ParticipantModel participant = new ParticipantModel();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Participants WHERE ParticipantId = @ParticipantId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ParticipantId", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            participant.ParticipantId = reader.GetInt32(0).ToString();
                            participant.FirstName = reader.GetString(1);
                            participant.LastName = reader.GetString(2);
                            participant.Address = reader.GetString(3);
                            participant.PhoneNumber = reader.GetString(4);
                            participant.Email = reader.GetString(5);
                            participant.BirthDate = reader.GetDateTime(6);
                            participant.Gender = reader.GetString(7);
                            participant.TShirtSize = reader.GetString(8);
                            participant.RegisterDate = reader.GetDateTime(9);
                        }
                    }
                }
            }

            return participant;
        }
    }
}
