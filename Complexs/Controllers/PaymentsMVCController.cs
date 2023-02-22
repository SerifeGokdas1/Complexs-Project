using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Complexs.Models;

namespace Complexs.Controllers
{
    public class PaymentsMVCController : Controller
    {
        // GET: PaymentsMVC
        public ActionResult Index()
        {
            IEnumerable<PaymentsModel> calList;
            HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("Payments").Result;
            calList = response.Content.ReadAsAsync<IEnumerable<PaymentsModel>>().Result;
            return View(calList);
            //return View();
        }
        public ActionResult ADD(int id = 0)
        {
            if (id == 0)
            {

                return View(new PaymentsModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("Payments/" + id.ToString()).Result; //Buradaki Sites Apideki controllerdan geliyor.
                return View(response.Content.ReadAsAsync<PaymentsModel>().Result);

            }
        }
        [HttpPost]
        public ActionResult ADD(PaymentsModel payment)
        {
            if (payment.PaymentId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PostAsJsonAsync("Payments", payment).Result;
                TempData["SuccessMessage"] = "Payment information saved successfully.";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PutAsJsonAsync("Payments/" + payment.PaymentId, payment).Result;
                TempData["SuccessMessage"] = "Payment information has been successfully updated.";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WepApiClient.DeleteAsync("Payments/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Payment information deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}