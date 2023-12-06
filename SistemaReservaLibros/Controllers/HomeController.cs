using Newtonsoft.Json;
using SistemaReservaLibros.Permisos;
using SistemaReservaLibros.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaReservaLibros.Models;

namespace SistemaReservaLibros.Controllers
{
    [ValidateSession]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SistemaReservaLibros.ServiceReference1.Service1Client obj = new Service1Client();
            string result = obj.ListBooks();

            List<Books> listBooks = JsonConvert.DeserializeObject<List<Books>>(result);

            return View(listBooks);
        }

        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            SistemaReservaLibros.ServiceReference1.Service1Client obj = new Service1Client();
            string result = obj.SearchBook(searchTerm);

            List<Books> listBooks = JsonConvert.DeserializeObject<List<Books>>(result);

            return View(listBooks);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Logout()
        {
            Session["usuario"] = null;
            return RedirectToAction("Login", "Access");
        }

    }
}