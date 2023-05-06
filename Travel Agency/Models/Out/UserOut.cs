using System.ComponentModel.DataAnnotations;

namespace Travel_Agency.Models.Out {
    public record UserOut {

        public UserOut(int id, string firstName, string lastName, string email, string password, string address, string city, string phoneNumber, string role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Address = address;
            City = city;
            PhoneNumber = phoneNumber;
            Role = role;
        }

        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; } 
        public string Address { get; init; } 
        public string City { get; init; } 
        public string PhoneNumber { get; init; } 
        public string Role { get; init; }
    }
}
