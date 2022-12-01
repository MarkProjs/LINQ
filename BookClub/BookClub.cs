
using System.Collections.Generic;

namespace BookClub
{
    public class BookClub : IBookClub
    {
        private List<IBook> _books = new List<IBook>();

        public BookClub(string filePath) {

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