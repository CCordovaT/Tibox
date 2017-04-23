using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tibox.Mvc.FilterActions
{
    public class ErrorHandler: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            var model = new HandleErrorInfo(
                filterContext.Exception,
                "Controller",
                "Action"
                );
            filterContext.Result = new ViewResult()
            {
                ViewName="Error",
                ViewData= new ViewDataDictionary(model)
            };
        }
    }
}