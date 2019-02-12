using Microsoft.AspNetCore.Mvc;

namespace WebLayer.Controllers
{
    [Route("/api/[controller]")]
    public class QueryController : Controller
    {
        [HttpGet]
        public Query GetQuery()
        {
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