using System;
using System.Collections.Generic;
using LibraryMS.DAL;
using LibraryMS.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryMS.BLL
{
    public class UserBLL
    {
        //USER VALIDATION PART
        private bool UserValidation(User user)
        {
            bool userValid;

            if (user.UserId == 0 || user.UserId >= 100000)
            {
                Console.WriteLine("Invalid User id!!!, user id should be in between 1 to 100000");
                userValid = false;
            }
            else if (user.UserName.Length <= 3 || user.UserName.Length > 30)
            {
                Console.WriteLine("Invalid User name!!!, minimum 2 maximum 30 characters are allowed");
                userValid = false;
            }
            else if (user.UserName.Any(char.IsDigit))
            {
                Console.WriteLine("Invalid User name!!!, name should not contains digit");
                userValid = false;
            }
            else if (!(new Regex("([\\w\\.\\-_]+)?\\w+@[\\w-_]+(\\.\\w+){1,}").IsMatch(user.UserEmail)))
            {
                Console.WriteLine("Invalid Email!!!, email should be an email");
                userValid = false;
            }
            else if (user.UserPassword.Length <= 7 || user.UserPassword.Length > 15)
            {
                Console.WriteLine("Invalid Password!!!, minimum 8 maximum 15 characters are allowed");
                userValid = false;
            }
            else
            {
                userValid = true;
            }
            return userValid;
        }

        UserDAL userDAL = new UserDAL();

        //RETURNING USERS FROM USER TABLE =>BLL
        public List<User> GetAllUsersBLL()
        {
            List<User> users = userDAL.GetAllUserssDAL();
            return users;
        }
        //ADDING USER INTO USER TABLE =>BLLL 
        public void AddUsersBLL(User user)
        {
            bool isValidated = UserValidation(user);
            if (isValidated)
            {
                UserDAL userDAL = new UserDAL();
                bool isDone = userDAL.AddUsersDAL(user);
                if (isDone == true)
                {
                    Console.WriteLine("User added successfully...");
                }
                else
                {
                    Console.WriteLine("Try again...");
                }
                }
                else
                {
                    Console.WriteLine("Try again...");
                }
            }
        }
        //UPDATING USER FROM USER TABLE =>BLL
        public void UpdateUsersBLL(User user)
        {
            bool isValidated = UserValidation(user);
            if (isValidated)
            {
                UserDAL userDAL = new UserDAL();
                bool isDone = userDAL.UpdateUsersDAL(user);
                if (isDone == true)
                {
                    Console.WriteLine("User updated successfully...");
                }
                else
                {
                    Console.WriteLine("Try again...");
                }
            }
            else
            {
                Console.WriteLine("Try again...");
            }
        }
        //REMOVING USER FROM USER TABLE 
        public void RemoveUsersBLL(int userId)
        {
            if (userId == 0 || userId >= 100000)
            {
                Console.WriteLine("Invalid User Id...");
                Console.WriteLine("Try again...");
            }
            else
            {
                UserDAL userDAL = new UserDAL();
                bool isDone = userDAL.RemoveUsersDAL(userId);
                if (isDone)
                {
                    Console.WriteLine("User deleted successfully...");
                }
                else
                {
                    Console.WriteLine("Try again...");
                }
            }
        }


        //CODE FOR INDIVIDUAL USERS......

        //INDIVIDUAL USER LOGIN CREDENTIAL CHECKING 
        public bool UserLogin(string userEmail, string userPass)
        {
            UserDAL userDAL = new UserDAL();
            List<User> users = userDAL.GetAllUserssDAL();
            bool isDone = users.Exists(u => u.UserEmail == userEmail && u.UserPassword == userPass);
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
        //GET USER ID FROM USER TABLE  
        public int GetUserIdBLL(string userEmail)
        {
            List<User> users = userDAL.GetAllUserssDAL();
            User user = users.Find(u => u.UserEmail == userEmail);
            return user.UserId;
        }
        //REQUEST BOOK TO BORROW 
        public void RequestBookBLL(int bookId, int userId)
        {
            Book book = BookDAL.books.Find(b => b.BookId == bookId);
            if (book.BookCopies > 0)
            {
                bool isDone = userDAL.RequestBookDAL(bookId, userId);
                if (isDone)
                {
                    Console.WriteLine("Requested successfully...");
                }
                else
                {
                    Console.WriteLine("Try again...");
                }
            }
            else
            {
                Console.WriteLine("Sorry book is empty...");
                Console.WriteLine("Try again...");
            }
        }
        //RETRIEVE REQUESTED BOOK FROM REQUESTED TABLE 
        public List<RequestedBook> GetRequestBookBL()
        {
            return userDAL.GetRequestBookDAL();
        }
        //ACCEPT A BOOK REQUEST OF INDIVIDUAL USER 
        public void AcceptRequestBLL(int userId, int bookId)
        {
            bool isDone = userDAL.AcceptRequestDAL(userId, bookId);
            if (isDone)
            {
                Console.WriteLine("Accepted successfully...");
            }
            else
            {
                Console.WriteLine("Try again...");
            }
        }
        //RETRIEVE RECIEVED BOOKS FROM RECIEVED TABLE 
        public List<RecievedBook> GetRecievedBookBLL()
        {
            return userDAL.GetRecievedBookDAL();
        }
        //DELETE RECIEVED BOOK FROM RECIEVED TABLE 
        public void DeleteRecievedBLL(int bookId, int userId)
        {
            bool isDone = userDAL.DeleteRecievedDAL(bookId, userId);
            if (isDone)
            {
                Console.WriteLine("Book deleted successfully...");
            }
            else
            {
                Console.WriteLine("Try again...");
            }
        }

    }
}