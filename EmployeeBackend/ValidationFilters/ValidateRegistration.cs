using EmployeeBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EmployeeBackend.ValidationFilters
{
    public class ValidateRegistration : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var Values = actionContext.ActionArguments.Values;
            int UserId = 0;
            string UserName = string.Empty;
            string Email_Id = string.Empty;
            int RoleId = 0;
            string Password = string.Empty;
            string Error = string.Empty;
            string Action = string.Empty;

            bool hasValue = false;

            foreach (User i in Values)
            {
                if (i != null)
                {
                    UserId = i.UserId;
                    UserName = i.UserName;
                    Email_Id = i.Email_Id;
                    RoleId = i.RoleId;
                    Password = i.Password;
                    Action = i.Action;
                    hasValue = true;
                }
            }
            if (hasValue == true)
            {
                if (Action != null && Action == "update")
                {
                    if (UserId == 0)
                    {
                        Error = Error + "Enter User Id. ";
                    }
                }
                if (Action != null && (Action == "update" || Action == "add"))
                {
                    if (UserName == null || UserName == "")
                    {
                        Error = Error + "Enter User Name. ";
                    }
                    if (Email_Id == null || Email_Id == "")
                    {
                        Error = Error + "Enter Email_Id. ";
                    }
                    if (RoleId == 0)
                    {
                        Error = Error + "Select Role Id. ";
                    }
                    if (Password == null || Password == "")
                    {
                        Error = Error + "Enter Password. ";
                    }
                }
                if (Error != "")
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest, Error);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest, "Enter all the required fields");
            }

        }
    }
}