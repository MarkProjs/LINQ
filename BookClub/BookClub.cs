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

        public void LoadData() {
            var bookElements = booksXml.Elements("book");
            var books = from b in bookElements
                        select new {
                            ID = b.Attribute("id").Value,
                            Title = b.Element("title").Value,
                            Description = b.Element("description").Value,
                            AuthorLastName = b.Element("author").Attribute("lastName").Value,
                            AuthorFirstName = b.Element("author").Attribute("firstName").Value,
                            Genre = b.Element("genre").Value
                        };

            
            var ratingElements = ratingsXml.Elements("book");
            var ratings = from c in ratingElements
                         select new {
                            BookId = c.Attribute("id").Value,
                            NumberOfReaders = c.Elements("rating").Count()
                        };

            
            
        }
    }
}