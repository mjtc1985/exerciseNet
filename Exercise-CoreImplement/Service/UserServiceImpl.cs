using Exercise_CoreInterface.Service;
using System.Collections.Generic;
using Exercise_CoreInterface.Model;
using Exercise_CoreData.Repository;

namespace Exercise_CoreImplement.Service 
{
    public class UserServiceImpl : UserService
    {
        private UserRepository _userRepository { get; set; }

        public UserServiceImpl(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public User createUser(User user)
        {
            return this._userRepository.createUser(user);
        }

        public IEnumerable<User> getAllUsers()
        {
            return this._userRepository.getAllUsers();
        }

        public User getUser(int id)
        {
            return this._userRepository.getUser(id);
        }

        public void removeUser(int id)
        {
            this._userRepository.removeUser(id);
        }

        public User updateUser(User user)
        {
            return this._userRepository.updateUser(user);
        }
    }
}
