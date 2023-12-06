using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaReservaLibros.Models;
using SistemaReservaLibros.ServiceReference1;

namespace SistemaReservaLibros.Controllers
{
    public class AccessController : Controller
    {

        // GET: Access
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users oUser)
        {
            var user = new ServiceReference1.User();
            user.email = oUser.email;
            user.password = oUser.password;
            
            SistemaReservaLibros.ServiceReference1.Service1Client obj = new Service1Client();
            string result = obj.ValidateUser(user);
            oUser.idUser = Convert.ToInt32(result);

            if (oUser.idUser != 0)
            {
                Session["usuario"] = oUser;
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }
        }

    }
}