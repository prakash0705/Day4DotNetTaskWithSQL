using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskDay4.Models;

namespace TaskDay4.Repository
{
    class UserRepository : User, IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository()
        {
            _db = new ApplicationDbContext();
        }

        public List<User> ActiveUsers()
        {
            var activeUsers = _db.Users.Where(a=>a.IsActive==true).ToList();
            return activeUsers;
        }

        public List<User> AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return _db.Users.ToList();
        }

        public List<User> DeleteUser(int id)
        {
            var deleteUser = _db.Users.Where(a => a.Id == id).FirstOrDefault();
            if(deleteUser==null)
            {
                Console.WriteLine("No User found at id: " + id);
            }
            else
            {
                _db.Users.Remove(deleteUser);
                _db.SaveChanges();
                Console.WriteLine("User deleted successfull");

            }
            return _db.Users.ToList();
        }

        public User GetUser(int id)
        {
            var user = _db.Users.Where(a => a.Id == id).FirstOrDefault();
            return user;
        }

        public List<User> Users()
        {
            var users = _db.Users.ToList();
            return users;
        }
    }
}
