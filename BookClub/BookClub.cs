using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace BookClub
{
    public class BookClub : IBookClub
    {
        private List<IBook> _books = new List<IBook>();
        

        public BookClub(string filePath) {
            XElement booksXml = XElement.Load(filePath + "books.xml");
            XElement ratingsXml = XElement.Load(filePath + "ratings.xml");
        }

        public List<IBook> Books {
            get {
                return _books;
            }
        }

        public void LoadData() {

        }
    }
}