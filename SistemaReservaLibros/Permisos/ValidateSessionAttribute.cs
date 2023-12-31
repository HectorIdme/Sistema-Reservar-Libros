﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaReservaLibros.Permisos
{
    public class ValidateSessionAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["usuario"] == null)
            {
                filterContext.Result = new RedirectResult("~/Access/Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}