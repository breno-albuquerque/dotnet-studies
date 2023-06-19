namespace SqlDataAccess.Models
{
    internal class Role
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        public DateTime DateInsertion { get; set; }

        public DateTime DateAlteration { get; set; }

        public List<User> Users { get; set; }

        public Role()
        {
            Users = new List<User>();
        }
    }
}
