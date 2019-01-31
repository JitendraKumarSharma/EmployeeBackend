using EmployeeBackend.GlobalFiles;
using EmployeeBackend.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeBackend.DAL
{
    public class User_DAL
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public User_DAL()
        {
            cmd = new SqlCommand();
            sda = new SqlDataAdapter();
            dt = new DataTable();
        }
        public DataTable GetLoginDetail(string UserName, string Password)
        {
            try
            {
                cmd = new SqlCommand("GetLoginDetail", cmd.Connection)
                {
                    Connection = DbConnect.CreateConnection(),
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EmailId", UserName);
                sda = new SqlDataAdapter(cmd);
                cmd.Connection.Open();
                sda.Fill(dt);
                cmd.Connection.Close();

                if (dt.Rows.Count > 0)
                {
                    var pwdDB = Convert.ToString(dt.Rows[0]["Password"]);
                    var hashCode = Convert.ToString(dt.Rows[0]["Salt"]);
                    //Password Hasing Process Call Helper Class Method    
                    var encodingPasswordString = EncryptDecrypt.EncodePassword(Password, hashCode);
                    //Check Login Detail User Name Or Password    
                    if (pwdDB.Equals(encodingPasswordString))
                    {
                        return dt;
                    }
                    else
                    {
                        return new DataTable();
                    }
                }
                else
                {
                    return new DataTable();
                }
            }
            catch (Exception ex)
            {
                return dt;
            }
        }

        public int Save_Update_User(User _usr)
        {
            int id = 0;
            try
            {
                var keyNew = EncryptDecrypt.GeneratePassword(10);
                var Password = EncryptDecrypt.EncodePassword(_usr.Password, keyNew);
                cmd = new SqlCommand("AddUpdateUser", cmd.Connection)
                {
                    Connection = DbConnect.CreateConnection(),
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserId", _usr.UserId);
                cmd.Parameters.AddWithValue("@UserName", _usr.UserName);
                cmd.Parameters.AddWithValue("@Email_id", _usr.Email_Id);
                cmd.Parameters.AddWithValue("@RoleId", _usr.RoleId);
                cmd.Parameters.AddWithValue("@password", Password);
                cmd.Parameters.AddWithValue("@Salt", keyNew);
                cmd.Parameters.AddWithValue("@Action", _usr.Action);
                cmd.Connection.Open();
                id = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Connection.Close();
                return id;
            }
            catch (Exception ex)
            {
                return id;
            }
        }
    }
}