using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Complexs.Models;

namespace Complexs.Controllers
{
    public class DebtsMVCController : Controller
    {
        // GET: DebtsMVC
        public ActionResult Index()
        {
            IEnumerable<DebtsModel> calList;
            HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("Debts").Result;
            calList = response.Content.ReadAsAsync<IEnumerable<DebtsModel>>().Result;
            return View(calList);
            //return View();
        }
        public ActionResult ADD(int id = 0)
        {
            if (id == 0)
            {

                return View(new DebtsModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("Debts/" + id.ToString()).Result; //Buradaki Sites Apideki controllerdan geliyor.
                return View(response.Content.ReadAsAsync<DebtsModel>().Result);

            }
        }
        [HttpPost]
        public ActionResult ADD(DebtsModel debts)
        {
            if (debts.DebtId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PostAsJsonAsync("Debts", debts).Result;
                TempData["SuccessMessage"] = "Debt information saved successfully.";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PutAsJsonAsync("Debts/" + debts.DebtId, debts).Result;
                TempData["SuccessMessage"] = "Debt information has been successfully updated.";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WepApiClient.DeleteAsync("Debts/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Debt information deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}