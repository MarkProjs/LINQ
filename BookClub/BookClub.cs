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
            var books = from b in booksXml.Elements("book")
                        select new {
                            ID = b.Attribute("id").Value,
                            Title = b.Element("title").Value,
                            Description = b.Element("description").Value,
                            AuthorLastName = b.Element("author").Attribute("lastName").Value,
                            AuthorFirstName = b.Element("author").Attribute("firstName").Value,
                            Genre = b.Element("genre").Value
                        };
        }
    }
}