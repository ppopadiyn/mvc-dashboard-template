using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Dashboard.Mvc5
{
    public static class HtmlHelpers
    {
        public static string IsActive(this HtmlHelper helper, string controller, string actions = "")
        {
            string classValue = "active";
            ViewContext viewContext = helper.ViewContext;

            string currentController = viewContext.RouteData.Values["controller"].ToString();
            string currentAction = viewContext.RouteData.Values["action"].ToString();

            if (string.IsNullOrEmpty(actions))
            {
                actions = currentAction;
            }

            List<string> acceptedActions = actions.Trim().Split(',').Distinct().ToList();
            List<string> acceptedController = controller.Trim().Split(',').Distinct().ToList();

            bool actionRequirementsMet = acceptedActions.FirstOrDefault(x => x.Equals(currentAction, StringComparison.CurrentCultureIgnoreCase)) != null;
            bool controllerRequirementsMet = acceptedController.FirstOrDefault(x => x.Equals(currentController, StringComparison.CurrentCultureIgnoreCase)) != null;

            return actionRequirementsMet && controllerRequirementsMet ? classValue : string.Empty;
        }
    }
}