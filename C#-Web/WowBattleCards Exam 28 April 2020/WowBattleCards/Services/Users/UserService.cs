using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WowBattleCards.Data;
using WowBattleCards.Users.ViewModels;

namespace WowBattleCards.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void RegisterUser(UserRegisterViewModel inputModel)
        {
            var pass = ComputeHash(inputModel.Password);
            this.db.Users.Add(new User
            {
                Username = inputModel.Username,
                Email = inputModel.Email,
                Password = pass,
            });
            this.db.SaveChanges();
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

        public bool IsUsernameAvailable(string username) => this.db.Users.All(x => x.Username != username);

        public bool IsEmailAvailable(string email) => this.db.Users.All(x => x.Email != email);

        public string GetUserId(string username, string password)
        {
            var userId = this.db.Users
                .Where(x => x.Username == username && x.Password == ComputeHash(password))
                .Select(x => x.Id).FirstOrDefault();
            return userId;
        }
    }
}
