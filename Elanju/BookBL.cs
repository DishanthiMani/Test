using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMS.BLL;
using LibraryMS.Entity;
using LibraryMS.Exception;
using System.Threading.Tasks;

namespace LibraryMS.CSharp
{
    class BookBL
    {
        private Book book = new Book();
        //BOOK MENU
        private void GetBookMenu()
        {
            Console.WriteLine("1) Press 1 to add a book\n" +
                "2) Press 2 to update a book\n" +
                "3) Press 3 to delete a book\n" +
                "4) Press 4 to show all book\n" +
                "5) Press 5 to exit");
        }

        //ADD BOOK INTO BOOK TABLE
        private void AddBook()
        {
            try
            {
                Console.WriteLine("Enter book details..");
                Console.Write("Book Id: ");
                book.BookId = int.Parse(Console.ReadLine());
                Console.Write("Book Name: ");
                book.BookName = Console.ReadLine();
                Console.Write("Book Author: ");
                book.BookAuthor = Console.ReadLine();
                Console.Write("Book Copies: ");
                book.BookCopies = int.Parse(Console.ReadLine());
                BookBLL addBook = new BookBLL();
                addBook.AddBookBLL(book.BookId, book.BookName, book.BookAuthor, book.BookCopies);
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a valid input");
            }
            catch (LibraryMSException)
            {
                throw new LibraryMSException("Some unknown exception is occured..");
            }
        }
        //UPDATE BOOK 
        private void UpdateBook()
        {
            try
            {
                Console.WriteLine("Enter book details..");
                Console.Write("Book Id: ");
                book.BookId = int.Parse(Console.ReadLine());
                Console.Write("Book Name: ");
                book.BookName = Console.ReadLine();
                Console.Write("Book Author: ");
                book.BookAuthor = Console.ReadLine();
                Console.Write("Book Copies: ");
                book.BookCopies = int.Parse(Console.ReadLine());
                BookBLL updateBook = new BookBLL();
                updateBook.UpdateBookBLL(book.BookId, book.BookName, book.BookAuthor, book.BookCopies);
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a valid input");
            }
            catch (LibraryMSException)
            {
                throw new LibraryMSException("Some unknown exception is occured..");
            }
        }
        //REMOVE BOOK 
        private void RemoveBook()
        {
            try
            {
                Console.WriteLine("Enter book details..");
                Console.Write("Book Id: ");
                book.BookId = int.Parse(Console.ReadLine());
                BookBLL removeBook = new BookBLL();
                removeBook.RemoveBookBLL(book.BookId);
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a valid input");
            }
            catch (Exception)
            {
                throw new LibraryMSException("Some unknown exception is occured..");
            }
        }
        //RETRIEVE BOOKS        
        public void GetAllBook()
        {
            List<Book> books = new List<Book>();
            BookBLL bookTemp = new BookBLL();
            books = bookTemp.GetAllBookBLL();
            Console.WriteLine("---------------------------Books-List---------------------------");
            Console.WriteLine("--Id-----Name---------------Author-------------------Copies-----");
            foreach (Book book in books)
            {
                Console.WriteLine("  " + book.BookId + "\t" + book.BookName + "\t  " + book.BookAuthor + "\t\t\t" + book.BookCopies);
            }
            Console.WriteLine("----------------------------------------------------------------");
        }

        //COMPLETE BOOK SECTION

        public void BookSection()
        {
            Console.WriteLine("Welcome-to-Book-Section-------------");
            bool bookLoop = true;
            while (bookLoop == true)
            {
                try
                {
                    GetBookMenu();
                    int bookCase = int.Parse(Console.ReadLine());
                    switch (bookCase)
                    {
                        case 1:
                            AddBook();
                            break;
                        case 2:
                            UpdateBook();
                            break;
                        case 3:
                            RemoveBook();
                            break;
                        case 4:
                            GetAllBook();
                            break;
                        case 5:
                            Console.WriteLine("");
                            bookLoop = false;
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