using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMS.Entity;
using LibraryMS.BLL;
using System.Threading.Tasks;

namespace LibraryMS.CSharp
{
    class UserBL
    {
        private User user = new User();
        //USER MENU
        private void GetUserMenu()
        {
            Console.WriteLine("1) Press 1 to add a user\n" +
                "2) Press 2 to update a user\n" +
                "3) Press 3 to delete a user\n" +
                "4) Press 4 to show all user\n" +
                "5) Press 5 to exit");
        }
        //ADD USER INTO USER TABLE
        private void AddUser()
        {
            try
            {
                Console.WriteLine("Enter user details..");
                Console.Write("User Id: ");
                user.UserId = int.Parse(Console.ReadLine());
                Console.Write("User Name: ");
                user.UserName = Console.ReadLine();
                Console.Write("User Email: ");
                user.UserEmail = Console.ReadLine();
                Console.Write("User Password: ");
                user.UserPassword = Console.ReadLine();
                UserBLL userBLL = new UserBLL();
                userBLL.AddUsersBLL(user);
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a valid input!!!");
            }
        }
        //UPDATE USER FROM USER TABLE
        private void UpdateUser()
        {
            try
            {
                Console.WriteLine("Enter user details..");
                Console.Write("User Id: ");
                user.UserId = int.Parse(Console.ReadLine());
                Console.Write("User Name: ");
                user.UserName = Console.ReadLine();
                Console.Write("User Email: ");
                user.UserEmail = Console.ReadLine();
                Console.Write("User Password: ");
                user.UserPassword = Console.ReadLine();
                UserBLL userBLL = new UserBLL();
                userBLL.UpdateUsersBLL(user);
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a valid input!!!");
            }
        }
        //REMOVE USER FROM USER TABLE
        private void RemoveUser()
        {
            try
            {
                Console.WriteLine("Enter user details..");
                Console.Write("User Id: ");
                int userId = int.Parse(Console.ReadLine());
                UserBLL userBLL = new UserBLL();
                userBLL.RemoveUsersBLL(userId);
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a valid input");
            }
        }

        //RETRIEVE USERS FROM USER TABLE

        private void GetAllUser()
        {
            List<User> users = new List<User>();
            UserBLL userBLL = new UserBLL();
            users = userBLL.GetAllUsersBLL();
            Console.WriteLine("---------------------------Users-List---------------------------");
            Console.WriteLine("--Id-----Name---------------Email------------------Password-----");
            foreach (User user in users)
            {
                Console.WriteLine("  " + user.UserId + "\t" + user.UserName + "\t " + user.UserEmail + "\t" + user.UserPassword);
            }
            Console.WriteLine("----------------------------------------------------------------");
        }

        //COMPLETE USER SECTION

