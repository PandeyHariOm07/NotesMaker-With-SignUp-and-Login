using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NotesMaker;
using NotesMaker.Interfaces;
using WebApp.Models;

namespace WebApp.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        private readonly IUser _user = null;
        public LoginController()
        {
            _user = new UserAuthentication();
        }

        [HttpPost]
        public IHttpActionResult SignUp([FromBody]SignUpModel signUp)
        {
            var res = _user.SignUp(signUp.email_id, signUp.name, signUp.password);
            if (res == 0) return BadRequest();
            return Ok();
        }

        [HttpGet]
        [Route("LoginUser")]
        public IHttpActionResult LoginUser(string email, string password)
        {
            var res = _user.LoginUser(email, password);
            if(res.Count() == 0) return BadRequest();  
            return Ok();
        }
    }
}
