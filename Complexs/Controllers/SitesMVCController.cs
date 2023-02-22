using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Complexs.Models;


namespace Complexs.Controllers
{
    public class SitesMVCController : Controller
    {
        // GET: SitesMVC
        public ActionResult Index()
        {
            IEnumerable<SitesModel> calList;
            HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("Sites").Result;
            calList = response.Content.ReadAsAsync<IEnumerable<SitesModel>>().Result;
            return View(calList);
            //return View();
        }
        public ActionResult ADD(int id = 0)
        {
            if (id == 0)
            {

                return View(new SitesModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("Sites/" + id.ToString()).Result; //Buradaki Sites Apideki controllerdan geliyor.
                return View(response.Content.ReadAsAsync<SitesModel>().Result);

            }
        }
        [HttpPost]
        public ActionResult ADD(SitesModel site)
        {
            if (site.SiteId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PostAsJsonAsync("Sites", site).Result;
                TempData["SuccessMessage"] = "Site information saved successfully.";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PutAsJsonAsync("Sites/" + site.SiteId, site).Result;
                TempData["SuccessMessage"] = "Site information has been successfully updated.";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WepApiClient.DeleteAsync("Sites/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Site information deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
