using System.ComponentModel.DataAnnotations;

namespace Travel_Agency.Models.Out {
    public record UserOut {

        public UserOut(int id, string firstName, string lastName, string email, string password, string address, string city, string phoneNumber, string role)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.Address = address;
            this.City = city;
            this.PhoneNumber = phoneNumber;
            this.Role = role;
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
