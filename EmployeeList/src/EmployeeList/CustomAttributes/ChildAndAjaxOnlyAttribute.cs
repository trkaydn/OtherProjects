using System.Web.Mvc;

namespace EmployeeListUI.CustomAttributes
{
	public class ChildAndAjaxOnlyAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (!filterContext.HttpContext.Request.IsAjaxRequest() && !filterContext.IsChildAction)
				filterContext.HttpContext.Response.Redirect("/Error/Index");
		}
	}
}