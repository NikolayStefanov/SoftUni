﻿using SharedTrip.Data;
using SharedTrip.Data.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = ComputeHash(password),
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var pass = ComputeHash(password);
            var targetUserId = this.db.Users
                .Where(x => x.Username.ToLower() == username.ToLower() && x.Password == pass)
                .Select(x => x.Id)
                .FirstOrDefault();
            return targetUserId;
        }

        public bool IsEmailAvailable(string email)
        {
            return this.db.Users.All(x => x.Email.ToLower() != email.ToLower());
        }

        public bool IsUsernameAvailable(string username)
        {
            return this.db.Users.All(x => x.Username.ToLower() != username.ToLower());
        }
        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }
    }
}
