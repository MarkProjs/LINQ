using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace BookClub
{
    public class BookClub : IBookClub
    {
        private List<IBook> _books = new List<IBook>();
        private XElement booksXml;
        private XElement ratingsXml;
        

        public BookClub(string filePath) {
            booksXml = XElement.Load(filePath + "books.xml");
            ratingsXml = XElement.Load(filePath + "ratings.xml");
        }

        public List<IBook> Books {
            get {
                return _books;
            }
        }

        public void LoadData() 
        {
            //make anonymous type for books
            IEnumerable<XElement> bookElements = booksXml.Elements("book");
            var books = from b in bookElements
                        select new {
                            BookId = b.Attribute("id").Value,
                            Title = b.Element("title").Value,
                            Description = b.Element("description").Value,
                            AuthorLastName = b.Element("author").Attribute("lastName").Value,
                            AuthorFirstName = b.Element("author").Attribute("firstName").Value,
                            Genre = b.Element("genre").Value
                        };

            //make anonymous type for ratings
            IEnumerable<XElement> ratingElements = ratingsXml.Elements("book");
            var ratings = from c in ratingElements
                          select new {
                            BookId = c.Attribute("id").Value,
                            AvgRating = Math.Round((double)c.Elements("rating").Sum(n=>int.Parse(n.Value)) / c.Elements("rating").Count(), 2),
                            NumberOfReaders = c.Elements("rating").Count()
                            };
            
            //join the two anonymous types
            var booksAndRatings = from b in books
                                  join r in ratings on b.BookId equals r.BookId
                                  select  new {b.BookId, b.Title, b.Description, b.AuthorLastName, 
                                               b.AuthorFirstName, b.Genre, r.AvgRating, r.NumberOfReaders};


            //populate the List
            foreach(var br in booksAndRatings)
            {
                _books.Add(new Book(int.Parse(br.BookId), br.Title, br.Description, br.Genre, br.AuthorLastName, br.AuthorFirstName, br.AvgRating, br.NumberOfReaders));
                Console.WriteLine(br);
            }
        }


    }
}