using System.Linq;
using System.Web.Http;
using WebApiDemo.Models;
namespace WebApiDemo.Controllers
{
    public class CountryController : ApiController
    {
        CountryContext db = new CountryContext();
        [HttpGet]
        public IHttpActionResult GetCountries()
        {
            return Ok(db.Countries.ToList());
        }
        [HttpGet]
        public IHttpActionResult GetCountry(int id)
        {
            var country = db.Countries.Find(id);
            if (country == null)
                return NotFound();
            return Ok(country);
        }
        [HttpPost]
        public IHttpActionResult AddCountry(Country country)
        {
            db.Countries.Add(country);
            db.SaveChanges();
            return Ok("Country Added Successfully");
        }
        [HttpPut]
        public IHttpActionResult UpdateCountry(int id, Country country)
        {
            var c = db.Countries.Find(id);
            if (c == null)
                return NotFound();
            c.CountryName = country.CountryName;
            c.Capital = country.Capital;
            db.SaveChanges();
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        public IHttpActionResult DeleteCountry(int id)
        {
            var c = db.Countries.Find(id);
            if (c == null)
                return NotFound();
            db.Countries.Remove(c);
            db.SaveChanges();
            return Ok("Deleted Successfully");
        }
    }
}