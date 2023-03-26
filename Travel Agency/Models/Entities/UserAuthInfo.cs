namespace Travel_Agency.Models.Entities {
    public class UserAuthInfo {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
