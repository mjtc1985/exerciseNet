using System.Collections.Generic;
using System.Linq;
using Exercise_CoreInterface.Model;
using Exercise_CoreData.Context;

namespace Exercise_CoreData.Repository.Impl
{
    public class UserRepositoryImpl : UserRepository
    {
        private readonly RepositoryContext _context;

        public UserRepositoryImpl(RepositoryContext context)
        {
            this._context = context;
        }

        public User createUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public IEnumerable<User> getAllUsers()
        {
            return _context.Users.ToList();
        }

        public User getUser(int id)
        {
            User user = _context.Users.SingleOrDefault(u => u.Id == id);
            return user;
        }

        public void removeUser(int id)
        {
            User userToRemove = _context.Users.Find(id);
            if(userToRemove != null)
            {
                _context.Users.Remove(userToRemove);
                _context.SaveChanges();
            }
        }

        public User updateUser(User user)
        {
            User userToUpdate = _context.Users.SingleOrDefault(u => u.Id == user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.Name = user.Name;
                userToUpdate.Birthdate = user.Birthdate;
                _context.SaveChanges();
            }

            return userToUpdate;
        }
    }
}
