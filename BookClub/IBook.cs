namespace BookClub{
    public interface IBook
    {
        int BookId {get;}
        string Title {get;}
        string Description {get;}
        string Genre {get;}
        string AuthorLastName {get;}
        string AuthorFirstName {get;}

        /// <summary>
        /// The average rating of the book
        /// </summary>
        /// <value></value>
        double Rating {get;}

        /// <summary>
        /// The number of people who have rated the book
        /// </summary>
        /// <value></value>
        int NumberOfReaders {get;}
    }
}