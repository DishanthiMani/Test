using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.CSharp
{
    class Program
    {
        //MAIN PROGRAM
        static void Main(string[] args)
        {
            bool logLoop = true;
            while (logLoop == true)
            {
                try
                {
                    Console.WriteLine("Welcome to Aspire Library Management System");
                    Console.WriteLine("1) Press 1 to login as Admin\n" +
                    "2) Press 2 to login as User\n" +
                    "3) Press 3 to exit");

                    int logCase = int.Parse(Console.ReadLine());
                    switch (logCase)
                    {
                        case 1:
                            AdminBL adminPL = new AdminBL();
                            adminPL.AdminLogin();
                            break;
                        case 2:
                            UserBL userPL = new UserBL();
                            userPL.UserLogin();
                            break;
                        case 3:
                            logLoop = false;
                            break;
                        default:
                            Console.WriteLine("Enter a valid input...");
                            break;
                    }
                }
                catch (FormatException)
                {
                    logLoop = true;
                    Console.WriteLine("Try again...");
                }
            }
        }
    }
}
