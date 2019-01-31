using EmployeeBackend.DAL;
using EmployeeBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeBackend.BAL
{
    public class User_BAL
    {
        User_DAL objUserDal = new User_DAL();
        public int Save_Update_User(User _usr)
        {
            return objUserDal.Save_Update_User(_usr);
        }
    }
}