using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public class FactoriesController : ApiController
    {
        // GET: api/Factories
        public IEnumerable<string> Get()
        {
            var context = new Db.Model1Container();
            return context.Factories.Select(f => f.Name).ToList();
        }
        
    }
}
