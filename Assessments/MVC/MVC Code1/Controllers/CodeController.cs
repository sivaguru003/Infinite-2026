using System.Linq;
using System.Web.Mvc;
using MVC.Models;  
public class CodeController : Controller
{
    NorthwindEntities db = new NorthwindEntities();

     public ActionResult GermanyCustomers()
    {
        var customers = db.Customers
                          .Where(c => c.Country == "Germany")
                          .ToList();

        return View(customers);
    }

     public ActionResult OrderCustomer()
    {
        var customer = db.Orders
                         .Where(o => o.OrderID == 10248)
                         .Select(o => o.Customer)
                         .FirstOrDefault();

        return View(customer);
    }
}