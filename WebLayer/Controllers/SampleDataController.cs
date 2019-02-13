using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace WebLayer.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public async Task<IEnumerable<WeatherForecast>> WeatherForecasts()
        {
            #region Login - Claims Cookie Authentication
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "akshay.raut@gmail.com"),
                new Claim("FullName", "Akshay Raut"),
                new Claim(ClaimTypes.Role, "Administrator"),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            #endregion

            #region Logout - Claims Cookie Authentication
            // await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            #endregion

            #region Session service - Authentication
                // HttpContext.Session.SetString("name", "akshay");
            #endregion
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public IActionResult TestQueryApi()
        {

            // return Ok(HttpContext.Session.GetString("name"));
            // Approach 1
            QueryController qc = new QueryController();
            return Ok(qc.GetQuery());

            // Approach 2
            // var request = HttpWebRequest.Create("http://" + Request.Host.Value + "/api/query/");
            // request.Method = "GET";
            // request.ContentType = "application/json";
            // var response = request.GetResponse() as HttpWebResponse;
            // // var data = new byte[response.ContentLength];
            // using (var stream = response.GetResponseStream())
            // {
            //     StreamReader sr = new StreamReader(stream);
            //     Query q = JsonConvert.DeserializeObject<Query>(sr.ReadToEnd());
            //     q.IsApiWorking = true;
            //     return Ok(q);
            // }

        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }

        public class Query
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public bool IsApiWorking { get; set; }
        }
    }
}
