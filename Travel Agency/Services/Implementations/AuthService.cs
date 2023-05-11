using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.RegularExpressions;
using Travel_Agency.Data;
using Travel_Agency.Models.Entities;
using Travel_Agency.Models.In;
using Travel_Agency.Models.Out;

namespace Travel_Agency.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly DatabaseContext _databaseContext;

        public AuthService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<dynamic> Login(UserAuthInfoIn request) {
            try {
                if (string.IsNullOrEmpty(request.Username)) throw new Exception("Username is missing.");
                if (string.IsNullOrEmpty(request.Password)) throw new Exception("Password is missing.");
                var user = await _databaseContext.UsersAuthInfo.Where(user => user.Username.Equals(request.Username)).Include(role => role.Role).Include(user => user.User).FirstOrDefaultAsync();
                if (user == null) throw new Exception("User not found.");
                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password)) throw new Exception("Incorrect password.");
                return user;
            } catch (Exception ex) {
                return ex.Message;
            }
        }

        public async Task<dynamic> Register(UserIn request) { 
            try {
                var firstNameRegex = new Regex(@"^[a-z]*[A-Z][a-z]*$");
                var lastNameRegex = new Regex(@"^[a-z]*[A-Z][a-z]*$");
                var emailRegex = new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$");
                var passwordRegex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*]).{8,}$");
                var cityRegex = new Regex(@"^[A-Z][a-z]+(?:[ ][A-Z][a-z]+)*$");
                var homeAddressRegex = new Regex(@"^[A-Z][\p{L}\d\s.,-]*$");
                var phoneNumberRegex = new Regex(@"^(\+?\d{1,3}\s)?\(?(\d{3})\)?[-.\s]?(\d{3})[-.\s]?(\d{3,4})$");
                var roleRegex = new Regex("^[A-Z][a-z]+$");

                if (request == null) throw new Exception("User in request does not exists.");
                if (string.IsNullOrEmpty(request.FirstName)) throw new Exception("Firstname is missing.");
                if (string.IsNullOrEmpty(request.LastName)) throw new Exception("Lastname is missing.");
                if (string.IsNullOrEmpty(request.Email)) throw new Exception("Email is missing.");
                if (string.IsNullOrEmpty(request.Password)) throw new Exception("Password is missing.");
                if (string.IsNullOrEmpty(request.Address)) throw new Exception("Address is missing.");
                if (string.IsNullOrEmpty(request.City)) throw new Exception("City is missing.");
                if (string.IsNullOrEmpty(request.PhoneNumber)) throw new Exception("Phone number is missing.");
                if (string.IsNullOrEmpty(request.Role)) throw new Exception("Role is missing.");
                if (!firstNameRegex.IsMatch(request.FirstName)) throw new Exception("First name is not valid. Example of valid first name: John");
                if (!lastNameRegex.IsMatch(request.LastName)) throw new Exception("Last name is not valid. Example of valid last name: Smith");
                if (!emailRegex.IsMatch(request.Email)) throw new Exception("Email address is not valid. Example of valid email address: johnsmith@gmail.com");
                if (!passwordRegex.IsMatch(request.Password)) throw new Exception("Password is not valid. The password should consist of at least 8 letters, al least one capital letter, one number and one special character. Example: Abcdefg1*");
                if (!cityRegex.IsMatch(request.City)) throw new Exception("City name is not valid. Example of valid city name: New York");
                if (!homeAddressRegex.IsMatch(request.Address)) throw new Exception("Home address is not valid. Example of valid home address: Address bb");
                if (!phoneNumberRegex.IsMatch(request.PhoneNumber)) throw new Exception("Phone number is not valid. Example of valid phone numbers: +1 (123) 456-7890, 555-555-1234, +44 1234567890, 123-456-789");
                if (!request.Role.Equals("User")) throw new Exception("User role is not valid. Example of valid role: User");
                if (!roleRegex.IsMatch(request.Role)) throw new Exception("User role is not valid. Example of valid role: User");

                var roles = await _databaseContext.Roles.ToListAsync();
                if (roles == null) return null;

                User user = new User {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Address = request.Address,
                    City = request.City,
                    PhoneNumber = request.PhoneNumber,
                };

                _databaseContext.Users.Add(user);

                UserAuthInfo userAuthInfo = new UserAuthInfo {
                    Username = request.FirstName.ToLower() + "_" + request.LastName.ToLower(),
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    Role = roles.Where(r => r.Name.Equals(request.Role)).FirstOrDefault(),
                    User = user,
                };

                _databaseContext.UsersAuthInfo.Add(userAuthInfo);
                await _databaseContext.SaveChangesAsync();

                UserOut userOut = new UserOut(
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    userAuthInfo.Password,
                    user.Address,
                    user.City,
                    user.PhoneNumber,
                    userAuthInfo.Role.Name
                );
                return userOut;
            } catch (Exception ex) {
                return ex.Message;
            }
        }
    }
}
