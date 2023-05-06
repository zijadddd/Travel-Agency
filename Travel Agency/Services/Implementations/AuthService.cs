﻿using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Data;
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

        public async Task<UserAuthInfo> Login(UserAuthInfoIn request) {
            var user = await _databaseContext.UsersAuthInfo.Where(user => user.Username.Equals(request.Username)).Include(role => role.Role).Include(user => user.User).FirstOrDefaultAsync();
            if (user == null) return null;
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password)) return null;
            return user;
        }

        public async Task<UserOut> Register(UserIn request)
        {
            if (request == null) return null;
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
        }
    }
}
