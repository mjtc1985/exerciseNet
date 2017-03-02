using Exercise_CoreInterface.Model;
using Exercise_CoreInterface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace exercise.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private UserService _userService { get; set; }

        public UserController(UserService userService)
        {
            this._userService = userService;
        }

        /// <summary>
        /// <p>Return a list of users existing in system</p>
        /// </summary>
        /// <returns>list of users</returns>
        [Route("getAll")]
        public IEnumerable<User> getAllUsers()
        {
            return _userService.getAllUsers();
        }

        /// <summary>
        /// <p>Return user with id is equal than id parameter</p>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>user</returns>
        [Route("get/{id:int}")]
        public HttpResponseMessage getUser(int id)
        {
            User userResult = _userService.getUser(id);

            if(User == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ModelState);
            }else
            {
                return new HttpResponseMessage()
                {
                    Content = new ObjectContent<User>(userResult, Configuration.Formatters.JsonFormatter),
                    StatusCode = HttpStatusCode.Created
                };
            }
        }

        /// <summary>
        /// <p>Create in database an user</p>
        /// </summary>
        /// <param name="user"></param>
        /// <returns>the created user</returns>
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage createUser(User user)
        {
            if (ModelState.IsValid)
            {
                User userResult = _userService.createUser(user);
                return new HttpResponseMessage()
                {
                    Content = new ObjectContent<User>(userResult, Configuration.Formatters.JsonFormatter),
                    StatusCode = HttpStatusCode.Created
                };
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        /// <summary>
        /// <p>Modifiy an user</p>
        /// </summary>
        /// <param name="user"></param>
        /// <returns>the modified user</returns>
        [Route("update")]
        [HttpPost]
        public HttpResponseMessage updateUser(User user)
        {
            if (ModelState.IsValid)
            {
                User userResult = _userService.updateUser(user);
                return new HttpResponseMessage()
                {
                    Content = new ObjectContent<User>(userResult, Configuration.Formatters.JsonFormatter),
                    StatusCode = HttpStatusCode.Created
                };
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        /// <summary>
        /// <p>Remove an user</p>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("remove/{id:int}")]
        [HttpGet]
        public void removeUser(int id)
        {
            _userService.removeUser(id);
        }
    }
}
