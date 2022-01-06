using System;
using System.Collections.Generic;
using LibraryMS.DAL;
using LibraryMS.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.BLL
{
    public class AdminBLL
    {
        //CHECKING ADMIN LOGIN CREDENTIALS  =>BLL
        public bool AdminLogin(string adminEmail, string adminPass)
        {
            AdminDAL adminDAL = new AdminDAL();
            List<Admin> admins = adminDAL.GetAllAdminsDAL();
            bool isDone = admins.Exists(a => a.AdminEmail == adminEmail && a.AdminPassword == adminPass);
            if (isDone)
            {
                Console.WriteLine("Logged in successfully...");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Email Id or Password...");
                return false;
            }
        }
    }
}