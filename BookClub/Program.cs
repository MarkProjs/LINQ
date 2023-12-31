﻿using System;
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
                    Console.Write("Please enter the path to the books and ratings files (There is a default folder, just type \"./XML Files/\"): ");
                    string filePath = Console.ReadLine();
                    BookClub bc = new BookClub(filePath.ToLower());
                    bc.LoadData();
                    List<IBook> books = bc.Books;
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
                {   
                    Console.WriteLine("-----------------------------------------------------------------------MAIN MENU---------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("1. View all the Books");
                    Console.WriteLine("2. View the top-rated books. Press 2");
                    Console.WriteLine("3. Browse books by popular genre. Press 3");
                    Console.WriteLine("4. Search a book by keyword. Press 4");
                    Console.WriteLine("5. Search an \"Adams\" last name. Press 5");
                    Console.WriteLine("6. Exit the program. Press 6");
                    Console.WriteLine();
                    Console.Write("What would you like to see? ");
                    string userInput = Console.ReadLine();
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    switch(userInput)
                    {
                        case "1":
                            //print the books and the ratings
                            foreach(Book aBook in books)
                            {
                                Console.WriteLine(aBook);
                            }
                            break;
                            
                        case "2":
                            var top5Books = (from b in books
                                             where b.NumberOfReaders > 20 && b.Rating > 3
                                             orderby b.Rating descending
                                             select b).Take(5);

                            foreach(var book in top5Books) {
                                Console.WriteLine(book);
                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            }
                            Console.WriteLine("These are the top 5 books");      
                            break;  
                        case "3":
                            // grouping the book by its genre
                            var GenreQuery1 = from b in books
                                             group b by b.Genre;
                            
                            var SortBooks = from g in GenreQuery1
                                                    orderby g.Sum(n=>n.NumberOfReaders) descending, g.Average(n=>n.Rating) descending
                                                    select new {
                                                        Books = g,
                                                        NumberOfReadersPerGenre = g.Count(),
                                                        AverageOfRatingsPerGenre = Math.Round(g.Average(n=>n.Rating), 2)
                                                    };
                            
                            foreach(var BooksPerGenre in SortBooks) {
                                Console.WriteLine("Books: ");
                                foreach(var Books in BooksPerGenre.Books) {
                                    Console.WriteLine("\t"+Books.Title);
                                }
                                Console.WriteLine("Number of Books in the genre: "+ BooksPerGenre.NumberOfReadersPerGenre);
                                Console.WriteLine("Average Rating of the genre: "+ BooksPerGenre.AverageOfRatingsPerGenre);
                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            }

                            Console.WriteLine();
                            break;
                            
                        case "4":
                            Console.Write("Keyword to search: ");
                            string UserKeyWord = Console.ReadLine();

                            var BooksFromKeyWord = from b in books
                                                   where b.Title.ToLower().Contains(UserKeyWord.ToLower()) || b.Description.ToLower().Contains(UserKeyWord.ToLower())
                                                   select b;

                            foreach(var BookKey in BooksFromKeyWord)
                            {
                                Console.WriteLine(BookKey);
                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            }         
                            break;
                            
                        case "5":
                            IEnumerable<IBook> AdamsBooks = ExtensionMethod(books);
                            foreach(var BookOfAdam in AdamsBooks) {
                                Console.WriteLine(BookOfAdam);
                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            }
                            break;
                        case "6":
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


        private static IEnumerable<IBook> ExtensionMethod(List<IBook> books) 
        {
            IEnumerable<IBook> BookWithAdamsLastName = Enumerable.Where(books, n=>n.AuthorLastName.Equals("Adams"));

            return BookWithAdamsLastName;

        }
    }
}
