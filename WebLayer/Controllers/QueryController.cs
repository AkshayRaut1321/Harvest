using Microsoft.AspNetCore.Mvc;
using Query.DAL;

namespace WebLayer.Controllers
{
    [Route("/api/[controller]")]
    public class QueryController : Controller
    {
        [HttpGet]
        public Query GetQuery()
        {
            Class1 c = new Class1();
            c.Log("hello world");

            Query q = new Query();
            q.ID = 20;
            q.Name = "New query";
            return q;
        }
        
        [HttpPost]
        public IActionResult Save([FromBody] Query q)
        {
            return Ok(q);
        }
    }

    public class Query
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}