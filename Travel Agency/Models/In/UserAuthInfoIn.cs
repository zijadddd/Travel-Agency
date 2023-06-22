namespace Travel_Agency.Models.In
{
    public record UserAuthInfoIn
    {
        public UserAuthInfoIn(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get; init; }
        public string Password { get; init; }
    }
}
