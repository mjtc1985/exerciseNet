using Exercise_CoreInterface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_CoreInterface.Service
{
    public interface UserService
    {
        /// <summary>
        /// <p>Return a list of users existing in system</p>
        /// </summary>
        /// <returns>list of users</returns>
        IEnumerable<User> getAllUsers();

        /// <summary>
        /// <p>Return user with id is equal than id parameter</p>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>user</returns>
        User getUser(int id);

        /// <summary>
        /// <p>Create in database an user</p>
        /// </summary>
        /// <param name="user"></param>
        /// <returns>the created user</returns>
        User createUser(User user);

        /// <summary>
        /// <p>Modifiy an user</p>
        /// </summary>
        /// <param name="user"></param>
        /// <returns>the modified user</returns>
        User updateUser(User user);

        /// <summary>
        /// <p>Remove an user</p>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void removeUser(int id);
    }
}
