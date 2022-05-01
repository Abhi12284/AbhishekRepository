using Newtonsoft.Json;
using System;
using System.IO;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string m)
        {
            ViewBag.result = m;
            return View();
        }
        [HttpPost]
        public ActionResult Submit(string firstName, string lastName)
        {
            try
            {
                ModelState.Clear();
                string message = string.Empty;
                CustomerName objName = new CustomerName();
                objName.FirstName = firstName;
                objName.LastName = lastName;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                var json = JsonConvert.SerializeObject(objName, Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(path + "\\test.txt"))
                {
                    writer.Write(json);
                }
                message = "Record Saved Successfully";
                return RedirectToAction("Index","Home",new { m=message});
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}