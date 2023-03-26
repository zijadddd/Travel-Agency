using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<UserOut> Register(UserRegIn request)
        {
            if (request == null) return null;
            var role = _databaseContext.Roles.Where(r => r.Name.Equals(request.Role)).FirstOrDefault();
            if (role == null) return null;

            User user = new User {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                Address = request.Address,
                City = request.City,
                PhoneNumber = request.PhoneNumber,
                Role = role
            };
            _databaseContext.Users.Add(user);
            await _databaseContext.SaveChangesAsync();

            UserOut userOut = new UserOut {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Address = user.Address,
                City = user.City,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role.Name
            };
            return userOut;
        }
    }
}
