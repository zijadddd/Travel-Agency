namespace Travel_Agency.Models.In
{
    public record UserIn
    {
        public UserIn(string firstName, string lastName, string email, string password, string city, string address, string phoneNumber, string role)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.City = city;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Role = role;
        }

        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string City { get; init; }
        public string Address { get; init; }
        public string PhoneNumber { get; init; }
        public string Role { get; init; }
    }
}
