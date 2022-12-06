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
                    // List<IBook> books = bc.Books;
                    bool menu = true;
                    while(menu)
                    {
                        try
                        {   Console.WriteLine("What would you like to see? ");
                            Console.WriteLine();
                            Console.WriteLine("1. View the top-rated books. Press 1");
                            Console.WriteLine("2. Browse books by popular genre. Press 2");
                            Console.WriteLine("3. Search a book by keyword. Press 3");
                            Console.WriteLine("4. Which book is the most popular by its genre. Press 4");
                            Console.WriteLine("5. View the top-rated books. Press 5");
                            Console.WriteLine();
                            string userInput = Console.ReadLine();
                        } catch(Exception e) {
                            Console.WriteLine("Input Error. Try again.");
                            menu = true;
                        }
                    }
                    isTrue = false;

                } catch(Exception e) {
                    Console.WriteLine("The path given was not correct. Try again.");
                    isTrue = true;
                }
            } 
        }
    }
}
