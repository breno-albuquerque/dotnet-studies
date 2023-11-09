namespace SqlDataAccess.Models
{
    internal class User
    {
        public int Id { get; set; }

        public Role UserRole { get; set; }

        public string Document { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DateInsertion { get; set; }

        public DateTime DateAlteration { get; set; }
    }
}
