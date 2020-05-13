using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelpDesk.WebAPI.Controllers
{
    using KPI.Library.Services;

    public class UsersController : ApiController
    {

        private KPI.Library.Services.ERPUserService service;

        // GET api/<controller>

        public UsersController()
        {
            this.service = new ERPUserService();
        }
        public IEnumerable<KPI.Library.Models.User> Get()
        {
            return null;
        }

        // GET api/<controller>/5
        public string Get(string id)
        {
            return "value";
        }

        // // POST api/<controller>
        // public void Post([FromBody]string value)
        // {
        // }
        //
        // // PUT api/<controller>/5
        // public void Put(int id, [FromBody]string value)
        // {
        // }
        //
        // // DELETE api/<controller>/5
        // public void Delete(int id)
        // {
        // }
    }
}