using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeBackend.DAL
{
    public class Employee_DAL
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public Employee_DAL()
        {
            cmd = new SqlCommand();
            sda = new SqlDataAdapter();
            dt = new DataTable();
        }

        
    }
}