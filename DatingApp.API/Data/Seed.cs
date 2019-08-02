using Newtonsoft.Json;
using DatingApp.API.Models;
using System.Collections.Generic;


namespace DatingApp.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
            
        }

        public void SeedUsers(){
            var userData = System.IO.File.ReadAllText("Data/UserSeedData.Json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);

            foreach(var user in users){
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);
                user.Username = user.Username.ToLower();
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                _context.Users.Add(user);    
            }
            _context.SaveChanges();
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                //Sets the password salt
                passwordSalt = hmac.Key;
                //Creates a hash of the password for non readable strongly encrypted field valye
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }


        }
    }
}