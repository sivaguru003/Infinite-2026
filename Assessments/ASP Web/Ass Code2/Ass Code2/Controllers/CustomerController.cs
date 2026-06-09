using System.Web.Http;
using NorthwindAPI.Models;

namespace NorthwindAPI.Controllers
{
    public class CustomerController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        [HttpGet]
        [Route("api/customer/country/{country}")]
        public IHttpActionResult GetCustomerByCountry(string country)
        {
            var customers = db.GetCustomersByCountry(country);

            return Ok(customers);
        }
    }
}