using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Complexs.Models;

namespace Complexs.Controllers
{
    public class CustomersMVCController : Controller
    {
        // GET: CustomersMVC
        public ActionResult Index()
        {
            IEnumerable<CustomersModel> calList;
            HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("Customers").Result;
            calList = response.Content.ReadAsAsync<IEnumerable<CustomersModel>>().Result;
            return View(calList);
            //return View();
        }
        public ActionResult ADD(int id = 0)
        {
            if (id == 0)
            {

                return View(new CustomersModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("Customers/" + id.ToString()).Result; //Buradaki Sites Apideki controllerdan geliyor.
                return View(response.Content.ReadAsAsync<CustomersModel>().Result);

            }
        }
        [HttpPost]
        public ActionResult ADD(CustomersModel customers)
        {
            if (customers.CustomerId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PostAsJsonAsync("Customers", customers).Result;
                TempData["SuccessMessage"] = "Customer information saved successfully.";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PutAsJsonAsync("Customers/" + customers.CustomerId, customers).Result;
                TempData["SuccessMessage"] = "Customer information has been successfully updated.";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WepApiClient.DeleteAsync("Customers/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Customer information deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}