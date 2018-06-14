using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public class CategoriesController : ApiController
    {
        // GET: api/Categories
        public IEnumerable<string> Get()
        {
            var context = new Db.Model1Container();
            return context.Categories.Select(f => f.Name).ToList();
        }
    }
}
