using System.Collections.Generic;

namespace BookClub
{
    public interface IBookClub
    {
        List<IBook> Books {get;}

        /// <summary>
        /// Loads the data from the books.xml and 
        /// ratings.xml file and populates the Books collection.
        /// Note, the method uses LINQ to read the XML files.
        /// </summary>
        void LoadData();
        
    }
}