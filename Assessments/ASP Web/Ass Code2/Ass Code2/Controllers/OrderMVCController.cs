using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVCClient.Models;

namespace MVCClient.Controllers
{
    public class OrderMVCController : Controller
    {
        string apiUrl =
        "https://localhost:44300/api/orders/employee5";

        public async Task<ActionResult> Index()
        {
            List<OrderModel> orders = new List<OrderModel>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response =
                    await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string data =
                        await response.Content.ReadAsStringAsync();

                    orders =
                    JsonConvert.DeserializeObject<List<OrderModel>>(data);
                }
            }

            return View(orders);
        }
    }
}