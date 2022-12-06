namespace BookClub
{
    public class Book : IBook
    {

        public Book(int _bookId, string _title, string _description, string _genre, string _authorLastName, string _authorFirstName, double _rating, int _numberOfReaders) 
        {
            BookId = _bookId;
            Title = _title;
            Description = _description;
            Genre = _genre;
            AuthorLastName = _authorLastName;
            AuthorFirstName = _authorFirstName;
            Rating = _rating;
            NumberOfReaders = _numberOfReaders;
        }

        //getters and setters
        public int BookId {get;}
        public string Title {get;}
        public string Description {get;}
        public string Genre {get;}
        public string AuthorLastName {get;}
        public string AuthorFirstName {get;}
        public double Rating {get;}
        public int NumberOfReaders {get;}

        public override string ToString() {
            return BookId + "\n" +
                    Title + "\n" +
                    "Desc: " + Description + "\n" +
                    "Genre: " +Genre + "\n" +
                    AuthorLastName + ", "+ AuthorFirstName + "\n" +
                    "Rating: " + Rating + "\n" +
                    "Number Of Readers: " + NumberOfReaders + "\n";
        }
        
    }
}