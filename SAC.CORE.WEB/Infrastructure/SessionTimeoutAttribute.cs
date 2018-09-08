//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SAC.CORE.WEB.Infrastructure
{
    public class SessionTimeoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //HttpContext ctx = HttpContext.Current;
            //if (HttpContext.Current.Session["userId"] == null)
            //{
            //    filterContext.Result = new RedirectResult("~/User/Login");
            //    return;
            //}
            if (filterContext.HttpContext.Session.GetString("UltimoRegistro") == null)
            {
                filterContext.Result = new RedirectResult("~/Register/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }

        //public void OnActionExecuted(ActionExecutedContext context)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public void OnActionExecuting(ActionExecutingContext context)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}