using Git.Data;
using Git.ViewModels.Users;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Git.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void CreateUser(RegisterInputModel inputModel)
        {
            var newUser = new User
            {
                Username = inputModel.Username,
                Email = inputModel.Email,
                Password = ComputeHash(inputModel.Password),
            };
            this.db.Add(newUser);
            this.db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var hashedPass = ComputeHash(password);
            var userId = this.db.Users
                .Where(x => x.Username == username && x.Password == hashedPass)
                .Select(x => x.Id)
                .FirstOrDefault();
            return userId;
        }

        public bool IsEmailAvailable(string email)
        {
            return this.db.Users.All(u => u.Email != email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return this.db.Users.All(u => u.Username != username);
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
