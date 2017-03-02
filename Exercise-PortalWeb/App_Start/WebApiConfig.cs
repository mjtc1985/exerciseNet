using exercise.Resolver;
using Exercise_CoreData.Context;
using Exercise_CoreData.Repository;
using Exercise_CoreData.Repository.Impl;
using Exercise_CoreImplement.Service;
using Exercise_CoreInterface.Service;
using Microsoft.Practices.Unity;
using System.Net.Http.Headers;
using System.Data.Entity;
using System.Web.Http;
using Exercise_CoreInterface.Model;
using System.Web.Http.ExceptionHandling;
using exercise.Filters;

namespace exercise
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var userRepositoryType = typeof(UserRepository);
            var dbContextType = typeof(DbContext);

            // Web API configuration and services 
            UnityContainer container = new UnityContainer();
            container.RegisterType<UserService, UserServiceImpl>(new InjectionConstructor(userRepositoryType));
            container.RegisterType<UserRepository, UserRepositoryImpl>(new InjectionConstructor(new RepositoryContext()));
            
            //DbContext injection
            container.RegisterType<DbContext, RepositoryContext>(new PerThreadLifetimeManager());

            //Exception handler
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            //Unity
            config.DependencyResolver = new UnityResolver(container);
                
            // Web API routes 
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes
            .Add(new MediaTypeHeaderValue("text/html"));

            AddTestData(container.Resolve<DbContext>());
        }

        /// <summary>
        /// Private method for seed database when the application starts
        /// </summary>
        /// <param name="context"></param>
        private static void AddTestData(DbContext dbContext)
        {
            RepositoryContext context = (RepositoryContext)dbContext;
            var testUser1 = new User
            {
                Id = 1,
                Name = "Manuel",
                Birthdate = new System.DateTime(1985, 9, 10)
            };

            context.Users.Add(testUser1);

            var testUser2 = new User
            {
                Id = 1,
                Name = "Antonio",
                Birthdate = new System.DateTime(1982, 5, 1)
            };

            context.Users.Add(testUser2);

            var testUser3 = new User
            {
                Id = 1,
                Name = "Luis",
                Birthdate = new System.DateTime(1990, 3, 20)
            };

            context.Users.Add(testUser3);

            context.SaveChanges();
        }
    }
}
