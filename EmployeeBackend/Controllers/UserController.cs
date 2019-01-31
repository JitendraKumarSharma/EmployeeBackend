using EmployeeBackend.BAL;
using EmployeeBackend.Models;
using EmployeeBackend.ValidationFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeBackend.Controllers
{
    [Authorize]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        User_BAL objUserBal = new User_BAL();

        [AllowAnonymous]
        [HttpPost]
        [Route("saveuser")]
        [ValidateRegistration]
        public HttpResponseMessage SaveUser(User _usr)
        {
            try
            {
                int k = 0;
                int c = 10 / k;
                int id = objUserBal.Save_Update_User(_usr);
                if (id > 0)
                {
                    var message = Request.CreateResponse(HttpStatusCode.Created, id);
                    return message;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.MultipleChoices, "User already exists");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
