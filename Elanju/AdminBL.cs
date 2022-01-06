/*
Title : Library Management System
Author : Abitha S
Created at : 01/Jan/2022
Reviewed by : AKSHAYA
Updated at : 04/Jan/2022
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMS.BLL;
using System.Threading.Tasks;

namespace LibraryMS.CSharp
{
    public class AdminBL
    {
        //INDIVIDUAL ADMIN LOGIN CREDENTIAL CHECKING
        public void AdminLogin()
        {
            try
            {
                Console.WriteLine("Admin-Login-----------");
                Console.Write("Email Id: ");
                string adminEmail = Console.ReadLine();
                Console.Write("Password: ");
                string adminPass = Console.ReadLine();
                AdminBLL adminBLL = new AdminBLL();
                bool isDone = adminBLL.AdminLogin(adminEmail, adminPass);
                if (isDone)
                {
                    AdminSection();
                }
                else
                {
                    Console.WriteLine("Try again...");
                }
            }
            catch (LibraryMSException)
            {
                throw new LibraryMSException("Some unknown exception is occured..");
            }
        }


        //ADMIN MENU
        private void GetAdminMenu()
        {
            Console.Write("1) Press 1 to show book section\n" +
                "2) Press 2 to show user section\n" +
                "3) Press 3 to show request section\n" +
                "4) Press 4 to show accepted section\n" +
                "5) Press 5 to ");
            Console.WriteLine("logout");
            Console.WriteLine();
        }

        //ADMIN COMPLETE SECTION

        private void AdminSection()
        {
            Console.WriteLine("Welcome-to-Admin-Section--------------");
            bool adminLoop = true;
            while (adminLoop == true)
            {
                try
                {
                    GetAdminMenu();
                    int adminCase = int.Parse(Console.ReadLine());
                    switch (adminCase)
                    {
                        case 1:
                            BookBL bookSection = new BookBL();
                            bookSection.BookSection();
                            break;
                        case 2:
                            UserBL userSection = new UserBL();
                            userSection.UserSection();
                            break;
                        case 3:
                            RequestedSection();
                            break;
                        case 4:
                            RecievedSection();
                            break;
                        case 5:
                            Console.WriteLine("Logged out successfully..\nTada have a nice day...");
                            adminLoop = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input!!!");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Sorry try again once!!!");
                }
            }
        }

        //ACCEPT A BOOK REQUEST

        public void AcceptRequest()
        {
            try
            {
                Console.Write("User Id: ");
                int userId = int.Parse(Console.ReadLine());
                Console.Write("Book Id: ");
                int bookId = int.Parse(Console.ReadLine());
                UserBLL userBLL = new UserBLL();
                userBLL.AcceptRequestBLL(userId, bookId);
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a valid input...");
            }
        }

        //ADMIN REQUESTED BOOKS MENU

        private void RequestedSection()
        {
            bool reqLoop = true;
            while (reqLoop == true)
            {
                try
                {
                    Console.WriteLine("Welcome-to-Request-Section--------------");
                    Console.WriteLine("1) Press 1 to show all book request\n" +
                        "2) Press 2 to accept requested books\n" +
                        "3) Press 3 to exit");
                    int reqCase = int.Parse(Console.ReadLine());
                    switch (reqCase)
                    {
                        case 1:
                            UserBL userPL = new UserBL();
                            userPL.GetRequestBook();
                            break;
                        case 2:
                            AcceptRequest();
                            break;
                        case 3:
                            Console.WriteLine("");
                            reqLoop = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input!!!");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Sorry try agian once!!!");
                }
                catch (LibraryMSException)
                {
                    throw new LibraryMSException("Some unknown exception is occured..");
                }
            }
        }

        //DELETE A ACCEPTED BOOK

        public void DeleteRecieved()
        {
            try
            {
                Console.Write("User Id: ");
                int userId = int.Parse(Console.ReadLine());
                Console.Write("Book Id: ");
                int bookId = int.Parse(Console.ReadLine());
                UserBLL userBLL = new UserBLL();
                userBLL.DeleteRecievedBLL(bookId, userId);

            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a valid input...");
            }
            catch (LibraryMSException)
            {
                Console.WriteLine("Try again...");

                throw new LibraryMSException("Some unknown exception is occured..");
            }
        }

        //ADMIN RECIEVED BOOK MENU
        private void RecievedSection()
        {
            bool recLoop = true;
            while (recLoop == true)
            {
                try
                {
                    Console.WriteLine("Welcome-to-Accepted-Section--------------");
                    Console.WriteLine("1) Press 1 to show all book accepted\n" +
                       "2) Press 2 to takeback accepted books\n" +
                       "3) Press 3 to exit");
                    int recCase = int.Parse(Console.ReadLine());
                    switch (recCase)
                    {
                        case 1:
                            UserPL userPL = new UserPL();
                            userPL.GetRecievedBook();
                            break;
                        case 2:
                            DeleteRecieved();
                            break;
                        case 3:
                            Console.WriteLine();
                            recLoop = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input!!!");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Sorry try agian once!!!");
                }
                catch (LibraryMSException)
                {
                    throw new LibraryMSException("Some unknown exception is occured..");
                }
            }
        }
    }
}
