using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Task = Domain.Task;

namespace Repo
{
    public class UserRepository : IUserRepository
    {
        WebApiEntities entity = new WebApiEntities();
        public TaskManagementContext context;

        public UserRepository(TaskManagementContext context)
        {
            this.context = context;
        }
       public void Create(User aUser)
        {
            User newUser = new User();
            newUser.Username = aUser.Username;
            newUser.Email = aUser.Email;
            newUser.Password = aUser.Password;
            entity.User.Add(newUser);
            entity.SaveChanges();

        }
        public IEnumerable<User> GetAll()
        {
            using(var context = this.context)
            {
                //List<User> list = userrepo.GetAll;
                //UserContext userContext
                List<User> p = context.Users.ToList();
                List<User> list = entity.User.ToList();
                //List<User> list = context.User.ToList();
                
                //return p;
                return list;          
            }
            
        }
        
        public void Update(User aUser)
        {
            User currentUser = entity.User.Where(a=> a.Username == aUser.Username).FirstOrDefault();
            if(currentUser != null)
            {
                currentUser.Username = aUser.Username;
                currentUser.Email = aUser.Email;
                currentUser.Password = aUser.Password;
                entity.SaveChanges();
            }
        }
        public void Delete(User aUser)
        {
            User currentUser = entity.User.Where(a => a.Username == aUser.Username).FirstOrDefault();
            if(currentUser != null)
            {
                entity.User.Remove(currentUser);
                entity.SaveChanges();
            }
        }

    }
}
