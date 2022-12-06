using System;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace BookClub
{
    class Program
    {
        static void Main(string[] args)
        {   Console.WriteLine("Hello!");
            bool isTrue = true;
            while(isTrue) 
            {
                try
                {
                    Console.Write("Please enter the path to the books and ratings files: ");
                    string filePath = Console.ReadLine();
                    BookClub bc = new BookClub(filePath);
                    bc.LoadData();
                    List<IBook> books = bc.Books;
                    //print the books and the ratings
                    foreach(Book aBook in books)
                    {
                        Console.WriteLine(aBook);
                    }

                    isTrue = DisplayMenu(books, isTrue);

                } catch(Exception e) {
                    Console.WriteLine("The path given was not correct. Try again.");
                    isTrue = true;
                }
            } 
        }

        private static bool DisplayMenu(List<IBook> books, bool isTrue) 
        {
            //menu
            bool menu = true;
            while(menu)
            {
                try
                {   Console.WriteLine("What would you like to see? ");
                    Console.WriteLine();
                    Console.WriteLine("1. View the top-rated books. Press 1");
                    Console.WriteLine("2. Browse books by popular genre. Press 2");
                    Console.WriteLine("3. Search a book by keyword. Press 3");
                    Console.WriteLine("4. Most popular book by its genre. Press 4");
                    Console.WriteLine("5. Exit the program. Press 5");
                    Console.WriteLine();
                    string userInput = Console.ReadLine();
                    switch(userInput)
                    {
                        case "1":
                            break;
                        case "2":
                            break;
                        case "3":
                            break;
                        case "4":
                            break;
                        case "5":
                            Console.WriteLine("Have a Good day!");
                            menu = false;
                            break;
                        default:
                            throw new Exception("ERROR!");
                    }
                } catch(Exception e) {
                    Console.WriteLine("Why are you trying to break the code? Come on. Try again.");
                    menu = true;
                }
            }

            return isTrue = false;
        }
    }
}
