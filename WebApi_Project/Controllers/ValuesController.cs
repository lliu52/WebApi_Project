using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;
using Repo;

namespace WebApi_Project.Controllers
{
    public class ValuesController : ApiController
    {
        private IUserRepository userRepository;
        public ValuesController()
        {
            this.userRepository = new UserRepository(new TaskManagementContext());
        }

        public ValuesController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        //[HttpPost]
        [Route("api/value/create")]
        public IHttpActionResult CreateUsers(User aUser)
        {
            userRepository.Create(aUser);
            return Ok();
        }
        [Route("api/value/read")]
        public IHttpActionResult GetAllUsers()
        {
            
            //var temp = userRepository.GetAll();
            //List<User> list = userrepo.GetAll;
            //Domain.WebApiEntities e = new Domain.WebApiEntities();
            //List<User> users = e.User.ToList();
            //List<User> l = 
            return Ok(userRepository.GetAll());
        }

        //[HttpPost]
        //[Authorize]
        [Route("api/value/update")]
        public IHttpActionResult UpdateUser(User aUser)
        {
            userRepository.Update(aUser);
            return Ok();
        }

        [Route("api/value/update1")]
        [HttpPut]
        public HttpResponseMessage UpdateUser1(User aUser)
        {
            userRepository.Update(aUser);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("api/value/delete")]
        public IHttpActionResult DeleteUser(User aUser)
        {
            userRepository.Delete(aUser);
            return Ok();
        }
        
    }
}