        public void UserSection()
        {
            Console.WriteLine("Welcome-to-User-Section-------------");
            bool userLoop = true;
            while (userLoop == true)
            {
                try
                {
                    GetUserMenu();
                    int userCase = int.Parse(Console.ReadLine());
                    switch (userCase)
                    {
                        case 1:
                            AddUser();
                            break;
                        case 2:
                            UpdateUser();
                            break;
                        case 3:
                            RemoveUser();
                            break;
                        case 4:
                            GetAllUser();
                            break;
                        case 5:
                            Console.WriteLine();
                            userLoop = false;
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
            }
        }



        //CODES USED FOR INDIVIDUAL USER.....

        //INDIVIDUAL USER LOGIN CREDENTIAL CHECKING
        public void UserLogin()
        {
            try
            {

                Console.WriteLine("User-Login-----------");
                Console.Write("Email Id: ");
                string userEmail = Console.ReadLine();
                Console.Write("Password: ");
                string userPass = Console.ReadLine();
                UserBLL userBLL = new UserBLL();
                bool isDone = userBLL.UserLogin(userEmail, userPass);
                if (isDone)
                {
                    int userId = userBLL.GetUserIdBLL(userEmail);
                    UserHomeSection(userId);
                }
                else
                {
                    Console.WriteLine("Try again...");
                }
            }
            catch (Exception)
            {
                throw new Exception("Some unknown exception is occured..");
            }

        }
        //INDIVIDUAL USER HOME MENU
        private void GetUserHomeMenu()
        {
            Console.Write("1) Press 1 to show books section\n" +
                "2) Press 2 to show request section\n" +
                "3) Press 3 to show recieve section\n" +
                "4) Press 4 to ");
            Console.Write("logout");
            Console.WriteLine();
        }
        //INDIVIDUAL USER HOME SCREEN
        private void UserHomeSection(int userId)
        {
            Console.WriteLine("Welcome-to-User-Section--------------");
            bool userLoop = true;
            while (userLoop == true)
            {
                try
                {
                    GetUserHomeMenu();
                    int userCase = int.Parse(Console.ReadLine());
                    switch (userCase)
                    {
                        case 1:
                            BookPL bookPL = new BookPL();
                            bookPL.GetAllBook();
                            break;
                        case 2:
                            RequestSection(userId);
                            break;
                        case 3:
                            RecieveSection(userId);
                            break;
                        case 4:
                            Console.WriteLine("Logged out successfully..\n have a nice day...");
                            userLoop = false;
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
                catch (Exception)
                {
                    throw new Exception("Some unknown exception is occured..");
                }
            }
        }

        //REQUEST BOOK MENU

        private void RequestSection(int userId)
        {
            bool reqLoop = true;
            while (reqLoop == true)
            {
                try
                {
                    Console.WriteLine("Welcome-to-Request-Section--------------");
                    Console.WriteLine("1) Press 1 to rise a book request\n" +
                       "2) Press 2 to show requested books\n" +
                       "3) Press 3 to exit");
                    int reqCase = int.Parse(Console.ReadLine());
                    switch (reqCase)
                    {
                        case 1:
                            RequestBook(userId);
                            break;
                        case 2:
                            GetUserRequestBook(userId);
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
                catch (Exception)
                {
                    throw new Exception("Some unknown exception is occured..");
                }
            }
        }

        //REQUEST A BOOK TO BORROW BY INDIVIDUAL USER

        private void RequestBook(int userId)
        {
            try
            {
                Console.Write("Book Id: ");
                int bookId = int.Parse(Console.ReadLine());
                UserBLL userBLL = new UserBLL();
                userBLL.RequestBookBLL(bookId, userId);
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a valid input...");
            }

        }
        //RETRIEVE REQUESTED BOOKS OF INDIVIDUAL USER FROM REQUEST TABLE
        private void GetUserRequestBook(int userId)
        {
            UserBLL userBLL = new UserBLL();
            List<RequestedBook> requestedBooks = userBLL.GetRequestBookBL();
            List<RequestedBook> requestedBooksUser = requestedBooks.FindAll(s => s.UserId == userId);
            Console.WriteLine("-----------------Requested-Book-List-----------------\n" + "--Book-Id---Book-Name---------Date-Requiested--------");
            foreach (RequestedBook requested in requestedBooksUser)
            {
                Console.WriteLine("  " + requested.BookId + "\t" + requested.BookName + "\t\t" + requested.DateRequested.ToShortDateString());
            }
            Console.WriteLine("-----------------------------------------------------");
        }

        //RECIEvE BOOK MENU
        private void RecieveSection(int userId)
        {
            bool recLoop = true;
            while (recLoop == true)
            {
                try
                {
                    Console.WriteLine("Welcome-to-Recieved-Section--------------");
                    Console.WriteLine("1) Press 1 to delete a recieved book\n" +
                      "2) Press 2 to show recieved books\n" +
                      "3) Press 3 to exit");
                    int recCase = int.Parse(Console.ReadLine());
                    switch (recCase)
                    {
                        case 1:
                            DeleteRecieve(userId);
                            break;
                        case 2:
                            GetUserRecievedBook(userId);
                            break;
                        case 3:
                            Console.WriteLine("");
                            recLoop = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input!!!");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry try agian once!!!");
                }
            }
        }

        //RETRIEVE RECIEVED BOOKS OF INDIVIDUAL USER FROM RECIEVED TABLE

        private void GetUserRecievedBook(int userId)
        {
            UserBLL userBLL = new UserBLL();
            List<RecievedBook> recievedBooks = userBLL.GetRecievedBookBLL();
            List<RecievedBook> recievedBooksUser = recievedBooks.FindAll(s => s.UserId == userId);
            Console.WriteLine("------------------Recieved-Book-List-----------------\n" +
                              "--Book-Id---Book-Name----Date-Recieved------");
            foreach (RecievedBook recieved in recievedBooksUser)
            {
                Console.WriteLine("  " + recieved.BookId + "\t" + recieved.BookName + "\t\t" + recieved.DateRecieved.ToShortDateString());
            }
            Console.WriteLine("-----------------------------------------------------");
        }

        //RETRIEVE REQUESTED BOOKS FROM REQUEST TABLE

        public void GetRequestBook()
        {
            UserBLL userBLL = new UserBLL();
            List<RequestedBook> requestedBooks = userBLL.GetRequestBookBL();
            Console.WriteLine("--------------------------User+Book-Requested-List------------------------\n" + "--Book-Id---Book-Name-------Date-Requested--------User-Id---User-Name-----");
            foreach (RequestedBook requested in requestedBooks)
            {
                Console.WriteLine(" " + requested.BookId + "\t" + requested.BookName + "\t"
                    + requested.DateRequested.ToShortDateString() + "\t" + requested.UserId + "\t" + requested.UserName);
            }
            Console.WriteLine("--------------------------------------------------------------------------");
        }

        //RETRIEVE RECIEVED BOOKS FROM RECIEVED TABLE
        public void GetRecievedBook()
        {
            UserBLL userBLL = new UserBLL();
            List<RecievedBook> recievedBooks = userBLL.GetRecievedBookBLL();

            Console.WriteLine("--------------------------User+Book-Recieved-List-------------------------\n" + "--Book-Id---Book-Name-------Date-Accepted---------User-Id---User-Name-----");
            foreach (RecievedBook recieved in recievedBooks)
            {
                Console.WriteLine(" " + recieved.BookId + "\t" + recieved.BookName + "\t"
                    + recieved.DateRecieved.ToShortDateString() + "\t" + recieved.UserId + "\t" + recieved.UserName);
            }
            Console.WriteLine("--------------------------------------------------------------------------");
        }

        //DELETE A RECIEVED BOOK FROM RECIEVED TABLE
        private void DeleteRecieve(int userId)
        {
            try
            {
                Console.Write("Book Id: ");
                int bookId = int.Parse(Console.ReadLine());
                UserBLL userBLL = new UserBLL();
                userBLL.DeleteRecievedBLL(bookId, userId);

            }
            catch (Exception)
            {
                Console.WriteLine("Enter a valid input...");
            }
        }
    }
}