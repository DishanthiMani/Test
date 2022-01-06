using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMS.Exception;
using System.Threading.Tasks;

namespace LibraryMS.CSharp
{
    class Main
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
                            Console.WriteLine("Enter a valid input...");
        
                            break;
                        case 2:
                            Console.WriteLine("Enter a valid input...");
                        
                            break;
                        case 3:
                            Console.WriteLine("Enter a valid input...");
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
                catch (LibraryMSException)
                {
                    throw new LibraryMSException("Some unknown exception is occured..");
                }
            }
        }
    }
}
