namespace Travel_Agency.Models.Entities {
    public class UserAuthInfo {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
